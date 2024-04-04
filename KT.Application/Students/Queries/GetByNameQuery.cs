using KT.Domain.Aggregates;
using MediatR;

namespace KT.Application.Students.Queries;

public record GetByNameQuery(string Forename, string Surname)
    : IRequest<Student>;