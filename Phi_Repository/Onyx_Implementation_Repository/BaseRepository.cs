using Onyx_Entities_Repository;
using Microsoft.EntityFrameworkCore;

namespace Onyx_Implementation_Repository;

public class BaseRepository<T> where T : Entity
{
    protected readonly DbContext _dbContext;
    protected readonly DbSet<T> _dbSet;

    public BaseRepository(DbContext dbContext)
    {
        _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        _dbSet = _dbContext.Set<T>();
    }
}