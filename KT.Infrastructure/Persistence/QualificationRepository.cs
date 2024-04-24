using KT.Application.Common.Interfaces.Persistence;
using KT.Domain.Qualification;

namespace KT.Infrastructure.Persistence;

public class QualificationRepository : Repository<Qualification>, IQualificationRepository
{
}