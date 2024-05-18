using KT.Application.Common.Interfaces.Persistence;
using KT.Domain.ModuleTemplateAggregate;
using Microsoft.EntityFrameworkCore;

namespace KT.Infrastructure.Persistence.Repositories;

public class ModuleTemplateRepository : IModuleTemplateRepository
{
    private readonly KtDbContext _dbContext;

    public ModuleTemplateRepository(KtDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<ModuleTemplate> AddAsync(ModuleTemplate entity)
    {
        var moduleTemplate = (await _dbContext.ModuleTemplates.AddAsync(entity)).Entity;
        await _dbContext.SaveChangesAsync();
        return moduleTemplate;
    }

    public async Task<int> RemoveAsync(Guid id)
    {
        var moduleTemplate = await _dbContext.ModuleTemplates.FindAsync(id);
        if (moduleTemplate is null) return 0;

        _dbContext.ModuleTemplates.Remove(moduleTemplate);
        return await _dbContext.SaveChangesAsync();
    }

    public async Task<ModuleTemplate?> GetByIdAsync(Guid id)
    {
        return await _dbContext.ModuleTemplates.FindAsync(id);
    }
    
    public async Task<IList<ModuleTemplate>> GetByIdsAsync(IList<Guid> ids)
    {
        return await _dbContext.ModuleTemplates.Where(x => ids.Contains(x.Id)).ToListAsync();
    }

    public async Task<IList<ModuleTemplate>> ListAsync()
    {
        return await _dbContext.ModuleTemplates.ToListAsync();
    }

    public async Task UpdateAsync(ModuleTemplate entity)
    {
        _dbContext.ModuleTemplates.Update(entity);
        await _dbContext.SaveChangesAsync();
    }
}