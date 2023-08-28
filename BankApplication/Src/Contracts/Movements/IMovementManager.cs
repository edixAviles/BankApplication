using BankApplication.Src.Domain.Movements;

namespace BankApplication.Src.Contracts.Movements
{
    public interface IMovementManager
    {
        Task<Movement> Get(Guid id);
        Task<List<Movement>> GetMovementsByCustomerAndDate(Guid customerId, DateTime startDate, DateTime endDate);
        Task<Movement> Insert(InsertMovementDto movementInsert, double initialBalance, double balance);
    }
}
