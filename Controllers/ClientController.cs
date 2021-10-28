using Microsoft.AspNetCore.Mvc;
using RentAPI.Model;
using RentAPI.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RentAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly IClientRepository _clientRepository;
        public ClientController(IClientRepository clientRepository)
        {
            _clientRepository = clientRepository;
        }
        [HttpGet] //get all clients
        public async Task<IEnumerable<Client>> GetClients()
        {
            return await _clientRepository.Get();
        }
        [HttpGet("{Id}")]
        public async Task<ActionResult<Client>> GetClients(int Id)
        {
            return await _clientRepository.Get(Id);

        }
        [HttpPut] //update a client
        public async Task<ActionResult> PutClient(int id, [FromBody] Client client)
        {
            if (id != client.Id)
            {
                return BadRequest();
            }
            await _clientRepository.Update(client);
            return NoContent();
        }
        [HttpPost] // insert new client
        public async Task<ActionResult<Client>> PostClient([FromBody] Client client)
        {
            var NewClient = await _clientRepository.Create(client);
            return CreatedAtAction(nameof(GetClients), new { id = NewClient.Id }, NewClient);
        }
        [HttpDelete("{id}")] //delete by id
        public async Task<ActionResult> Delete(int id)
        {
            var clientDelete = await _clientRepository.Get(id);
            if (clientDelete == null)
            {
                return NotFound();
            }
            else
            {
                await _clientRepository.Delete(clientDelete.Id);
                return NoContent();
            }
        }
    }
}
