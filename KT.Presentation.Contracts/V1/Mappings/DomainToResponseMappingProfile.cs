using AutoMapper;
using KT.Domain.Common.ValueObjects;
using KT.Domain.LearnerAggregate;
using KT.Presentation.Contracts.V1.Responses;

namespace KT.Presentation.Contracts.V1.Mappings;

public class DomainToResponseProfile : Profile
{
    public DomainToResponseProfile()
    {
        CreateMap<Learner, LearnerResponse>();
        CreateMap<Address, AddressResponse>();
        CreateMap<ContactDetails, ContactDetailsResponse>();
    }
}