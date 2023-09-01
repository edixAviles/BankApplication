using BankApplication.Core.Domain;
using BankApplication.Src.Contracts.Movements;
using Microsoft.EntityFrameworkCore;

namespace BankApplication.Src.Domain.Movements
{
    public class MovementRepository : IMovementRepository
    {
        private readonly BankApplicationDbContext _context;

        public MovementRepository(BankApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Movement?> Get(Guid id)
        {
            var entity = await _context.Movements
                .Include(movement => movement.Account)
                .Include(movement => movement.Account.Customer)
                .FirstOrDefaultAsync(movement => movement.Id == id);
            return entity;
        }

        public async Task<List<Movement>> GetMovementsByCustomerAndDate(Guid customerId, DateTime startDate, DateTime endDate)
        {
            var entities = await _context.Movements
                .Include(movement => movement.Account)
                .Include(movement => movement.Account.Customer)
                .Where(movement => movement.Account.CustomerId == customerId && movement.Date.Date >= startDate && movement.Date <= endDate)
                .ToListAsync();
            return entities;
        }

        public async Task<Movement> Insert(Movement entity)
        {
            var createdEntity = await _context.Movements.AddAsync(entity);
            await _context.SaveChangesAsync();

            return createdEntity.Entity;
        }

        public async Task<Movement> Update(Movement entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return entity;
        }

        public async Task Delete(Guid id)
        {
            var entity = await _context.Movements.FindAsync(id);
            if (entity != null)
            {
                _context.Movements.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }
    }
}
