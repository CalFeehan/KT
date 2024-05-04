using AutoMapper;
using KT.Domain.Common.ValueObjects;
using KT.Domain.LearnerAggregate;
using KT.Domain.LearnerAggregate.Entities;
using KT.Domain.LibraryAggregate;
using KT.Presentation.Contracts.V1.Responses;

namespace KT.Presentation.API;

/// <summary>
/// Mapping profile for domain objects to responses.
/// </summary>
public class DomainToResponseProfile : Profile
{
    /// <summary>
    /// Initializes a new instance of the <see cref="DomainToResponseProfile"/> class.
    /// </summary>
    public DomainToResponseProfile()
    {
        CreateMap<Learner, LearnerResponse>()
            .ForCtorParam("DateOfBirth", opt => opt.MapFrom(src => src.DateOfBirth.ToDateTime(TimeOnly.MinValue)));
        CreateMap<Address, AddressResponse>();
        CreateMap<ContactDetails, ContactDetailsResponse>();
        CreateMap<LearningPlan, LearningPlanResponse>();
        CreateMap<Library, LibraryResponse>();
    }
}

