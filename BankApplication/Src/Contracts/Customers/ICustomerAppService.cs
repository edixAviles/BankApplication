using BankApplication.Core.Response;

namespace BankApplication.Src.Contracts.Customers
{
    public interface ICustomerAppService
    {
        Task<Response<CustomerDto>> GetCustomer(Guid id);
        Task<Response<CustomerDto>> InsertCustomer(InsertCustomerDto customerData);
        Task<Response<CustomerDto>> UpdateCustomer(UpdateCustomerDto customerData);
        Task<Response<Guid>> DeleteCustomer(Guid id);
    }
}
