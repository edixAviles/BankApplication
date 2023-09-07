using BankApplication.Src.Domain.Movements;

namespace BankApplication.Src.Contracts.Movements
{
    public interface IMovementManager
    {
        Task<Movement> GetAsync(Guid id);
        Task<IEnumerable<Movement>> GetMovementsByCustomerAndDateAsync(Guid customerId, DateTime startDate, DateTime endDate);
        Task<Movement> InsertAsync(InsertMovementDto movementInsert, double initialBalance, double balance);
    }
}
