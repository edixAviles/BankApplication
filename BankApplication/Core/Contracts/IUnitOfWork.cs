using BankApplication.Src.Contracts.Accounts;
using BankApplication.Src.Contracts.Customers;
using BankApplication.Src.Contracts.Movements;

namespace BankApplication.Core.Contracts
{
    public interface IUnitOfWork : IDisposable
    {
        ICustomerManager Customers { get; }
        IAccountManager Accounts { get; }
        IMovementManager Movements { get; }
        Task CompleteAsync();
    }
}
