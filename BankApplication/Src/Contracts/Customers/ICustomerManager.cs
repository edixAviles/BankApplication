using BankApplication.Src.Domain.Customers;

namespace BankApplication.Src.Contracts.Customers
{
    public interface ICustomerManager
    {
        Task<Customer> Get(Guid id);
        Task<Customer> Insert(InsertCustomerDto accountInsert);
        Task<Customer> Update(UpdateCustomerDto accountUpdate);
        Task Delete(Guid id);
    }
}
