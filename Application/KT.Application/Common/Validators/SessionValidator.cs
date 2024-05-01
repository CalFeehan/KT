using FluentValidation;
using KT.Domain.SessionAggregate;

namespace KT.Application;

public class SessionValidator : AbstractValidator<Session>
{
    public SessionValidator()
    {
        RuleFor(x => x.CourseId).NotEmpty();
        RuleFor(x => x.SessionType).NotEmpty();
        RuleFor(x => x.StartTime).NotEmpty();
        RuleFor(x => x.EndTime).NotEmpty();
        RuleFor(x => x.Location);
        RuleFor(x => x.Notes);
        RuleFor(x => x.MeetingLink);
    }
}
