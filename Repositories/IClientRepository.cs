using RentAPI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RentAPI.Repositories
{
    public interface IClientRepository
    {
        Task<IEnumerable<Client>> Get();
        Task<Client> Get(int Id);
        Task<Client> Create(Client client);
        Task Delete (int Id);
        Task Update(Client client);
    }
}
