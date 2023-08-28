using BankApplication.Src.Domain.Accounts;
using BankApplication.Src.Domain.Customers;
using BankApplication.Src.Domain.Movements;
using Microsoft.EntityFrameworkCore;

namespace BankApplication.Core.Domain
{
    public class BaseContext : DbContext
    {
        public BaseContext(DbContextOptions<BaseContext> options) : base(options)
        {
        }

        public DbSet<Account> Accounts { get; set; } = null!;
        public DbSet<Customer> Customers { get; set; } = null!;
        public DbSet<Movement> Movements { get; set; } = null!;
    }
}
