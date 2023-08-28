using BankApplication.Core.Domain;
using BankApplication.Src.Domain.Accounts;

namespace BankApplication.Src.Contracts.Accounts
{
    public interface IAccountRepository : IBaseRepository<Account>
    {
    }
}
