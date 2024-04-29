using KT.Application.Common.Interfaces.Persistence;
using KT.Domain.StudentAggregate;
using Microsoft.EntityFrameworkCore;

namespace KT.Infrastructure.Persistence.Repositories;

public class StudentRepository(KTDbContext dbContext) : IStudentRepository
{
    private readonly KTDbContext _dbContext = dbContext;

    public async Task<Student> CreateAsync(Student entity)
    {
        var student = (await _dbContext.Students.AddAsync(entity)).Entity;
        await _dbContext.SaveChangesAsync();
        return student;
    }

    public async Task<int> DeleteAsync(Guid id)
    {
        var student = await _dbContext.Students.FindAsync(id);
        if (student is null)
        {
            return 0;
        }

        _dbContext.Students.Remove(student);
        return await _dbContext.SaveChangesAsync();
    }

    public async Task<Student?> GetByIdAsync(Guid id)
    {
        return await _dbContext.Students.FindAsync(id);
    }

    public async Task<IList<Student>> ListAsync()
    {
        return await _dbContext.Students.ToListAsync();
    }

    public async Task UpdateAsync(Student entity)
    {
        _dbContext.Students.Update(entity);
        await _dbContext.SaveChangesAsync();
    }
}