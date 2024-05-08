using ErrorOr;
using KT.Application.Common.Interfaces.Persistence;
using KT.Domain.LibraryAggregate.Entities;
using MediatR;
using KT.Domain.Common.Errors;

namespace KT.Application.Libraries.Commands.Add;

public class AddCourseTemplateHandler : IRequestHandler<AddCourseTemplateCommand, ErrorOr<CourseTemplate>>
{
    private readonly ILibraryRepository _libraryRepository;

    public AddCourseTemplateHandler(ILibraryRepository libraryRepository)
    {
        _libraryRepository = libraryRepository;
    }

    public async Task<ErrorOr<CourseTemplate>> Handle(AddCourseTemplateCommand request, CancellationToken cancellationToken)
    {
        // add course template to library
        var library = await _libraryRepository.GetByIdAsync(request.LibraryId);
        if (library is null)
        {
            return Errors.Library.NotFound;
        }

        var courseTemplate = library.AddCourseTemplate(request.Title, request.Description, request.Code, request.Level, request.DurationInDays);

        await _libraryRepository.UpdateAsync(library);

        return courseTemplate;
    }
}
