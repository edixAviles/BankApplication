using BankApplication.Core.Response;
using BankApplication.Src.Contracts.Customers;
using Microsoft.AspNetCore.Mvc;

namespace BankApplication.Src.Controllers.Customers
{
    [Route("api/clientes")]
    [ApiController]
    public class CustomerController : ControllerBase, ICustomerAppService
    {
        private readonly ICustomerAppService _customerAppService;

        public CustomerController(ICustomerAppService customerAppService)
        {
            _customerAppService = customerAppService;
        }

        [HttpGet]
        public async Task<Response<CustomerDto>> GetCustomer(Guid id)
        {
            return await _customerAppService.GetCustomer(id);
        }

        [HttpPost]
        public async Task<Response<CustomerDto>> InsertCustomer(InsertCustomerDto customerData)
        {
            return await _customerAppService.InsertCustomer(customerData);
        }

        [HttpPut]
        public async Task<Response<CustomerDto>> UpdateCustomer(UpdateCustomerDto customerData)
        {
            return await _customerAppService.UpdateCustomer(customerData);
        }

        [HttpDelete]
        public async Task<Response<Guid>> DeleteCustomer(Guid id)
        {
            return await _customerAppService.DeleteCustomer(id);
        }
    }
}
