using Microsoft.EntityFrameworkCore;
using RentAPI.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RentAPI.Repositories
{
    public class ClientRepository : IClientRepository
    {
        private readonly ClientContext _context;
        public ClientRepository(ClientContext context)
        {
            _context = context;
        }
        public async Task<Client> Create(Client client)
        {
            _context.Clients.Add(client);
            await _context.SaveChangesAsync();
            return client;
        }
        public async Task Delete(int Id)
        {
            var clientToDelete = await _context.Clients.FindAsync(Id);
            _context.Clients.Remove(clientToDelete);
            await _context.SaveChangesAsync();
        }
        public async Task<IEnumerable<Client>> Get()
        {
            return await _context.Clients.ToListAsync();
        }
        public async Task<Client> Get(int Id)
        {
            return await _context.Clients.FindAsync(Id);
        }
        public async Task Update(Client client)
        {
            _context.Entry(client).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
