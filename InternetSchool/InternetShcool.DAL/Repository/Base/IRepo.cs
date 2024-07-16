using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternetShcool.DAL.Repository.Base;

public interface IRepo<TEntity, in TKEy>
        where TEntity : class
        where TKEy : IEquatable<TKEy>
{
    Task<List<TEntity>> GetAllAsync();
    Task<TEntity?> GetAsync(int id);
    Task<TEntity> AddAsync(TEntity entity);
    Task<bool> AddManyAsync(IEnumerable<TEntity> entities);
    Task<TEntity> UpdateAsync(TEntity entity);
    Task<bool> UpdateManyAsync(IEnumerable<TEntity> entities);
    Task<bool> DeleteAsync(TEntity entity);
    Task<bool> DeleteManyAsync(IEnumerable<TEntity> entities);
    Task<int> SaveChangesAsync();
    int SaveChanges();
}
