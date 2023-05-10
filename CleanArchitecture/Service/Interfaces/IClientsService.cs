using Domain.Pagination;
using Service.DTOs;
using Service.Pagination;
namespace Service.Interfaces
{
    public interface IClientsService
    {
        Task<PagedList<ClientDTO>> GetClientsAsync(ClientParameters queryParameters);
        Task<ClientDTO> GetClientByIdAsync(int id);
        Task DeleteClientAsync(int id);
        Task UpdateClientAsync(int id, ClientDTO clientDTO);
        Task AddClientAsync(ClientDTO clientDTO);
    }
}
