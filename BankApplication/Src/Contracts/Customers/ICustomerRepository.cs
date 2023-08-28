using BankApplication.Core.Domain;
using BankApplication.Src.Domain.Customers;

namespace BankApplication.Src.Contracts.Customers
{
    public interface ICustomerRepository : IBaseRepository<Customer>
    {
    }
}
