using ErrorOr;
using KT.Common.Enums;
using KT.Domain.SessionAggregate;
using MediatR;

namespace KT.Application.Sessions.Commands.Create;

public record CreateCommand(
    Guid CourseId,
    SessionType SessionType,
    DateTime StartTime,
    DateTime EndTime,
    Guid? CohortId,
    string Location,
    string Notes,
    string MeetingLink) : IRequest<ErrorOr<Session>>;
