using BankApplication.Core.Domain;
using BankApplication.Src.Domain.Accounts;
using BankApplication.Src.Domain.Customers;
using Microsoft.EntityFrameworkCore;

namespace BankApplication.Tests
{
    public class BankApplicationSeedData
    {
        public BankApplicationDbContext Context { get; set; }

        public BankApplicationSeedData()
        {
            var options = new DbContextOptionsBuilder<BankApplicationDbContext>().UseInMemoryDatabase(Guid.NewGuid().ToString()).Options;
            Context = new BankApplicationDbContext(options);

            if (!Context.Customers.Any())
            {
                var customers = new List<Customer>
                {
                    TestData.Customer1,
                    TestData.Customer2,
                    TestData.Customer3,
                    TestData.Customer4,
                    TestData.Customer5,
                };
                Context.Customers.AddRange(customers);
                Context.SaveChanges();
            }

            if (!Context.Accounts.Any())
            {
                var accounts = new List<Account>
                {
                    TestData.Account1,
                    TestData.Account2,
                    TestData.Account3,
                    TestData.Account4,
                    TestData.Account5,
                };

                Context.Accounts.AddRange(accounts);
                Context.SaveChanges();
            }
        }
    }
}
