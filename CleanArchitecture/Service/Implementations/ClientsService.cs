using Domain.Entities;
using Domain.Interfaces;
using Domain.Pagination;
using Mapster;
using Service.DTOs;
using Service.Interfaces;
using Service.Pagination;

namespace Service.Implementations
{
    public class ClientsService : IClientsService
    {
        private readonly IUnitOfWork _unitOfWork;
        public ClientsService(IUnitOfWork work)
        {
            _unitOfWork = work;
        }

        public async Task AddClientAsync(ClientDTO clientDTO)
        {
            _unitOfWork.ClientsRepository.Create(clientDTO.Adapt<Client>());
            await _unitOfWork.SaveChanges();
        }

        public async Task DeleteClientAsync(int id)
        {
          var client = await _unitOfWork.ClientsRepository.GetClientById(id);
            _unitOfWork.ClientsRepository.Delete(client);
            await _unitOfWork.SaveChanges();
        }

        public async Task<ClientDTO> GetClientByIdAsync(int id)
        {
            var client = await _unitOfWork.ClientsRepository.GetClientById(id);
            var clientDTO = client.Adapt<ClientDTO>();
            return clientDTO;
        }

        public async Task<PagedList<ClientDTO>> GetClientsAsync(ClientParameters queryParameters)
        {
            var clients = await _unitOfWork.ClientsRepository.GetAllClients(queryParameters);
            var dtos = clients.Adapt<IEnumerable<ClientDTO>>();
            return  PagedList<ClientDTO>.ToPagedList(dtos,queryParameters.PageNumber,queryParameters.PageSize);
        }

        public async Task UpdateClientAsync(int id, ClientDTO clientDTO)
        {
            var client = await _unitOfWork.ClientsRepository.GetClientById(id);
            clientDTO.Adapt(client);
            _unitOfWork.ClientsRepository.Update(client);
            await _unitOfWork.SaveChanges();
        }
    }
}
