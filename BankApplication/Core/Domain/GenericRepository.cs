using BankApplication.Core.Contracts;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace BankApplication.Core.Domain
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseModel
    {
        internal BankApplicationDbContext context;
        internal DbSet<T> dbSet;

        public GenericRepository(BankApplicationDbContext context)
        {
            this.context = context;
            dbSet = context.Set<T>();
        }

        public virtual async Task<T?> GetAsync(Guid id)
        {
            var entity = await dbSet.FindAsync(id);
            return entity;
        }

        public virtual async Task<IEnumerable<T>> GetAsync(Expression<Func<T, bool>>? filter = null, Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null, string includeProperties = "")
        {
            IQueryable<T> query = dbSet;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            foreach (var includeProperty in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }

            if (orderBy != null)
            {
                return await orderBy(query).ToListAsync();
            }
            else
            {
                return await query.ToListAsync();
            }
        }

        public virtual async Task<T> InsertAsync(T entity)
        {
            var createdEntity = await dbSet.AddAsync(entity);
            return createdEntity.Entity;
        }

        public virtual T Update(T entity)
        {
            dbSet.Attach(entity);
            context.Entry(entity).State = EntityState.Modified;
            return entity;
        }

        public virtual void Delete(Guid id)
        {
            var entity = dbSet.Find(id);
            if (entity != null)
            {
                dbSet.Remove(entity);
            }
        }
    }
}
