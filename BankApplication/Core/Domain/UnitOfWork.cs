using BankApplication.Core.Contracts;
using BankApplication.Src.Contracts.Accounts;
using BankApplication.Src.Contracts.Customers;
using BankApplication.Src.Contracts.Movements;

namespace BankApplication.Core.Domain
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly BankApplicationDbContext _context;
        public ICustomerManager CustomerManager { get; }
        public IAccountManager AccountManager { get; }
        public IMovementManager MovementManager { get; }

        public UnitOfWork(
            BankApplicationDbContext context,
            ICustomerManager customers,
            IAccountManager accounts,
            IMovementManager movements
        )
        {
            _context = context;
            CustomerManager = customers;
            AccountManager = accounts;
            MovementManager = movements;
        }

        public async Task CompleteAsync()
        {
            await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                _context.Dispose();
            }
        }
    }
}
