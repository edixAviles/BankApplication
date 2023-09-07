using BankApplication.Core.Contracts;
using BankApplication.Src.Contracts.Accounts;
using BankApplication.Src.Contracts.Customers;
using BankApplication.Src.Contracts.Movements;

namespace BankApplication.Core.Domain
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly BankApplicationDbContext _context;
        public ICustomerManager Customers { get; }
        public IAccountManager Accounts { get; }
        public IMovementManager Movements { get; }

        public UnitOfWork(
            BankApplicationDbContext context,
            ICustomerManager customers,
            IAccountManager accounts,
            IMovementManager movements
        )
        {
            _context = context;
            Customers = customers;
            Accounts = accounts;
            Movements = movements;
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
