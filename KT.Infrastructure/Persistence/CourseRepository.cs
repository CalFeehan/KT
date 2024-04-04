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
    public async Task<int> DeleteAsync(Guid id)
    {
        var student = _courses.FirstOrDefault(x => x.Id == id);
        if (student is null) return 0;

        _courses.Remove(student);
        return 1;
    }

    /// <inheritdoc />
    public async Task UpdateAsync(Course entity)
    {
        var student = _courses.FirstOrDefault(x => x.Id == entity.Id);
        if (student is null) return;

        // TODO: Temp implementation.
        _courses.Remove(student);
        _courses.Add(entity);
    }
}