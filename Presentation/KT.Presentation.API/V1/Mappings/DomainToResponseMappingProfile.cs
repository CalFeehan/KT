using AutoMapper;
using KT.Domain.Common.ValueObjects;
using KT.Domain.CourseAggregate.ValueObjects;
using KT.Domain.LearnerAggregate;
using KT.Domain.LearnerAggregate.Entities;
using KT.Domain.LibraryAggregate;
using KT.Domain.LibraryAggregate.Entities;
using KT.Domain.LibraryAggregate.ValueObjects;
using KT.Domain.SessionAggregate;
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
        // aggregate roots
        CreateMap<Learner, LearnerResponse>()
            .ForCtorParam("DateOfBirth", opt => opt.MapFrom(src => src.DateOfBirth.ToDateTime(TimeOnly.MinValue)));
        CreateMap<Library, LibraryResponse>();
        CreateMap<Session, SessionResponse>();

        // entities
        CreateMap<LearningPlan, LearningPlanResponse>();
        CreateMap<CourseTemplate, CourseTemplateResponse>();
        CreateMap<SessionPlanTemplate, SessionPlanTemplateResponse>();
        CreateMap<SessionTemplate, SessionTemplateResponse>();
        CreateMap<ActivityPlanTemplate, ActivityPlanTemplateResponse>();
        CreateMap<ActivityTemplate, ActivityTemplateResponse>();
        CreateMap<ModuleTemplate, ModuleTemplateResponse>();

        // value objects
        CreateMap<Criteria, CriteriaResponse>();
        CreateMap<CriteriaTemplate, CriteriaTemplateResponse>();
        CreateMap<ScheduleDetails, ScheduleDetailsResponse>();
        CreateMap<Address, AddressResponse>();
        CreateMap<ContactDetails, ContactDetailsResponse>();
    }
}

