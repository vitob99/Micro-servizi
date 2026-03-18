using DeployService.Models;
using Microsoft.EntityFrameworkCore;

namespace DeployService.Data;

public class DeployDbContext : DbContext
{
    public DeployDbContext(DbContextOptions<DeployDbContext> options) : base(options)
    {
    }

    public DbSet<Deployment> Deployments => Set<Deployment>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        // TODO STUDENTE: opzionale, aggiungere configurazioni (indici su UserId, CreatedAt, ecc.)
    }
}

