using BankApplication.Core.Contracts;
using BankApplication.Core.Response;
using BankApplication.Src.Contracts.Movements;
using BankApplication.Src.Shared;
using BankApplication.Src.Shared.Domain;

namespace BankApplication.Src.Application.Movements
{
    public class MovementAppService : IMovementAppService
    {
        private readonly IUnitOfWork _uow;
        public MovementAppService(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public async Task<Response<MovementDto>> GetMovement(Guid id)
        {
            var response = new ResponseManager<MovementDto>();

            try
            {
                var movement = await _uow.MovementManager.GetAsync(id);

                var dto = new MovementDto
                {
                    Id = movement.Id,
                    Account = movement.Account.Number,
                    Type = movement.Type,
                    InitialBalance = movement.InitialBalance,
                    Value = movement.Value,
                    Balance = movement.Balance
                };
                return response.OnSuccess(dto);
            }
            catch (Exception ex)
            {
                return response.OnError(ServiceError.GetException(ex));
            }
        }

        public async Task<Response<IEnumerable<MovementsReportDto>>> GetMovementsByCustomerAndDate(Guid customerId, DateTime startDate, DateTime endDate)
        {
            var response = new ResponseManager<IEnumerable<MovementsReportDto>>();
            try
            {
                var report = new List<MovementsReportDto>();
                var movements = (await _uow.MovementManager.GetMovementsByCustomerAndDateAsync(customerId, startDate, endDate)).OrderBy(movement => movement.Date).ToList();

                foreach (var movement in movements)
                {
                    report.Add(new MovementsReportDto
                    {
                        Date = movement.Date.ToShortDateString(),
                        Customer = movement.Account.Customer.Name,
                        NumberAccount = movement.Account.Number,
                        TypeAccount = movement.Account.Type,
                        InitialBalance = movement.InitialBalance,
                        Value = movement.Value,
                        Balance = movement.Balance,
                        StateAccount = movement.Account.State
                    });
                }

                return response.OnSuccess(report);
            }
            catch (Exception ex)
            {
                return response.OnError(ServiceError.GetException(ex));
            }
        }

        public async Task<Response<MovementDto>> InsertMovement(InsertMovementDto movementData)
        {
            var response = new ResponseManager<MovementDto>();

            try
            {
                movementData.Type = movementData.Type.ToUpper();

                if (!MovementConsts.Types.Contains(movementData.Type))
                {
                    throw new ServiceException(MovementConsts.ErrorMovementTypeMovementNotValid);
                }

                var account = await _uow.AccountManager.GetAsync(movementData.AccountId);
                if (movementData.Type == MovementConsts.Debit)
                {
                    if (account.InitialBalance == 0)
                    {
                        throw new ServiceException(MovementConsts.ErrorMovementBalanceIsZero);
                    }
                    if (Math.Abs(movementData.Value) > account.InitialBalance)
                    {
                        throw new ServiceException(MovementConsts.ErrorMovementInsufficientBalance);
                    }
                }

                movementData.Value = Math.Abs(movementData.Value) * (movementData.Type == MovementConsts.Credit ? 1 : -1);
                var balance = account.InitialBalance + movementData.Value;
                var movement = await _uow.MovementManager.InsertAsync(movementData, account.InitialBalance, balance);
                _ = await _uow.AccountManager.UpateInitialBalanceAsync(account.Id, balance);
                await _uow.CompleteAsync();

                var dto = new MovementDto
                {
                    Id = movement.Id,
                    Account = movement.Account.Number,
                    Type = movement.Type,
                    InitialBalance = movement.InitialBalance,
                    Value = movementData.Value,
                    Balance = movement.Balance
                };
                return response.OnSuccess(dto);
            }
            catch (Exception ex)
            {
                return response.OnError(ServiceError.GetException(ex));
            }
        }
    }
}
