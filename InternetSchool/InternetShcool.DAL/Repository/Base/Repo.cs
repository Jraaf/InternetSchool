using InternetShcool.DAL.EF;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace InternetShcool.DAL.Repository.Base;

public class Repo<TEntity, TKey> : IRepo<TEntity, TKey>
       where TEntity : class
       where TKey : IEquatable<TKey>
{
    private readonly DbSet<TEntity> _table;
    private readonly InternetSchoolDBContext _context;
    public Repo(InternetSchoolDBContext context)
    {
        _context = context;
        _table = context.Set<TEntity>();
    }
    public Type ElementType => ((IQueryable<TEntity>)_table).ElementType;

    public Expression Expression => ((IQueryable<TEntity>)_table).Expression;

    public IQueryProvider Provider => ((IQueryable<TEntity>)_table).Provider;

    public async Task<TEntity> AddAsync(TEntity entity)
    {
        var data = await _table.AddAsync(entity);
        await SaveChangesAsync();
        return data.Entity;
    }

    public async Task<TEntity?> FindAsync(TKey key)
    {
        return await _table.FindAsync(key);
    }

    public async Task<bool> AddManyAsync(IEnumerable<TEntity> entities)
    {
        await _table.AddRangeAsync(entities);
        return SaveChanges() > 0;
    }

    public async Task<bool> DeleteAsync(TEntity entity)
    {
        _table.Remove(entity);
        return await SaveChangesAsync() > 0;
    }

    public async Task<bool> DeleteManyAsync(IEnumerable<TEntity> entities)
    {
        _table.RemoveRange(entities);
        return await SaveChangesAsync() > 0;
    }

    public async Task<List<TEntity>> GetAllAsync()
    {
        return await _table.ToListAsync();
    }

    public async Task<TEntity?> GetAsync(int id)
    {
        return await _table.FindAsync(id);
    }

    public IAsyncEnumerator<TEntity> GetAsyncEnumerator(CancellationToken cancellationToken = default)
    {
        return ((IAsyncEnumerable<TEntity>)_table).GetAsyncEnumerator(cancellationToken);
    }

    public IEnumerator<TEntity> GetEnumerator()
    {
        return ((IEnumerable<TEntity>)_table).GetEnumerator();
    }

    public int SaveChanges()
    {
        return _context.SaveChanges();
    }

    public async Task<int> SaveChangesAsync()
    {
        return await _context.SaveChangesAsync();
    }

    public async Task<TEntity> UpdateAsync(TEntity entity)
    {
        var data = _table.Update(entity);
        await _context.SaveChangesAsync();
        return data.Entity;
    }

    public async Task<bool> UpdateManyAsync(IEnumerable<TEntity> entities)
    {
        _table.UpdateRange(entities);
        return await _context.SaveChangesAsync() > 0;
    }
}
