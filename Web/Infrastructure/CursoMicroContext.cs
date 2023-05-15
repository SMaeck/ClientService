using Microsoft.EntityFrameworkCore;
using Web.Infrastructure.Configurations;
using Web.Models;

namespace Web.Infrastructure;

public class CursoMicroContext : DbContext
{
    public CursoMicroContext() : base("CursoMicro")
    {
    }
    
    //public CursoMicroContext(DbContextOptions<CursoMicroContext> options) : base(options) 
    //{ 
    //}
    //
    public DbSet<Cliente> Clientes { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Server=localhost\\SQLEXPRESS; DataBase=CursoMicro;Trusted_Connection=True;TrustServerCertificate=Yes;MultipleActiveResultSets=false;Integrated Security=true");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        if (modelBuilder is null)
            throw new ArgumentNullException(nameof(modelBuilder));

        new ClienteEntityTypeConfiguration().Configure(modelBuilder.Entity<Cliente>());
    }
}
