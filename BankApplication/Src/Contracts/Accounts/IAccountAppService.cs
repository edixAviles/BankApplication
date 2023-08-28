using BankApplication.Core.Response;

namespace BankApplication.Src.Contracts.Accounts
{
    public interface IAccountAppService
    {
        Task<Response<AccountDto>> GetAccount(Guid id);
        Task<Response<AccountDto>> InsertAccount(InsertAccountDto accountData);
        Task<Response<AccountDto>> UpdateAccount(UpdateAccountDto accountData);
        Task<Response<Guid>> DeleteAccount(Guid id);
    }
}
