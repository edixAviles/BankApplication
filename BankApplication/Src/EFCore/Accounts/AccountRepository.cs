using BankApplication.Core.Domain;
using BankApplication.Src.Domain.Accounts;
using Microsoft.EntityFrameworkCore;

namespace BankApplication.Src.EFCore.Accounts
{
    public class AccountRepository : GenericRepository<Account>, IAccountRepository
    {
        public AccountRepository(BankApplicationDbContext context) : base(context)
        {
        }

        public override async Task<Account?> GetAsync(Guid id)
        {
            var entity = await dbSet
                .Include(account => account.Customer)
                .FirstOrDefaultAsync(account => account.Id == id);
            return entity;
        }
    }
}
