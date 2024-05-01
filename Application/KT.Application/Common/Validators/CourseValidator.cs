using FluentValidation;
using KT.Common.Enums;
using KT.Domain.CourseAggregate;

namespace KT.Application;

public class CourseValidator : AbstractValidator<Course>
{
    public CourseValidator()
    {
        RuleFor(x => x.LearnerId).NotEmpty();
        RuleFor(x => x.Code).NotEmpty().MaximumLength(25);
        RuleFor(x => x.Level).NotEmpty().GreaterThan(0);
        RuleFor(x => x.CourseStatus).IsInEnum();
        RuleFor(x => x.Title).NotEmpty().MaximumLength(100);
        RuleFor(x => x.Description).NotEmpty().MaximumLength(500);
        RuleFor(x => x.StartDate).NotEmpty();
        RuleFor(x => x.ExpectedEndDate).NotEmpty().GreaterThan(x => x.StartDate);
        RuleFor(x => x.ActualEndDate).GreaterThan(x => x.StartDate);
        
        RuleFor(x => x).Must(BeAValidStatus).WithMessage("Course status is not valid");
    }

    private static bool BeAValidStatus(Course course)
    {
        return course.CourseStatus switch
        {
            CourseStatus.NotStarted => course.StartDate > DateTime.Now,
            CourseStatus.InProgress => course.StartDate <= DateTime.Now && !course.ActualEndDate.HasValue,
            CourseStatus.Completed => course.ActualEndDate.HasValue,
            _ => true
        };
    }
}
