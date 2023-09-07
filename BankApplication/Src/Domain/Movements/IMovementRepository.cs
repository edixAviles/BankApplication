using BankApplication.Core.Contracts;

namespace BankApplication.Src.Domain.Movements
{
    public interface IMovementRepository : IGenericRepository<Movement>
    {
        Task<IEnumerable<Movement>> GetMovementsByCustomerAndDateAsync(Guid customerId, DateTime startDate, DateTime endDate);
    }
}
