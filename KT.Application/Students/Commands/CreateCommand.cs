using ErrorOr;
using KT.Domain.Common.ValueObjects;
using KT.Domain.StudentAggregate;
using MediatR;

namespace KT.Application.Students.Commands;

public record CreateCommand(string Forename, string Surname, DateOnly DateOfBirth, Address Address, ContactDetails ContactDetails) 
    : IRequest<ErrorOr<Student>>;
