namespace BankApplication.Core.Domain
{
    public interface IBaseRepository<T> where T : BaseModel
    {
        Task<T?> Get(Guid id);
        Task<T> Insert(T entity);
        Task<T> Update(T entity);
        Task Delete(Guid id);
    }
}
