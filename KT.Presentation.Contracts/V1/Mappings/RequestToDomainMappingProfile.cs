using AutoMapper;
using KT.Domain.Aggregates;
using KT.Presentation.Contracts.V1.Requests;
using KT.Presentation.Contracts.V1.Responses;

namespace KT.Presentation.Contracts.V1.Mappings;

public class RequestToDomainMappingProfile : Profile
{
    public RequestToDomainMappingProfile()
    {
        CreateMap<CreateStudentRequest, Student>();
    }
}