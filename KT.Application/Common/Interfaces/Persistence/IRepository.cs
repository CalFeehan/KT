namespace KT.Application.Common.Interfaces.Persistence;

public interface IRepository<T> where T : class
{
    /// <summary>
    /// Add the entity to the database.
    /// </summary>
    Task AddAsync(T entity);

    /// <summary>
    /// Get the entity by id.
    /// </summary>
    Task<T?> GetByIdAsync(Guid id);

    /// <summary>
    /// List all entities.
    /// </summary>
    Task<IList<T>> ListAsync();

    /// <summary>
    /// Delete an entity by id. Returns number of records effected.
    /// </summary>
    Task<int> DeleteAsync(Guid id);

    /// <summary>
    /// Update an entity.
    /// </summary>
    Task UpdateAsync(T entity);
}