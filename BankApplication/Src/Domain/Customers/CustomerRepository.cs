using BankApplication.Core.Domain;
using BankApplication.Src.Contracts.Customers;
using Microsoft.EntityFrameworkCore;

namespace BankApplication.Src.Domain.Customers
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly BaseContext _context;

        public CustomerRepository(BaseContext context)
        {
            _context = context;
        }

        public async Task<Customer?> Get(Guid id)
        {
            var entity = await _context.Customers.FirstOrDefaultAsync(customer => customer.Id == id);
            return entity;
        }

        public async Task<Customer> Insert(Customer entity)
        {
            var createdEntity = await _context.Customers.AddAsync(entity);
            await _context.SaveChangesAsync();

            return createdEntity.Entity;
        }

        public async Task<Customer> Update(Customer entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return entity;
        }

        public async Task Delete(Guid id)
        {
            var entity = await _context.Customers.FindAsync(id);
            if (entity != null)
            {
                _context.Customers.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }
    }
}
