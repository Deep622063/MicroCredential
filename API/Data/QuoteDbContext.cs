using Microsoft.EntityFrameworkCore;
using Models.Model;

namespace Data
{
    public class QuoteDbContext : DbContext
    {
        public QuoteDbContext(DbContextOptions<QuoteDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>()
                .HasMany(c => c.Quotes)
                .WithOne(e => e.Customer)
                .HasForeignKey(e => e.CustomerId);
        }

        public DbSet<Quote> Quotes { get; set; }

        public DbSet<Customer> Customers { get; set; }
    }
}
