using KT.Application.Common.Interfaces.Persistence;
using KT.Domain.Common.Models;

namespace KT.Infrastructure.Persistence;

public class Repository<T>() : IRepository<T> where T : Entity<Guid>
{
    private readonly List<T> _entities = [];

    public async Task<T> CreateAsync(T entity)
    {
        await Task.CompletedTask;

        _entities.Add(entity);

        return entity;
    }

    public async Task<T?> GetByIdAsync(Guid id)
    {
        await Task.CompletedTask;

        return _entities.FirstOrDefault(x => x.Id == id);
    }

    public async Task<IList<T>> ListAsync()
    {
        await Task.CompletedTask;

        return _entities;
    }

    public async Task<int> DeleteAsync(Guid id)
    {
        await Task.CompletedTask;

        var entity = _entities.FirstOrDefault(x => x.Id == id);
        if (entity is null) return 0;

        _entities.Remove(entity);
        return 1;
    }

    public async Task UpdateAsync(T model)
    {
        await Task.CompletedTask;

        var entity = _entities.FirstOrDefault(x => x.Id == model.Id);
        if (entity is null) return;
    }
}