using Domain.Pagination;
using Microsoft.AspNetCore.Mvc;
using Service.DTOs;
using Service.Interfaces;

namespace TimesheetAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientsController : ControllerBase
    {
        private readonly IClientsService _clientsService;
        public ClientsController(IClientsService clientsService)
        {
            _clientsService = clientsService;
        }
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] ClientParameters queryParameters)
        {
            var clietns = await _clientsService.GetClientsAsync(queryParameters);
            return Ok(clietns);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var client = await _clientsService.GetClientByIdAsync(id);
            return Ok(client);
        }
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ClientDTO clientDTO)
        {
            await _clientsService.AddClientAsync(clientDTO);
            return Ok();
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] ClientDTO clientDTO)
        {
            await _clientsService.UpdateClientAsync(id,clientDTO);
            return Ok();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _clientsService.DeleteClientAsync(id);
            return Ok();
        }
    }
}
