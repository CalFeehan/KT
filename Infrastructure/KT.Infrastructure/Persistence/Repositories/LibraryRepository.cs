using KT.Application.Common.Interfaces.Persistence;
using KT.Domain.LibraryAggregate;
using Microsoft.EntityFrameworkCore;

namespace KT.Infrastructure.Persistence.Repositories;

public class LibraryRepository : ILibraryRepository
{
    private readonly KTDbContext _dbContext;

    public LibraryRepository(KTDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Library> CreateAsync(Library entity)
    {
        var library = (await _dbContext.Libraries.AddAsync(entity)).Entity;
        await _dbContext.SaveChangesAsync();
        return library;
    }

    public async Task<int> DeleteAsync(Guid id)
    {
        var library = await _dbContext.Libraries.FindAsync(id);
        if (library is null)
        {
            return 0;
        }

        _dbContext.Libraries.Remove(library);
        return await _dbContext.SaveChangesAsync();
    }

    public async Task<Library?> GetByIdAsync(Guid id)
    {
        return await _dbContext.Libraries.FindAsync(id);
    }

    public async Task<IList<Library>> ListAsync()
    {
        return await _dbContext.Libraries.ToListAsync();
    }

    public async Task UpdateAsync(Library entity)
    {
        _dbContext.Libraries.Update(entity);
        await _dbContext.SaveChangesAsync();
    }
}