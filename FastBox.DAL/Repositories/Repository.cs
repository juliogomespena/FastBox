using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace FastBox.DAL.Repositories;

public class Repository<T>: IRepository<T> where T : class
{
    private readonly FastBoxDbContext _context;
    private readonly DbSet<T> _dbSet;

    public Repository(FastBoxDbContext context)
    {
        _context = context;
        _dbSet = _context.Set<T>();
        
    }
    public IQueryable<T> Query()
    {
        return _dbSet.AsQueryable();
    }

    public async Task<IEnumerable<T>> GetAllAsync(bool asNoTracking = false)
    {
        var query = asNoTracking ? _dbSet.AsNoTracking() : _dbSet;
        return await query.ToListAsync();
    }

    public async Task<T?> GetByIdWithIncludesAsync( Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includes)
    {
        IQueryable<T> query = _dbSet;

        foreach (var include in includes)
        {
            query = query.Include(include);
        }

        return await query.FirstOrDefaultAsync(predicate);
    }

    public async Task<T?> GetByIdAsync(long id)
    {
        return await _dbSet.FindAsync(id);
    }

    public async Task<T?> FirstOrDefaultAsync(Expression<Func<T, bool>> predicate)
    {
        return await _dbSet.FirstOrDefaultAsync(predicate);
    }

    public async Task AddAsync(T entity)
    {
        await _dbSet.AddAsync(entity);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(T entity)
    {
        if(entity != null)
        { 
            _dbSet.Remove(entity);
            await _context.SaveChangesAsync();
        }
    }

    public async Task UpdateAsync(T entity)
    {
        _dbSet.Update(entity);
        await _context.SaveChangesAsync();
    }

    public async Task<bool> AnyAsync(Expression<Func<T, bool>> predicate)
    {
        return await _dbSet.AnyAsync(predicate);
    }

    public void DetachEntity(T entity)
    {
        var entry = _context.Entry(entity);
        if (entry != null)
        {
            entry.State = EntityState.Detached;
        }
    }

    public void RemoveEntity(T entity)
    {
        _context.Set<T>().Remove(entity);
    }
}
