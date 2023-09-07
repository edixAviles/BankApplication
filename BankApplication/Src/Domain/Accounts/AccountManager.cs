using BankApplication.Src.Contracts.Accounts;
using BankApplication.Src.Shared;
using BankApplication.Src.Shared.Domain;

namespace BankApplication.Src.Domain.Accounts
{
    public class AccountManager : IAccountManager
    {
        private readonly IAccountRepository _accountRepository;

        public AccountManager(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }

        public async Task<Account> GetAsync(Guid id)
        {
            var entity = await FoundEntityAsync(id);
            return entity;
        }

        public async Task<Account> InsertAsync(InsertAccountDto accountInsert)
        {
            var account = new Account
            {
                Id = Guid.NewGuid(),
                Number = accountInsert.Number,
                Type = accountInsert.Type,
                InitialBalance = accountInsert.InitialBalance,
                State = true,
                CustomerId = accountInsert.CustomerId
            };

            var entity = await _accountRepository.InsertAsync(account);
            return entity;
        }

        public async Task<Account> UpdateAsync(UpdateAccountDto accountUpdate)
        {
            var entity = await FoundEntityAsync(accountUpdate.Id);
            entity.Number = accountUpdate.Number;
            entity.Type = accountUpdate.Type;
            entity.InitialBalance = accountUpdate.InitialBalance;
            entity.State = accountUpdate.State;
            entity.CustomerId = accountUpdate.CustomerId;

            var entityUpdated = _accountRepository.Update(entity);
            return entityUpdated;
        }

        public async Task<Account> UpateInitialBalanceAsync(Guid id, double balance)
        {
            var entity = await FoundEntityAsync(id);
            entity.InitialBalance = balance;

            var entityUpdated = _accountRepository.Update(entity);
            return entityUpdated;
        }

        public async Task DeleteAsync(Guid id)
        {
            _ = await FoundEntityAsync(id);
            _accountRepository.Delete(id);
        }

        private async Task<Account> FoundEntityAsync(Guid id)
        {
            var entity = await _accountRepository.GetAsync(id);
            return entity ?? throw new ServiceException(AccountConsts.ErrorAccountNotExists);
        }
    }
}
