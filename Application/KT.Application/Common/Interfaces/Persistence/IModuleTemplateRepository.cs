using KT.Domain.ModuleTemplateAggregate;

namespace KT.Application.Common.Interfaces.Persistence;

public interface IModuleTemplateRepository : IRepository<ModuleTemplate>
{
    Task<IList<ModuleTemplate>> GetByIdsAsync(IList<Guid> ids);
}