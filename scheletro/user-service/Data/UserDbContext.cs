using Microsoft.EntityFrameworkCore;
using UserService.Models;

namespace UserService.Data;

public class UserDbContext : DbContext
{
    public UserDbContext(DbContextOptions<UserDbContext> options) : base(options)
    {
    }

    public DbSet<User> Users => Set<User>();

    // TODO STUDENTE:
    // - Aggiungi eventualmente configurazioni fluent API (es. lunghezze massime, indici, ecc.)
    // - Opzionale: configura seeding dati iniziali
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        // TODO: configurare il modello User (es. proprietà obbligatorie, indici su Email)
    }
}

