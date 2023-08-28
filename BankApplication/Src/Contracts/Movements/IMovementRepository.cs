using BankApplication.Core.Domain;
using BankApplication.Src.Domain.Movements;

namespace BankApplication.Src.Contracts.Movements
{
    public interface IMovementRepository : IBaseRepository<Movement>
    {
        Task<List<Movement>> GetMovementsByCustomerAndDate(Guid customerId, DateTime startDate, DateTime endDate);
    }
}
