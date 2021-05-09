using Microsoft.EntityFrameworkCore;
using App.Data.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace App.Infrastructure.Core
{
    public class GlobalContext : IdentityDbContext
    {
        public GlobalContext() : base()
        {

        }

        public GlobalContext(DbContextOptions<GlobalContext> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=DESKTOP-4ITU00B\\SQLEXPRESS;Database = mainDB; Integrated Security = true");
            }
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<User> DbUsers { get; set; }



        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder
                .Entity<Customer>()
                .Property(e => e.CustomerType)
                .HasConversion<string>();

            builder
                .Entity<Transaction>()
                .Property(e => e.TransactionType)
                .HasConversion<string>();

            base.OnModelCreating(builder);
        }
    }
}
