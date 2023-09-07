using BankApplication.Src.Domain.Accounts;

namespace BankApplication.Src.Contracts.Accounts
{
    public interface IAccountManager
    {
        Task<Account> GetAsync(Guid id);
        Task<Account> InsertAsync(InsertAccountDto accountInsert);
        Task<Account> UpdateAsync(UpdateAccountDto accountUpdate);
        Task<Account> UpateInitialBalanceAsync(Guid id, double balance);
        Task DeleteAsync(Guid id);
    }
}
