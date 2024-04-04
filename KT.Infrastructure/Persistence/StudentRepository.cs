using KT.Application.Common.Interfaces.Persistence;
using KT.Domain.Aggregates;

namespace KT.Infrastructure.Persistence;

public class StudentRepository : IStudentRepository
{
    private readonly List<Student> _students = new()
    {
        new Student("Joe", "Bloggs"),
        new Student("Jane", "Doe")
    };
    
    /// <inheritdoc />
    public async Task AddAsync(Student entity)
    {
        _students.Add(entity);
    }

    /// <inheritdoc />
    public async Task<Student> GetByIdAsync(Guid id)
    {
        return _students.FirstOrDefault(x => x.Id == id);
    }

    /// <inheritdoc />
    public async Task<IList<Student>> ListAsync()
    {
        return _students;
    }

    /// <inheritdoc />
    public async Task<int> DeleteAsync(Guid id)
    {
        var student = _students.FirstOrDefault(x => x.Id == id);
        if (student is null) return 0;

        _students.Remove(student);
        return 1;
    }

    /// <inheritdoc />
    public async Task UpdateAsync(Student entity)
    {
        var student = _students.FirstOrDefault(x => x.Id == entity.Id);
        if (student is null) return;
        
        // TODO: Temp implementation.
        _students.Remove(student);
        _students.Add(entity);
    }
}