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

        public async Task<Account> Get(Guid id)
        {
            var entity = await FoundEntity(id);
            return entity;
        }

        public async Task<Account> Insert(InsertAccountDto accountInsert)
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

            var entity = await _accountRepository.Insert(account);
            return entity;
        }

        public async Task<Account> Update(UpdateAccountDto accountUpdate)
        {
            var entity = await FoundEntity(accountUpdate.Id);
            entity.Number = accountUpdate.Number;
            entity.Type = accountUpdate.Type;
            entity.InitialBalance = accountUpdate.InitialBalance;
            entity.State = accountUpdate.State;
            entity.CustomerId = accountUpdate.CustomerId;

            var entityUpdated = await _accountRepository.Update(entity);
            return entityUpdated;
        }

        public async Task<Account> UpateInitialBalance(Guid id, double balance)
        {
            var entity = await FoundEntity(id);
            entity.InitialBalance = balance;

            var entityUpdated = await _accountRepository.Update(entity);
            return entityUpdated;
        }

        public async Task Delete(Guid id)
        {
            _ = await FoundEntity(id);
            await _accountRepository.Delete(id);
        }

        private async Task<Account> FoundEntity(Guid id)
        {
            var entity = await _accountRepository.Get(id);
            return entity ?? throw new ServiceException(AccountConsts.ErrorAccountNotExists);
        }
    }
}
