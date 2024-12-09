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

    public async Task<IEnumerable<T>> GetAllAsync()
    {
        return await _dbSet.ToListAsync();
    }

    public async Task<T> GetByIdAsync(long id)
    {
        return await _dbSet.FindAsync(id);
    }

    public async Task UpdateAsync(T entity)
    {
        _dbSet.Update(entity);
        await _context.SaveChangesAsync();
    }

    public async Task<T?> FirstOrDefaultAsync(Expression<Func<T, bool>> predicate)
    {
        return await _dbSet.FirstOrDefaultAsync(predicate);
    }

    public async Task<bool> AnyAsync(Expression<Func<T, bool>> predicate)
    {
        return await _dbSet.AnyAsync(predicate);
    }

    public IQueryable<T> Query()
    {
        return _dbSet.AsQueryable();
    }

}
