using System.Linq.Expressions;

namespace BankApplication.Core.Contracts
{
    public interface IGenericRepository<T>
    {
        Task<T?> GetAsync(Guid id);
        Task<IEnumerable<T>> GetAsync(Expression<Func<T, bool>>? filter = null, Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null, string includeProperties = "");
        Task<T> InsertAsync(T entity);
        T Update(T entity);
        void Delete(Guid id);
    }
}
