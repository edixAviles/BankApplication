using BankApplication.Core.Contracts;
using BankApplication.Core.Response;
using BankApplication.Src.Contracts.Customers;
using BankApplication.Src.Shared;
using BankApplication.Src.Shared.Domain;

namespace BankApplication.Src.Application.Customers
{
    public class CustomerAppService : ICustomerAppService
    {
        private readonly IUnitOfWork _uow;

        public CustomerAppService(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public async Task<Response<CustomerDto>> GetCustomer(Guid id)
        {
            var response = new ResponseManager<CustomerDto>();

            try
            {
                var customer = await _uow.CustomerManager.GetAsync(id);

                var dto = new CustomerDto
                {
                    Id = customer.Id,
                    Name = customer.Name,
                    Address = customer.Address,
                    Password = customer.Password,
                    State = customer.State
                };
                return response.OnSuccess(dto);
            }
            catch (Exception ex)
            {
                return response.OnError(ServiceError.GetException(ex));
            }
        }

        public async Task<Response<CustomerDto>> InsertCustomer(InsertCustomerDto customerData)
        {
            var response = new ResponseManager<CustomerDto>();

            try
            {
                customerData.Gender = customerData.Gender.ToUpper();
                if (!PersonConsts.Genders.Contains(customerData.Gender))
                {
                    throw new ServiceException(PersonConsts.ErrorPersonIncorrectGender);
                }

                var customer = await _uow.CustomerManager.InsertAsync(customerData);
                await _uow.CompleteAsync();

                var dto = new CustomerDto
                {
                    Id = customer.Id,
                    Name = customer.Name,
                    Address = customer.Address,
                    Password = customer.Password,
                    State = customer.State
                };
                return response.OnSuccess(dto);
            }
            catch (Exception ex)
            {
                return response.OnError(ServiceError.GetException(ex));
            }
        }

        public async Task<Response<CustomerDto>> UpdateCustomer(UpdateCustomerDto customerData)
        {
            var response = new ResponseManager<CustomerDto>();

            try
            {
                customerData.Gender = customerData.Gender.ToUpper();
                if (!PersonConsts.Genders.Contains(customerData.Gender))
                {
                    throw new ServiceException(PersonConsts.ErrorPersonIncorrectGender);
                }

                var customer = await _uow.CustomerManager.UpdateAsync(customerData);
                await _uow.CompleteAsync();

                var dto = new CustomerDto
                {
                    Id = customer.Id,
                    Name = customer.Name,
                    Address = customer.Address,
                    Password = customer.Password,
                    State = customer.State
                };
                return response.OnSuccess(dto);
            }
            catch (Exception ex)
            {
                return response.OnError(ServiceError.GetException(ex));
            }
        }

        public async Task<Response<Guid>> DeleteCustomer(Guid id)
        {
            var response = new ResponseManager<Guid>();

            try
            {
                await _uow.CustomerManager.DeleteAsync(id);
                await _uow.CompleteAsync();

                return response.OnSuccess(id);
            }
            catch (Exception ex)
            {
                return response.OnError(ServiceError.GetException(ex));
            }
        }
    }
}
