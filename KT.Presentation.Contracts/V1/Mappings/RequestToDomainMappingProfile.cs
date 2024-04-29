using AutoMapper;
using KT.Domain.StudentAggregate;
using KT.Presentation.Contracts.V1.Requests;

namespace KT.Presentation.Contracts.V1.Mappings;

public class RequestToDomainMappingProfile : Profile
{
    public RequestToDomainMappingProfile()
    {
        CreateMap<CreateStudentRequest, Student>();
    }
}