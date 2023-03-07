using Microsoft.EntityFrameworkCore;
using domain;
using persistence.maps;

namespace persistence;
public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<Cliente> Clientes {get; set;}

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {        
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ClienteMap).Assembly);
    }
}