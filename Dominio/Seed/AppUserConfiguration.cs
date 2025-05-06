using Dominio.Entities.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Cryptography;

namespace Dominio.Seed
{
    [NotMapped]
    public class AppUserConfiguration : IEntityTypeConfiguration<AppUser>
    {
        public void Configure(EntityTypeBuilder<AppUser> builder)
        {
            
            builder.HasData(
                new AppUser
                {
                    Id = "07bc1990-5e8d-4237-a9e4-8e6b8ba56237",
                    FullName = "Admin",
                    Email = "admin@gmail.com",
                    PasswordHash = "AQAAAAIAAYagAAAAENtQei31/Xu5Vp2qYvDei0I9mcIrKXtQIVC06UpeM5t5Ye+yyH9P567/BdUDjdcLXA==",
                    UserName = "Admin1234!",
                    AccessFailedCount = 0,
                    ConcurrencyStamp = "892bd384-4698-42a8-90e0-2a359e6af3bd",
                    EmailConfirmed = false,
                    LockoutEnabled = false,
                    LockoutEnd = null,
                    NormalizedEmail = null,
                    NormalizedUserName = null,
                    PhoneNumber = null,
                    PhoneNumberConfirmed = false,
                    SecurityStamp = "e2b5ce7a-c6a1-4c1c-8f9e-2f9212ee73bc",
                    TwoFactorEnabled = false
                },
                new AppUser
                {
                    Id = "078a1ad8e-302a-4e75-a156-f997bb40d131",
                    FullName = "Employee",
                    Email = "employee@gmail.com",
                    PasswordHash = "AQAAAAIAAYagAAAAEJEzGW6Zdg5WK+11uKwInQYzGilIocBEaPyQvhbx70dNp/UC3LvSbDa4u13kA/oYRw==",
                    UserName = "Employee1234!",
                    AccessFailedCount = 0,
                    ConcurrencyStamp = "462bd384-4698-42a8-90e0-2a359e6af3bd",
                    EmailConfirmed = false,
                    LockoutEnabled = false,
                    LockoutEnd = null,
                    NormalizedEmail = null,
                    NormalizedUserName = null,
                    PhoneNumber = null,
                    PhoneNumberConfirmed = false,
                    SecurityStamp = "e0b5ce7a-c6a1-4c1c-8f9e-2f9212ee73bc",
                    TwoFactorEnabled = false
                },
                new AppUser
                {
                    Id = "079a1rd8e-302a-4e75-a156-f997bb40d131",
                    FullName = "User",
                    Email = "user@gmail.com",
                    PasswordHash = "AQAAAAIAAYagAAAAEDLkzYgM8E5nfOEtGwmnAAVRnsB0qfN80VG1A9a0hHkfoTFJ05O2h0wyXwvxZwY6rg==",
                    UserName = "User1234!",
                    AccessFailedCount = 0,
                    ConcurrencyStamp = "162bd384-4698-42a8-90e0-2a359e6af3bd",
                    EmailConfirmed = false,
                    LockoutEnabled = false,
                    LockoutEnd = null,
                    NormalizedEmail = null,
                    NormalizedUserName = null,
                    PhoneNumber = null,
                    PhoneNumberConfirmed = false,
                    SecurityStamp = "e7b5ce7a-c6a1-4c1c-8f9e-2f9212ee73bc",
                    TwoFactorEnabled = false


                }
            );
        }


    }


}