using Microsoft.EntityFrameworkCore;
using Models.Model;

namespace Data
{
    public class CustomersDbContext : DbContext
    {
        public CustomersDbContext(DbContextOptions<CustomersDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>()
                .HasMany(c => c.Quotes)
                .WithOne(e => e.Customer)
                .HasForeignKey(e => e.CustomerId);
        }
        public DbSet<Customer> Customers { get; set; }

        public DbSet<Quote> Quotes { get; set; }
    }
}
