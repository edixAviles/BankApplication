using BankApplication.Core.Response;

namespace BankApplication.Src.Contracts.Movements
{
    public interface IMovementAppService
    {
        Task<Response<MovementDto>> GetMovement(Guid id);
        Task<Response<MovementDto>> InsertMovement(InsertMovementDto movementData);
        Task<Response<IEnumerable<MovementsReportDto>>> GetMovementsByCustomerAndDate(Guid customerId, DateTime startDate, DateTime endDate);
    }
}
