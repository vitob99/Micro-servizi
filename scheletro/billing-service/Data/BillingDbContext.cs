using BillingService.Models;
using Microsoft.EntityFrameworkCore;

namespace BillingService.Data;

public class BillingDbContext : DbContext
{
    public BillingDbContext(DbContextOptions<BillingDbContext> options) : base(options)
    {
    }

    public DbSet<Payment> Payments => Set<Payment>();
    public DbSet<CreditTransaction> CreditTransactions => Set<CreditTransaction>();
    public DbSet<UsageRecord> UsageRecords => Set<UsageRecord>();
    public DbSet<Invoice> Invoices => Set<Invoice>();
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        // TODO STUDENTE: configurare eventuali vincoli e indici
        // ad esempio un indice su UserId, CreatedAt, ecc.
    }
}

