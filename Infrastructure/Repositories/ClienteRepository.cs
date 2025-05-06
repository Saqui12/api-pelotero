
using Dominio.Entities;
using Dominio.Interfaces;
using Infrastructure.Data;
using Microsoft.Identity.Client;

namespace Infrastructure.Repositories
{
    public class ClienteRepository : BaseRepository<Cliente>, IClienteRepository
    {
        public ClienteRepository(PeloterosDbContext context)
            : base(context)
        {
       
        }
    } 
    
    
}
