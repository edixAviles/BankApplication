using BankApplication.Core.Domain;
using BankApplication.Src.Application.Movements;
using BankApplication.Src.Contracts.Movements;
using BankApplication.Src.Domain.Accounts;
using BankApplication.Src.Domain.Movements;
using BankApplication.Src.EFCore.Accounts;
using BankApplication.Src.EFCore.Movements;
using BankApplication.Src.Shared.Domain;

namespace BankApplication.Tests.Application
{
    public class MovementAppServiceTests
    {
        private readonly MovementAppService _movementAppService;

        public MovementAppServiceTests()
        {
            var dataSeed = new BankApplicationSeedData();
            var context = dataSeed.Context;

            var accountRepository = new AccountRepository(context);
            var movementRepository = new MovementRepository(context);

            var accountManager = new AccountManager(accountRepository);
            var movementManager = new MovementManager(movementRepository);

            var uow = new UnitOfWork(context, null, accountManager, movementManager);
            _movementAppService = new(uow);
        }

        [Fact]
        public async Task Should_InsertCreditMovement()
        {
            // ARRANGE - ACCOUNT #1
            var movementData = new InsertMovementDto
            {
                Type = MovementConsts.Credit,
                Value = 100,
                AccountId = TestData.IdAccount1
            };

            // ACT
            var result = await _movementAppService.InsertMovement(movementData);

            // ASSERT
            Assert.NotNull(result);
            Assert.True(result.Success);
            Assert.NotNull(result.Result);
            Assert.Equal(200, result.Result.Balance);
            Assert.Equal(TestData.Account1.Number, result.Result.Account);
        }

        [Fact]
        public async Task Should_InsertDebitMovement()
        {
            // ARRANGE - ACCOUNT #2
            var movementData = new InsertMovementDto
            {
                Type = MovementConsts.Debit,
                Value = 55,
                AccountId = TestData.IdAccount2
            };

            // ACT
            var result = await _movementAppService.InsertMovement(movementData);

            // ASSERT
            Assert.NotNull(result);
            Assert.True(result.Success);
            Assert.NotNull(result.Result);
            Assert.Equal(45, result.Result.Balance);
            Assert.Equal(TestData.Account2.Number, result.Result.Account);
        }

        [Fact]
        public async Task Should_ThrownException_When_InsertDebitMovement_TypeMovementNotValid()
        {
            // ARRANGE - ACCOUNT #3
            var movementData = new InsertMovementDto
            {
                Type = "type_not_valid",
                Value = 55,
                AccountId = TestData.IdAccount3
            };

            // ACT
            var result = await _movementAppService.InsertMovement(movementData);

            // ASSERT
            Assert.NotNull(result);
            Assert.False(result.Success);
            Assert.NotNull(result.Error);
            Assert.Equal(MovementConsts.ErrorMovementTypeMovementNotValid.Code, result.Error.Code);
        }

        [Fact]
        public async Task Should_ThrownException_When_InsertDebitMovement_BalanceIsZero()
        {
            // ARRANGE - ACCOUNT #4
            var movementData = new InsertMovementDto
            {
                Type = MovementConsts.Debit,
                Value = 100,
                AccountId = TestData.IdAccount4
            };
            var movementData2 = new InsertMovementDto
            {
                Type = MovementConsts.Debit,
                Value = 0.01,
                AccountId = TestData.IdAccount4
            };

            // ACT
            _ = await _movementAppService.InsertMovement(movementData);
            var result = await _movementAppService.InsertMovement(movementData2);

            // ASSERT
            Assert.NotNull(result);
            Assert.False(result.Success);
            Assert.NotNull(result.Error);
            Assert.Equal(MovementConsts.ErrorMovementBalanceIsZero.Code, result.Error.Code);
        }

        [Fact]
        public async Task Should_ThrownException_When_InsertDebitMovement_InsufficientBalance()
        {
            // ARRANGE - ACCOUNT #5
            var movementData = new InsertMovementDto
            {
                Type = MovementConsts.Debit,
                Value = 99,
                AccountId = TestData.IdAccount5
            };
            var movementData2 = new InsertMovementDto
            {
                Type = MovementConsts.Debit,
                Value = 2,
                AccountId = TestData.IdAccount5
            };

            // ACT
            _ = await _movementAppService.InsertMovement(movementData);
            var result = await _movementAppService.InsertMovement(movementData2);

            // ASSERT
            Assert.NotNull(result);
            Assert.False(result.Success);
            Assert.NotNull(result.Error);
            Assert.Equal(MovementConsts.ErrorMovementInsufficientBalance.Code, result.Error.Code);
        }
    }
}
