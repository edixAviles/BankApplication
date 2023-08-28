using BankApplication.Core.Domain;
using BankApplication.Src.Contracts.Accounts;
using Microsoft.EntityFrameworkCore;

namespace BankApplication.Src.Domain.Accounts
{
    public class AccountRepository : IAccountRepository
    {
        private readonly BaseContext _context;

        public AccountRepository(BaseContext context)
        {
            _context = context;
        }

        public async Task<Account?> Get(Guid id)
        {
            var entity = await _context.Accounts
                .Include(account => account.Customer)
                .FirstOrDefaultAsync(account => account.Id == id);
            return entity;
        }

        public async Task<Account> Insert(Account entity)
        {
            var createdEntity = await _context.Accounts.AddAsync(entity);
            await _context.SaveChangesAsync();

            return createdEntity.Entity;
        }

        public async Task<Account> Update(Account entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return entity;
        }

        public async Task Delete(Guid id)
        {
            var entity = await _context.Accounts.FindAsync(id);
            if (entity != null)
            {
                _context.Accounts.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }
    }
}
