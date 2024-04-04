using KT.Application.Common.Interfaces.Persistence;
using KT.Domain.Aggregates;

namespace KT.Infrastructure.Persistence;

public class CourseRepository : ICourseRepository
{
    private readonly List<Course> _courses = [];
    
    /// <inheritdoc />
    public async Task AddAsync(Course entity)
    {
        _courses.Add(entity);
    }

    /// <inheritdoc />
    public async Task<Course> GetByIdAsync(Guid id)
    {
        return _courses.FirstOrDefault(x => x.Id == id);
    }

    /// <inheritdoc />
    public async Task<IList<Course>> ListAsync()
    {
        return _courses;
    }

    /// <inheritdoc />
    public async Task DeleteAsync(Guid id)
    {
        var student = _courses.FirstOrDefault(x => x.Id == id);
        if (student is not null)
        {
            _courses.Remove(student);
        }
    }

    /// <inheritdoc />
    public async Task UpdateAsync(Course entity)
    {
        var student = _courses.FirstOrDefault(x => x.Id == entity.Id);
        if (student is not null)
        {
            _courses.Remove(student);
        }
        
        _courses.Add(entity);
    }
}