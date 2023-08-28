using BankApplication.Core.Response;
using BankApplication.Src.Contracts.Accounts;
using BankApplication.Src.Contracts.Customers;
using BankApplication.Src.Shared;
using BankApplication.Src.Shared.Domain;

namespace BankApplication.Src.Application.Accounts
{
    public class AccountAppService : IAccountAppService
    {
        private readonly IAccountManager _accountManager;
        private readonly ICustomerManager _customerManager;

        public AccountAppService(IAccountManager accountManager, ICustomerManager customerManager)
        {
            _accountManager = accountManager;
            _customerManager = customerManager;
        }

        public async Task<Response<AccountDto>> GetAccount(Guid id)
        {
            var response = new ResponseManager<AccountDto>();

            try
            {
                var account = await _accountManager.Get(id);

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

                var customer = await _customerManager.Get(accountData.CustomerId);
                var account = await _accountManager.Insert(accountData);

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

                var account = await _accountManager.Update(accountData);

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
                await _accountManager.Delete(id);
                return response.OnSuccess(id);
            }
            catch (Exception ex)
            {
                return response.OnError(ServiceError.GetException(ex));
            }
        }
    }
}
