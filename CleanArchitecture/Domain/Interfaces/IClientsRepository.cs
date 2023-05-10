using Domain.Entities;
using Domain.Pagination;

namespace Domain.Interfaces
{
    public interface IClientsRepository : IRepositoryBase<Client>
    {
        Task<IEnumerable<Client>> GetAllClients(ClientParameters queryParameters);
        Task<Client> GetClientById(int id);
    }
}
