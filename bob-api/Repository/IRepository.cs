using System.Linq.Expressions;

namespace bob_api.Repository
{
    public interface IRepository<T>
    {
        Task<IEnumerable<T>> Get();
        Task<T> GetById(object id);
        Task<T> Create(T entity);
        Task<ICollection<T>> CreateMultiple(ICollection<T> entities);
        Task<T> Update(T entity);
        Task<T> Delete(T entity);

        IQueryable<T> GetByCondition(Expression<Func<T, bool>> expression);
    }
}
