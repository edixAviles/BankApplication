using BankApplication.Src.Domain.Accounts;

namespace BankApplication.Src.Contracts.Accounts
{
    public interface IAccountManager
    {
        Task<Account> Get(Guid id);
        Task<Account> Insert(InsertAccountDto accountInsert);
        Task<Account> Update(UpdateAccountDto accountUpdate);
        Task<Account> UpateInitialBalance(Guid id, double balance);
        Task Delete(Guid id);
    }
}
