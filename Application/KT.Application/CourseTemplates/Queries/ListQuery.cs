using KT.Domain.CourseTemplateAggregate;
using MediatR;

namespace KT.Application.CourseTemplates.Queries;

public record ListQuery() : IRequest<IList<CourseTemplate>>;