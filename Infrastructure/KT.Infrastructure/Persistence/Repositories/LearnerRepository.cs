using KT.Application.Common.Interfaces.Persistence;
using KT.Domain.LearnerAggregate;
using Microsoft.EntityFrameworkCore;

namespace KT.Infrastructure.Persistence.Repositories;

public class LearnerRepository(KTDbContext dbContext) : ILearnerRepository
{
    private readonly KTDbContext _dbContext = dbContext;

    public async Task<Learner> CreateAsync(Learner entity)
    {
        var learner = (await _dbContext.Learners.AddAsync(entity)).Entity;
        await _dbContext.SaveChangesAsync();
        return learner;
    }

    public async Task<int> DeleteAsync(Guid id)
    {
        var learner = await _dbContext.Learners.FindAsync(id);
        if (learner is null)
        {
            return 0;
        }

        _dbContext.Learners.Remove(learner);
        return await _dbContext.SaveChangesAsync();
    }

    public async Task<Learner?> GetByIdAsync(Guid id)
    {
        return await _dbContext.Learners.FindAsync(id);
    }

    public async Task<IList<Learner>> ListAsync()
    {
        return await _dbContext.Learners.ToListAsync();
    }

    public async Task UpdateAsync(Learner entity)
    {
        _dbContext.Learners.Update(entity);
        await _dbContext.SaveChangesAsync();
    }
}