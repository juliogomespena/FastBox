using System.Linq.Expressions;

namespace FastBox.DAL.Repositories;

public interface IRepository<T> where T : class
{
    IQueryable<T> Query();
    Task<IEnumerable<T>> GetAllAsync(bool asNoTracking = false);
    Task<T?> GetByIdWithIncludesAsync(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includes);
    Task<T?> GetByIdAsync(long id);
    Task<T?> FirstOrDefaultAsync(Expression<Func<T, bool>> predicate);
    Task AddAsync(T entity);
    Task DeleteAsync(T entity);
    Task UpdateAsync(T entity);
    Task<bool> AnyAsync(Expression<Func<T, bool>> predicate);
    void DetachEntity(T entity);
}
