using BankApplication.Src.EFCore.Customers;

namespace BankApplication.Tests.Domain
{
    public class CustomerRepositoryTests
    {
        private readonly CustomerRepository _customerRepository;

        public CustomerRepositoryTests()
        {
            var dataSeed = new BankApplicationSeedData();
            _customerRepository = new(dataSeed.Context);
        }

        [Fact]
        public async Task Should_GetCustomer()
        {

            var result = await _customerRepository.GetAsync(TestData.IdCustomer1);

            Assert.NotNull(result);
            Assert.Equal(TestData.IdCustomer1, result.Id);
        }

        [Fact]
        public async Task Should_GetNullCustomer()
        {
            var result = await _customerRepository.GetAsync(Guid.NewGuid());

            Assert.Null(result);
        }
    }
}
