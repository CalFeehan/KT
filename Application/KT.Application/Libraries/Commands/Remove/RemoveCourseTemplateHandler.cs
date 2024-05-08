using ErrorOr;
using KT.Application.Common.Interfaces.Persistence;
using MediatR;
using KT.Domain.Common.Errors;

namespace KT.Application.Libraries.Commands.Remove;

public class RemoveCourseTemplateHandler : IRequestHandler<RemoveCourseTemplateCommand, ErrorOr<Task>>
{
    private readonly ILibraryRepository _libraryRepository;

    public RemoveCourseTemplateHandler(ILibraryRepository libraryRepository)
    {
        _libraryRepository = libraryRepository;
    }

    public async Task<ErrorOr<Task>> Handle(RemoveCourseTemplateCommand request, CancellationToken cancellationToken)
    {
        var library = await _libraryRepository.GetByIdAsync(request.LibraryId);
        if (library is null)
        {
            return Errors.Library.NotFound;
        }

        library.RemoveCourseTemplate(request.CourseTemplateId);

        await _libraryRepository.UpdateAsync(library);

        return Task.CompletedTask;
    }
}
