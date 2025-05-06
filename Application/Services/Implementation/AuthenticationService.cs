using Application.Services.DTOs;
using Application.Services.DTOs.User;
using Application.Services.Iterfaces;
using Application.Services.Validators.Iterface;
using Dominio.Entities.Identity;
using Dominio.Interfaces.Authentication;
using FluentValidation;
using MapsterMapper;

namespace Application.Services.Implementation
{
    public class AuthenticationService(ITokenMana tokenmana,IUserMana usermana, IRoleMana rolemana
        , IAppLogger<AuthenticationService> logger, IMapper _mapper,IValidationService _validator
        , IValidator<CreateUser> createUserValidate ) : IAuthenticationService
    {
      
                   //"email": "adminadmin@gmail.com",
                  //"password": "Admin123!Admin123",

        public async Task<LoginResponse> Login(LoginUser loginuser)
        {
            if(loginuser==null)
                return new LoginResponse { Message = "Error al iniciar sesion" };
            // validation

            var user = _mapper.Map<AppUser>(loginuser);
            user.PasswordHash = loginuser.Password;

            bool LoginResult = await usermana.LoginUser(user);
            if(!LoginResult)
                return new LoginResponse { Message = "Error al iniciar sesion" };

            var _user = await usermana.GetUserByEmail(loginuser.Email);
            var claims = await usermana.GetUserClaims(_user!.Email!);

            string jwttoken = tokenmana.GenerateToken(claims);
            string refreshtoken = tokenmana.getRefreshToken();

            int saveTokenResult = await tokenmana.AddRefreshToken(_user!.Id, refreshtoken);

            return saveTokenResult <= 0 ? new LoginResponse { Message = "Error al guardar el refreshtoken" }
                : new LoginResponse
                {
                    Token = jwttoken,
                    RefreshToken = refreshtoken,
                    Message = "Inicio de sesion exitoso",
                    Success = true
                };
        }

        public async Task<LoginResponse> RenewToken(string refreshToken)
        {
            bool validateTokenResult =await  tokenmana.ValidateRefreshToken(refreshToken);
            if (!validateTokenResult)
                return new LoginResponse { Message = "invalid token" };

            string userId = await tokenmana.GetUserIdFromRefreshToken(refreshToken);
            AppUser? user = await usermana.GetUserById(userId);
            var claims = await usermana.GetUserClaims(user!.Email!);
            string newJwtToken = tokenmana.GenerateToken(claims);
            string newRefreshToken = tokenmana.getRefreshToken();
            await tokenmana.UpdateRefreshToken(userId, newRefreshToken);
            return new LoginResponse
            {
                Token = newJwtToken,
                RefreshToken = newRefreshToken,
                Message = "Token renewed",
                Success = true
            };
        }

        public async Task<ServiceResponse> Register(CreateUser createUser)
        {
            await _validator.ValidateAsync(createUser, createUserValidate);

            var model = _mapper.Map<AppUser>(createUser);
            model.UserName = createUser.Email;
            model.PasswordHash = createUser.Password;
            
            var result = await usermana.CreateUser(model);
            if (!result)
                return new ServiceResponse { Message = "Error al registrar el usuario" };            

            var _user = await usermana.GetUserByEmail(createUser.Email);
            var Users = await usermana.GetAllUsers();
            bool Roleresult =await rolemana.AddUserToRole(_user!, Users.Count() > 1 ? "EMPLOYEE" :  "ADMIN");

            if (!Roleresult)
            { var  remove = await usermana.DeleteUserByEmail(_user!.Email!); 
               if (!remove )
                {
                    logger.LogError($"user {_user.Email} failed to be remove", new Exception("Error a asignar un rol al usuario"));
                    return new ServiceResponse { Message = "Error al eliminar el usuario" };
                }

            }

            return new ServiceResponse { Message = "Usuario registrado con exito" , Success=true};
        }
        public async Task<ServiceResponse> DeleteUser(string email)
        {
            if (email == null)
                return new ServiceResponse { Message = "Debe ingresar un email" };

            var user = await usermana.GetUserByEmail(email);
            if (user is null)
                return new ServiceResponse { Message = "Usuario no encontrado" };
                
            await usermana.DeleteUserByEmail(email);
            return new ServiceResponse { Message = "Usuario eliminado con exito", Success = true };
        }
    }
}
