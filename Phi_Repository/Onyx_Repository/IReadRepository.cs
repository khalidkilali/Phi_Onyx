using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Onyx_Contrat_Repository;

/// <summary>
/// Generic interface, can implemented by classes to read data
/// </summary>
/// <typeparam name="T"></typeparam>
public interface IReadRepository<T> where T : class
{
    /// <summary>
    /// Get an entity with the given primary key values
    /// </summary>
    /// <param name="keyValues">The value of the primary key.</param>
    /// <returns>The found entity or null</returns>
    T GetById(params object[] keyValues);

    /// <summary>
    /// Gets the first or default entity based on a predicate, orderby, and included children
    /// </summary>
    /// <param name="predicate">A function to test each elements for a condition</param>
    /// <param name="orderBy">A function to order elements</param>
    /// <param name="include">Navigation properties separated by a comma</param>
    /// <param name="disableTracking">Disable entities changing tracking</param>
    /// <returns>The first element satisfying the condiftion.</returns>
    T GetFirstOrDefault(
        Expression<Func<T, bool>>? predicate = null,
        Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null,
        Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null,
        bool disableTracking = true
        );

    /// <summary>
    /// Gets all entities
    /// </summary>
    /// <returns>All entity data</returns>
    IEnumerable<T> GetAll();

    /// <summary>
    /// Gets the entities based on a predicate, orderby, and included children
    /// </summary>
    /// <param name="predicate">A function to test each elements for a condition</param>
    /// <param name="orderBy">A function to order elements</param>
    /// <param name="include">Navigation properties separated by a comma</param>
    /// <param name="disableTracking">Disable entities changing tracking</param>
    /// <returns>The first element satisfying the condiftion.</returns>
    IEnumerable<T> GetAll(
        Expression<Func<T, bool>>? predicate = null,
        Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null,
        Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null,
        bool disableTracking = true
        );

    /// <summary>
    /// Gets the count based on a predicate.
    /// </summary>
    /// <param name="predicate">A function to test each element for a condition.</param>
    /// <returns>The number of rows.</returns>
    int Count(Expression<Func<T, bool>>? predicate = null);

    /// <summary>
    /// Check if an element exists for a condition.
    /// </summary>
    /// <param name="predicate">A function to test each element for a condition.</param>
    /// <returns>A boolean</returns>
    bool Exists(Expression<Func<T, bool>> predicate);
}