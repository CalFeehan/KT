using KT.Application.Common.Interfaces.Persistence;
using KT.Domain.CourseTemplateAggregate;
using Microsoft.EntityFrameworkCore;

namespace KT.Infrastructure.Persistence.Repositories;

public class CourseTemplateRepository : ICourseTemplateRepository
{
    private readonly KTDbContext _dbContext;

    public CourseTemplateRepository(KTDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<CourseTemplate> AddAsync(CourseTemplate entity)
    {
        var courseTemplate = (await _dbContext.CourseTemplates.AddAsync(entity)).Entity;
        await _dbContext.SaveChangesAsync();
        return courseTemplate;
    }

    public async Task<int> RemoveAsync(Guid id)
    {
        var courseTemplate = await _dbContext.CourseTemplates.FindAsync(id);
        if (courseTemplate is null)
        {
            return 0;
        }

        _dbContext.CourseTemplates.Remove(courseTemplate);
        return await _dbContext.SaveChangesAsync();
    }

    public async Task<CourseTemplate?> GetByIdAsync(Guid id)
    {
        return await _dbContext.CourseTemplates.FindAsync(id);
    }

    public async Task<IList<CourseTemplate>> ListAsync()
    {
        return await _dbContext.CourseTemplates.ToListAsync();
    }

    public async Task UpdateAsync(CourseTemplate entity)
    {
        _dbContext.CourseTemplates.Update(entity);
        await _dbContext.SaveChangesAsync();
    }
}