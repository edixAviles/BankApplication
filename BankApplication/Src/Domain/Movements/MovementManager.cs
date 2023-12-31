﻿using BankApplication.Src.Contracts.Movements;
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

        public async Task<Movement> GetAsync(Guid id)
        {
            var entity = await FoundEntityAsync(id);
            return entity;
        }

        public async Task<IEnumerable<Movement>> GetMovementsByCustomerAndDateAsync(Guid customerId, DateTime startDate, DateTime endDate)
        {
            var movements = await _movementRepository.GetMovementsByCustomerAndDateAsync(customerId, startDate, endDate);
            return movements;
        }

        public async Task<Movement> InsertAsync(InsertMovementDto movementInsert, double initialBalance, double balance)
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

            var entity = await _movementRepository.InsertAsync(movement);
            return entity;
        }

        private async Task<Movement> FoundEntityAsync(Guid id)
        {
            var entity = await _movementRepository.GetAsync(id);
            return entity ?? throw new ServiceException(MovementConsts.ErrorMovementNotExists);
        }
    }
}
