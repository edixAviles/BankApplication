using BankApplication.Core.Response;
using BankApplication.Src.Contracts.Movements;
using Microsoft.AspNetCore.Mvc;

namespace BankApplication.Src.Controllers.Movements
{
    [Route("api/movimientos")]
    [ApiController]
    public class MovementController : ControllerBase, IMovementAppService
    {
        private readonly IMovementAppService _movementAppService;

        public MovementController(IMovementAppService movementAppService)
        {
            _movementAppService = movementAppService;
        }

        [HttpGet("{id}")]
        public async Task<Response<MovementDto>> GetMovement(Guid id)
        {
            return await _movementAppService.GetMovement(id);
        }

        [HttpGet("reportes")]
        public async Task<Response<IEnumerable<MovementsReportDto>>> GetMovementsByCustomerAndDate(Guid customerId, DateTime startDate, DateTime endDate)
        {
            return await _movementAppService.GetMovementsByCustomerAndDate(customerId, startDate, endDate);
        }

        [HttpPost]
        public async Task<Response<MovementDto>> InsertMovement(InsertMovementDto movementData)
        {
            return await _movementAppService.InsertMovement(movementData);
        }
    }
}
