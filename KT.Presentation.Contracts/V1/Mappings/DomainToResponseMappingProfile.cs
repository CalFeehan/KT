using AutoMapper;
using KT.Domain.Aggregates;
using KT.Presentation.Contracts.V1.Responses;

namespace KT.Presentation.Contracts.V1.Mappings;

public class DomainToResponseProfile : Profile
{
    public DomainToResponseProfile()
    {
        CreateMap<Student, StudentResponse>();
        CreateMap<Course, CourseResponse>();
    }
}