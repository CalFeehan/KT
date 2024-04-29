using ErrorOr;
using KT.Domain.StudentAggregate;
using MediatR;

namespace KT.Application.Students.Commands;

public record CreateCommand(string Forename, string Surname, DateOnly DateOfBirth) 
    : IRequest<ErrorOr<Student>>;
