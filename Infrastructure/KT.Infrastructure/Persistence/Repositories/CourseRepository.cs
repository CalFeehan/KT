using KT.Application.Common.Interfaces.Persistence;
using KT.Domain.CourseAggregate;
using Microsoft.EntityFrameworkCore;

namespace KT.Infrastructure.Persistence.Repositories;

public class CourseRepository : ICourseRepository
{
    private readonly KTDbContext _dbContext;

    public CourseRepository(KTDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Course> AddAsync(Course entity)
    {
        var course = (await _dbContext.Courses.AddAsync(entity)).Entity;
        await _dbContext.SaveChangesAsync();
        return course;
    }

    public async Task<int> RemoveAsync(Guid id)
    {
        var course = await _dbContext.Courses.FindAsync(id);
        if (course is null)
        {
            return 0;
        }

        _dbContext.Courses.Remove(course);
        return await _dbContext.SaveChangesAsync();
    }

    public async Task<Course?> GetByIdAsync(Guid id)
    {
        return await _dbContext.Courses.FindAsync(id);
    }

    public async Task<IList<Course>> ListAsync()
    {
        return await _dbContext.Courses.ToListAsync();
    }

    public async Task UpdateAsync(Course entity)
    {
        _dbContext.Courses.Update(entity);
        await _dbContext.SaveChangesAsync();
    }
}
