using AutoMapper;
using KT.Domain.Common.ValueObjects;
using KT.Domain.StudentAggregate;
using KT.Presentation.Contracts.V1.Requests;

namespace KT.Presentation.Contracts.V1.Mappings;

public class RequestToDomainMappingProfile : Profile
{
    public RequestToDomainMappingProfile()
    {
        CreateMap<CreateStudentRequest, Student>();
        CreateMap<AddressRequest, Address>();
        CreateMap<ContactDetailsRequest, ContactDetails>();
    }
}