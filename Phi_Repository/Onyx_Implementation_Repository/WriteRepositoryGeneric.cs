using Microsoft.EntityFrameworkCore;
using Onyx_Contrat_Repository;
using Onyx_Entities_Repository;

namespace Onyx_Implementation_Repository;

public class WriteRepositoryGeneric<T> : BaseRepository<T>, IWriteRepository<T> where T : Entity
{
    public WriteRepositoryGeneric(DbContext dbContext) : base(dbContext)
    {
    }

    public virtual void Add(T entity) => _dbSet.Add(entity);


    public virtual void Add(IEnumerable<T> entities) => _dbSet.AddRange(entities);


    public virtual void Delete(object id)
    {
        var entityToDelete = _dbSet.Find(id);
        if (entityToDelete != null)
        {
            _dbSet.Remove(entityToDelete);
        }
    }

    public virtual void Delete(T entityToDelete)
    {
        if (_dbContext.Entry(entityToDelete).State == EntityState.Detached)
            _ = _dbSet.Attach(entityToDelete);
        _ = _dbSet.Remove(entityToDelete);
    }

    public virtual void Delete(IEnumerable<T> entities) => _dbSet.RemoveRange(entities);

    public virtual void Update(T entity) => _dbSet.Update(entity);

    public virtual void Update(IEnumerable<T> entities) => _dbSet.UpdateRange(entities);
}
