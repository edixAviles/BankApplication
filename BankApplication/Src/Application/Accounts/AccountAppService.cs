using BankApplication.Core.Contracts;
using BankApplication.Core.Response;
using BankApplication.Src.Contracts.Accounts;
using BankApplication.Src.Shared;
using BankApplication.Src.Shared.Domain;

namespace BankApplication.Src.Application.Accounts
{
    public class AccountAppService : IAccountAppService
    {
        private readonly IUnitOfWork _uow;

        public AccountAppService(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public async Task<Response<AccountDto>> GetAccount(Guid id)
        {
            var response = new ResponseManager<AccountDto>();

            try
            {
                var account = await _uow.AccountManager.GetAsync(id);

                var dto = new AccountDto
                {
                    Id = account.Id,
                    Number = account.Number,
                    Type = account.Type,
                    InitialBalance = account.InitialBalance,
                    State = account.State,
                    Customer = account.Customer.Name
                };
                return response.OnSuccess(dto);
            }
            catch (Exception ex)
            {
                return response.OnError(ServiceError.GetException(ex));
            }
        }

        public async Task<Response<AccountDto>> InsertAccount(InsertAccountDto accountData)
        {
            var response = new ResponseManager<AccountDto>();

            try
            {
                accountData.Type = accountData.Type.ToUpper();
                if (!AccountConsts.Types.Contains(accountData.Type))
                {
                    throw new ServiceException(AccountConsts.ErrorAccountTypeAccountNotValid);
                }

                var customer = await _uow.CustomerManager.GetAsync(accountData.CustomerId);
                var account = await _uow.AccountManager.InsertAsync(accountData);
                await _uow.CompleteAsync();

                var dto = new AccountDto
                {
                    Id = account.Id,
                    Number = account.Number,
                    Type = account.Type,
                    InitialBalance = account.InitialBalance,
                    State = account.State,
                    Customer = account.Customer.Name
                };
                return response.OnSuccess(dto);
            }
            catch (Exception ex)
            {
                return response.OnError(ServiceError.GetException(ex));
            }
        }

        public async Task<Response<AccountDto>> UpdateAccount(UpdateAccountDto accountData)
        {
            var response = new ResponseManager<AccountDto>();

            try
            {
                accountData.Type = accountData.Type.ToUpper();
                if (!AccountConsts.Types.Contains(accountData.Type))
                {
                    throw new ServiceException(AccountConsts.ErrorAccountTypeAccountNotValid);
                }

                var account = await _uow.AccountManager.UpdateAsync(accountData);
                await _uow.CompleteAsync();

                var dto = new AccountDto
                {
                    Id = account.Id,
                    Number = account.Number,
                    Type = account.Type,
                    InitialBalance = account.InitialBalance,
                    State = account.State,
                    Customer = account.Customer.Name
                };
                return response.OnSuccess(dto);
            }
            catch (Exception ex)
            {
                return response.OnError(ServiceError.GetException(ex));
            }
        }

        public async Task<Response<Guid>> DeleteAccount(Guid id)
        {
            var response = new ResponseManager<Guid>();

            try
            {
                await _uow.AccountManager.DeleteAsync(id);
                await _uow.CompleteAsync();

                return response.OnSuccess(id);
            }
            catch (Exception ex)
            {
                return response.OnError(ServiceError.GetException(ex));
            }
        }
    }
}
