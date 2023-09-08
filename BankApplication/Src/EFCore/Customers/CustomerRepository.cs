using BankApplication.Core.Domain;
using BankApplication.Src.Domain.Customers;

namespace BankApplication.Src.EFCore.Customers
{
    public class CustomerRepository : GenericRepository<Customer>, ICustomerRepository
    {
        public CustomerRepository(BankApplicationDbContext context) : base(context)
        {
        }
    }
}
