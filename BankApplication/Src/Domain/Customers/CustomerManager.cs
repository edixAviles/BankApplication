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

        public async Task<Customer> Get(Guid id)
        {
            var entity = await FoundEntity(id);
            return entity;
        }

        public async Task<Customer> Insert(InsertCustomerDto customerInsert)
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

            var entity = await _customerRepository.Insert(customer);
            return entity;
        }

        public async Task<Customer> Update(UpdateCustomerDto customerUpdate)
        {
            var entity = await FoundEntity(customerUpdate.Id);

            entity.Identification = customerUpdate.Identification;
            entity.Name = customerUpdate.Name;
            entity.Gender = customerUpdate.Gender;
            entity.Age = customerUpdate.Age;
            entity.Address = customerUpdate.Address;
            entity.Phone = customerUpdate.Phone;
            entity.Password = customerUpdate.Password;
            entity.State = customerUpdate.State;

            var entityUpdated = await _customerRepository.Update(entity);
            return entityUpdated;
        }

        public async Task Delete(Guid id)
        {
            _ = await FoundEntity(id);
            await _customerRepository.Delete(id);
        }

        private async Task<Customer> FoundEntity(Guid id)
        {
            var entity = await _customerRepository.Get(id);
            return entity ?? throw new ServiceException(CustomerConsts.ErrorCustomerNotExists);
        }
    }
}
