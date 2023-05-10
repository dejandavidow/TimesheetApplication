using Domain.Entities;
using Domain.Interfaces;
using Domain.Pagination;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository
{
    public class ClientsRepository : RepositoryBase<Client>, IClientsRepository
    {
        private readonly ApplicationDbContext _context;
        public ClientsRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Client>> GetAllClients(ClientParameters parameters)
        {
            if(String.IsNullOrWhiteSpace(parameters.Name))
            return await FindAll().ToListAsync();
            return await FindByCondtition(x => x.ClientName.ToLower().Contains(parameters.Name.Trim().ToLower())).ToListAsync();
        }

        public async Task<Client> GetClientById(int id)
        {
            return await FindByCondtition(x => x.Id.Equals(id)).FirstOrDefaultAsync();
        }
    }
}
