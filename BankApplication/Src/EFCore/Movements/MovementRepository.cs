using BankApplication.Core.Domain;
using BankApplication.Src.Domain.Movements;
using Microsoft.EntityFrameworkCore;

namespace BankApplication.Src.EFCore.Movements
{
    public class MovementRepository : GenericRepository<Movement>, IMovementRepository
    {
        public MovementRepository(BankApplicationDbContext context) : base(context)
        {
        }

        public override async Task<Movement?> GetAsync(Guid id)
        {
            var entity = await dbSet
                .Include(movement => movement.Account)
                .Include(movement => movement.Account.Customer)
                .FirstOrDefaultAsync(movement => movement.Id == id);
            return entity;
        }

        public async Task<IEnumerable<Movement>> GetMovementsByCustomerAndDateAsync(Guid customerId, DateTime startDate, DateTime endDate)
        {
            var entities = await dbSet
                .Include(movement => movement.Account)
                .Include(movement => movement.Account.Customer)
                .Where(movement => movement.Account.CustomerId == customerId && movement.Date.Date >= startDate && movement.Date <= endDate)
                .ToListAsync();
            return entities;
        }
    }
}
