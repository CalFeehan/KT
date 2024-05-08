namespace KT.Application.Common.Interfaces.Persistence;

public interface IRepository<T> where T : class
{
    /// <summary>
    /// Adds the entity to the database.
    /// </summary>
    Task<T> AddAsync(T entity);

    /// <summary>
    /// Get the entity by id.
    /// </summary>
    Task<T?> GetByIdAsync(Guid id);

    /// <summary>
    /// List all entities.
    /// </summary>
    Task<IList<T>> ListAsync();

    /// <summary>
    /// Remove an entity by id. Returns number of records effected.
    /// </summary>
    Task<int> RemoveAsync(Guid id);

    /// <summary>
    /// Update an entity.
    /// </summary>
    Task UpdateAsync(T entity);
}