using Microsoft.EntityFrameworkCore;
using Clientes.Infrastructure.Entities;
using System.Collections.Generic;

namespace Clientes.Infrastructure
{
    public class ClienteDbContext : DbContext
    {
        public ClienteDbContext(DbContextOptions<ClienteDbContext> options) : base(options)
        {
        }

        public DbSet<Cliente> Clientes { get; set; }
    }
}