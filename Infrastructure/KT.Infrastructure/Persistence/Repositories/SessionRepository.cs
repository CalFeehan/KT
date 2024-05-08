using KT.Application.Common.Interfaces.Persistence;
using KT.Domain.SessionAggregate;
using Microsoft.EntityFrameworkCore;

namespace KT.Infrastructure.Persistence.Repositories;

public class SessionRepository : ISessionRepository
{
    private readonly KTDbContext _dbContext;

    public SessionRepository(KTDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Session> AddAsync(Session entity)
    {
        var session = (await _dbContext.Sessions.AddAsync(entity)).Entity;
        await _dbContext.SaveChangesAsync();
        return session;
    }

    public async Task<int> RemoveAsync(Guid id)
    {
        var session = await _dbContext.Sessions.FindAsync(id);
        if (session is null)
        {
            return 0;
        }

        _dbContext.Sessions.Remove(session);
        return await _dbContext.SaveChangesAsync();
    }

    public async Task<Session?> GetByIdAsync(Guid id)
    {
        return await _dbContext.Sessions.FindAsync(id);
    }

    public async Task<IList<Session>> ListAsync()
    {
        return await _dbContext.Sessions.ToListAsync();
    }

    public async Task UpdateAsync(Session entity)
    {
        _dbContext.Sessions.Update(entity);
        await _dbContext.SaveChangesAsync();
    }
}