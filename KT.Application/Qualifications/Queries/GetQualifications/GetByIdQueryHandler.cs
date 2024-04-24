using ErrorOr;
using KT.Application.Common.Interfaces.Persistence;
using KT.Domain.Common.Errors;
using KT.Domain.Qualification;
using MediatR;

namespace KT.Application.Qualifications.Queries.GetQualifications;

public class GetByIdQueryHandler(IQualificationRepository qualificationRepository)
    : IRequestHandler<GetByIdQuery, ErrorOr<Qualification>>
{
    public async Task<ErrorOr<Qualification>> Handle(GetByIdQuery query, CancellationToken cancellationToken)
    {
        var qualification = await qualificationRepository.GetByIdAsync(query.Id);

        if (qualification is null)
        {
            return Errors.Qualification.NotFound;
        }

        return qualification;
    }
}