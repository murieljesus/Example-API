using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RentAPI.Model
{
    public class ClientContext :DbContext
    {
        public ClientContext(DbContextOptions<ClientContext> options)
            :base(options)
        {
            Database.EnsureCreated();
        }
        public DbSet<Client>Clients { get; set; }
    }
}
