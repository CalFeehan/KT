using ErrorOr;
using KT.Domain.CourseTemplateAggregate;
using MediatR;

namespace KT.Application.CourseTemplates.Queries;

public record GetByIdQuery(Guid Id) : IRequest<ErrorOr<CourseTemplate>>;