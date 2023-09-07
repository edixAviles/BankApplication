using BankApplication.Src.Domain.Customers;

namespace BankApplication.Src.Contracts.Customers
{
    public interface ICustomerManager
    {
        Task<Customer> GetAsync(Guid id);
        Task<Customer> InsertAsync(InsertCustomerDto accountInsert);
        Task<Customer> UpdateAsync(UpdateCustomerDto accountUpdate);
        Task DeleteAsync(Guid id);
    }
}
