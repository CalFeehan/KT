using AutoMapper;
using KT.Domain.Common.ValueObjects;
using KT.Domain.CourseAggregate;
using KT.Domain.LearnerAggregate;
using KT.Domain.LearnerAggregate.Entities;
using KT.Domain.LibraryAggregate;
using KT.Domain.LibraryAggregate.Entities;
using KT.Domain.LibraryAggregate.ValueObjects;
using KT.Domain.SessionAggregate;
using KT.Presentation.Contracts.V1.Requests;

namespace KT.Presentation.API;

/// <summary>
/// Mapping profile for requests to domain objects.
/// </summary>
public class RequestToDomainMappingProfile : Profile
{
    /// <summary>
    /// Initializes a new instance of the <see cref="RequestToDomainMappingProfile"/> class.
    /// </summary>
    public RequestToDomainMappingProfile()
    {
        CreateMap<CreateLearnerRequest, Learner>();
        CreateMap<CreateLearningPlanRequest, LearningPlan>();
        CreateMap<AddressRequest, Address>();
        CreateMap<ContactDetailsRequest, ContactDetails>();
        CreateMap<CreateSessionRequest, Session>();
        CreateMap<CreateCourseRequest, Course>();
        CreateMap<CreateLibraryRequest, Library>();
        CreateMap<CreateCourseTemplateRequest, CourseTemplate>();
        CreateMap<CreateSessionPlanTemplateRequest, SessionPlanTemplate>();
        CreateMap<CreateSessionTemplateRequest, SessionTemplate>();
        CreateMap<CreateActivityPlanTemplateRequest, ActivityPlanTemplate>();
        CreateMap<CreateActivityTemplateRequest, ActivityTemplate>();
        CreateMap<SessionDetailsRequest, ScheduleDetails>();
        CreateMap<CreateModuleTemplateRequest, ModuleTemplate>();
    }
}
    