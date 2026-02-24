using FOODBANK.Data.Context;
using Microsoft.EntityFrameworkCore;


namespace FOODBANK.Data.Repositories;

public abstract class RepositoryBase<T> where T : class
{
    protected readonly FoodbankDbContext _context;
    protected readonly DbSet<T> _dbSet;

    protected RepositoryBase(FoodbankDbContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
        _dbSet = _context.Set<T>();
    }

    public virtual async Task<bool> UpsertAsync(T entity, bool isUpdating)
    {
        if (entity == null) throw new ArgumentNullException(nameof(entity));
        return isUpdating ? await UpdateAsync(entity) : await CreateAsync(entity);
    }

    public virtual async Task<bool> CreateAsync(T entity)
    {
        if (entity == null) throw new ArgumentNullException(nameof(entity));
        await _dbSet.AddAsync(entity);
        return await SaveAsync();
    }

    public virtual async Task<IEnumerable<T>> ReadAsync()
    {
        return await _dbSet.AsNoTracking().ToListAsync();
    }

    public virtual async Task<T?> FindAsync(int id)
    {
        var found = await _dbSet.FindAsync(id);
        return found is null ? null : found;
    }

    public virtual async Task<bool> UpdateAsync(T entity)
    {
        if (entity == null) throw new ArgumentNullException(nameof(entity));
        _dbSet.Update(entity);
        return await SaveAsync();
    }

    public virtual async Task<bool> UpdateManyAsync(IEnumerable<T> entities)
    {
        if (entities == null) throw new ArgumentNullException(nameof(entities));
        _dbSet.UpdateRange(entities);
        return await SaveAsync();
    }

    public virtual async Task<bool> DeleteAsync(T entity)
    {
        if (entity == null) throw new ArgumentNullException(nameof(entity));
        _dbSet.Remove(entity);
        return await SaveAsync();
    }

    public virtual async Task<bool> ExistsAsync(T entity)
    {
        try
        {
            var items = await ReadAsync();
            return items.Any(x => x.Equals(entity));
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    protected async Task<bool> SaveAsync()
    {
        return await _context.SaveChangesAsync() > 0;
    }
}
