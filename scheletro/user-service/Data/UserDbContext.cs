using Microsoft.EntityFrameworkCore;
using UserService.Models;

namespace UserService.Data
{
    public class UserDbContext : DbContext
    {
        public UserDbContext(DbContextOptions<UserDbContext> options) : base(options) { }


        public DbSet<User> Users { get; set; } = null!;
        public DbSet<SubscriptionPlan> SubscriptionPlans { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<User>(entity =>
            {

                entity.HasIndex(u => u.Email).IsUnique();
                entity.Property(u => u.Email)
                    .IsRequired()
                    .HasMaxLength(200);


                entity.Property(u => u.Name)
                    .HasMaxLength(200);

            });

            modelBuilder.Entity<SubscriptionPlan>(entity =>
            {
                entity.Property(p => p.Name)
                    .IsRequired()
                    .HasMaxLength(100);
            });


            modelBuilder.Entity<SubscriptionPlan>().HasData(
                new SubscriptionPlan
                {
                    Id = 1,
                    Name = "Free",
                    MonthlyCost = 0m,
                    MaxCreditsPerMonth = 100
                },
                new SubscriptionPlan
                {
                    Id = 2,
                    Name = "Pro",
                    MonthlyCost = 10m,
                    MaxCreditsPerMonth = 1000
                },
                new SubscriptionPlan
                {
                    Id = 3,
                    Name = "Enterprise",
                    MonthlyCost = 100m,
                    MaxCreditsPerMonth = int.MaxValue
                }
            );
        }
    }
}