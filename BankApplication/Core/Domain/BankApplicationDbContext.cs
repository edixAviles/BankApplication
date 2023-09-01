using BankApplication.Src.Domain.Accounts;
using BankApplication.Src.Domain.Customers;
using BankApplication.Src.Domain.Movements;
using Microsoft.EntityFrameworkCore;

namespace BankApplication.Core.Domain
{
    public class BankApplicationDbContext : DbContext
    {
        public BankApplicationDbContext(DbContextOptions<BankApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Account> Accounts { get; set; } = null!;
        public DbSet<Customer> Customers { get; set; } = null!;
        public DbSet<Movement> Movements { get; set; } = null!;
    }
}
