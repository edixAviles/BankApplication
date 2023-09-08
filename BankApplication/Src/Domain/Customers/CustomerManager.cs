using BankApplication.Src.Contracts.Customers;
using BankApplication.Src.Shared;
using BankApplication.Src.Shared.Domain;

namespace BankApplication.Src.Domain.Customers
{
    public class CustomerManager : ICustomerManager
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomerManager(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public async Task<Customer> GetAsync(Guid id)
        {
            var entity = await FoundEntityAsync(id);
            return entity;
        }

        public async Task<Customer> InsertAsync(InsertCustomerDto customerInsert)
        {
            var customer = new Customer
            {
                Id = Guid.NewGuid(),
                Identification = customerInsert.Identification,
                Name = customerInsert.Name,
                Gender = customerInsert.Gender,
                Age = customerInsert.Age,
                Address = customerInsert.Address,
                Phone = customerInsert.Phone,

                Password = customerInsert.Password,
                State = true,
            };

            var entity = await _customerRepository.InsertAsync(customer);
            return entity;
        }

        public async Task<Customer> UpdateAsync(UpdateCustomerDto customerUpdate)
        {
            var entity = await FoundEntityAsync(customerUpdate.Id);

            entity.Identification = customerUpdate.Identification;
            entity.Name = customerUpdate.Name;
            entity.Gender = customerUpdate.Gender;
            entity.Age = customerUpdate.Age;
            entity.Address = customerUpdate.Address;
            entity.Phone = customerUpdate.Phone;
            entity.Password = customerUpdate.Password;
            entity.State = customerUpdate.State;

            var entityUpdated = _customerRepository.Update(entity);
            return entityUpdated;
        }

        public async Task DeleteAsync(Guid id)
        {
            _ = await FoundEntityAsync(id);
            await _customerRepository.DeleteAsync(id);
        }

        private async Task<Customer> FoundEntityAsync(Guid id)
        {
            var entity = await _customerRepository.GetAsync(id);
            return entity ?? throw new ServiceException(CustomerConsts.ErrorCustomerNotExists);
        }
    }
}
