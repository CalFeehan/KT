using AutoMapper;
using KT.Domain.Common.ValueObjects;
using KT.Domain.StudentAggregate;
using KT.Presentation.Contracts.V1.Responses;

namespace KT.Presentation.Contracts.V1.Mappings;

public class DomainToResponseProfile : Profile
{
    public DomainToResponseProfile()
    {
        CreateMap<Student, StudentResponse>();
        CreateMap<Address, AddressResponse>();
        CreateMap<ContactDetails, ContactDetailsResponse>();
    }
}