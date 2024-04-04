using ErrorOr;
using KT.Domain.Aggregates;
using MediatR;

namespace KT.Application.Students.Commands;

public record CreateCommand(string Forename, string Surname) 
    : IRequest<ErrorOr<Student>>;
