using BankApplication.Src.Contracts.Accounts;
using BankApplication.Src.Contracts.Customers;
using BankApplication.Src.Contracts.Movements;

namespace BankApplication.Core.Contracts
{
    public interface IUnitOfWork : IDisposable
    {
        ICustomerManager CustomerManager { get; }
        IAccountManager AccountManager { get; }
        IMovementManager MovementManager { get; }
        Task CompleteAsync();
    }
}
