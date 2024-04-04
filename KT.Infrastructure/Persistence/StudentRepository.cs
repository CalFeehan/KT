using KT.Application.Common.Interfaces.Persistence;
using KT.Domain.Aggregates;

namespace KT.Infrastructure.Persistence;

public class StudentRepository : IStudentRepository
{
    private readonly List<Student> _students = GenerateDummyData();

    /// <inheritdoc />
    public async Task AddAsync(Student entity)
    {
        await Task.Delay(10);
        
        _students.Add(entity);
    }

    /// <inheritdoc />
    public async Task<Student?> GetByIdAsync(Guid id)
    {
        await Task.Delay(10);
        
        return _students.FirstOrDefault(x => x.Id == id);
    }

    /// <inheritdoc />
    public async Task<IList<Student>> ListAsync()
    {
        await Task.Delay(10);
        
        return _students;
    }

    /// <inheritdoc />
    public async Task<int> DeleteAsync(Guid id)
    {
        await Task.Delay(10);
        
        var student = _students.FirstOrDefault(x => x.Id == id);
        if (student is null) return 0;

        _students.Remove(student);
        return 1;
    }

    /// <inheritdoc />
    public async Task UpdateAsync(Student entity)
    {
        await Task.Delay(10);
        
        var student = _students.FirstOrDefault(x => x.Id == entity.Id);
        if (student is null) return;
        
        // TODO: Temp implementation.
        _students.Remove(student);
        _students.Add(entity);
    }
    
    
    private static List<Student> GenerateDummyData()
    {
        return
        [
            new Student("Joe", "Bloggs")
            {
                Id = Guid.Parse("2bf954eb-b3e7-4e53-b535-4ecedee53d7e")
            },

            new Student("Jane", "Doe")
            {
                Id = Guid.Parse("81946009-8467-45e6-ac5f-1fd90e7d1d67")
            }
        ];
    }
}