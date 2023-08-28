using BankApplication.Core.Response;
using BankApplication.Src.Contracts.Accounts;
using Microsoft.AspNetCore.Mvc;

namespace BankApplication.Src.Controllers.Accounts
{
    [Route("api/cuentas")]
    [ApiController]
    public class AccountController : ControllerBase, IAccountAppService
    {
        private readonly IAccountAppService _accountAppService;

        public AccountController(IAccountAppService accountAppService)
        {
            _accountAppService = accountAppService;
        }

        [HttpGet]
        public async Task<Response<AccountDto>> GetAccount(Guid id)
        {
            return await _accountAppService.GetAccount(id);
        }

        [HttpPost]
        public async Task<Response<AccountDto>> InsertAccount(InsertAccountDto accountData)
        {
            return await _accountAppService.InsertAccount(accountData);
        }

        [HttpPut]
        public async Task<Response<AccountDto>> UpdateAccount(UpdateAccountDto accountData)
        {
            return await _accountAppService.UpdateAccount(accountData);
        }

        [HttpDelete]
        public async Task<Response<Guid>> DeleteAccount(Guid id)
        {
            return await _accountAppService.DeleteAccount(id);
        }
    }
}
