using BankApplication.Src.Contracts.Movements;
using BankApplication.Src.Shared;
using BankApplication.Src.Shared.Domain;

namespace BankApplication.Src.Domain.Movements
{
    public class MovementManager : IMovementManager
    {
        private readonly IMovementRepository _movementRepository;

        public MovementManager(IMovementRepository movementRepository)
        {
            _movementRepository = movementRepository;
        }

        public async Task<Movement> Get(Guid id)
        {
            var entity = await FoundEntity(id);
            return entity;
        }

        public async Task<List<Movement>> GetMovementsByCustomerAndDate(Guid customerId, DateTime startDate, DateTime endDate)
        {
            var movements = await _movementRepository.GetMovementsByCustomerAndDate(customerId, startDate, endDate);
            return movements;
        }

        public async Task<Movement> Insert(InsertMovementDto movementInsert, double initialBalance, double balance)
        {
            var movement = new Movement
            {
                Id = Guid.NewGuid(),
                Date = DateTime.Now,
                Type = movementInsert.Type,
                InitialBalance = initialBalance,
                Value = movementInsert.Value,
                Balance = balance,
                AccountId = movementInsert.AccountId
            };

            var entity = await _movementRepository.Insert(movement);
            return entity;
        }

        private async Task<Movement> FoundEntity(Guid id)
        {
            var entity = await _movementRepository.Get(id);
            return entity ?? throw new ServiceException(MovementConsts.ErrorMovementNotExists);
        }
    }
}
