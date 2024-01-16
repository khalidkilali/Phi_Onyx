

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using Onyx_Contrat_Repository;
using Onyx_Entities_Repository;
using System.Linq.Expressions;

namespace Onyx_Implementation_Repository;

public class ReadRepositoryGeneric<T> : BaseRepository<T>, IReadRepository<T> where T : Entity
{
    public ReadRepositoryGeneric(DbContext dbContext) : base(dbContext)
    {
    }

    public virtual T GetById(params object[] keyValues) => _dbSet.Find(keyValues);

    public virtual IEnumerable<T> GetAll() => _dbSet;

    public virtual IEnumerable<T> GetAll(Expression<Func<T, bool>>? predicate = null, Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null, Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null, bool disableTracking = true)
    {
        IQueryable<T> query = _dbSet.AsQueryable();

        if (disableTracking) query = query.AsNoTracking();
        if (include != null) query = include(query);
        if (predicate != null) query = query.Where(predicate);
        query = orderBy != null ? orderBy(query) : query;

        return query;
    }

    public T GetFirstOrDefault(Expression<Func<T, bool>>? predicate = null, Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null, Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null, bool disableTracking = true)
    {
        IQueryable<T> query = _dbSet.AsQueryable();

        if (disableTracking) query = query.AsNoTracking();
        if (include != null) query = include(query);
        if (predicate != null) query = query.Where(predicate);
        query = orderBy != null ? orderBy(query) : query;

        return query.FirstOrDefault();
    }

    public int Count(Expression<Func<T, bool>>? predicate = null) =>  predicate != null ? _dbSet.Count(predicate) : _dbSet.Count();


    public bool Exists(Expression<Func<T, bool>> predicate) => _dbSet.Any(predicate);
    
}
