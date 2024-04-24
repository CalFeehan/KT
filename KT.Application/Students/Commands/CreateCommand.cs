using ErrorOr;
using KT.Domain.Student;
using MediatR;

namespace KT.Application.Students.Commands;

public record CreateCommand(string Forename, string Surname, DateOnly DateOfBirth) 
    : IRequest<ErrorOr<Student>>;
