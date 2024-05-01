using FluentValidation;
using KT.Domain.LibraryAggregate;

namespace KT.Application;

public class LibraryValidator : AbstractValidator<Library>
{
    public LibraryValidator()
    {
        
    }
}
