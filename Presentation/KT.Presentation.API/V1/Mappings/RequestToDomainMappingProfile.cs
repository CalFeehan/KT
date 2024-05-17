using AutoMapper;
using KT.Domain.Common.ValueObjects;
using KT.Domain.CourseAggregate;
using KT.Domain.CourseAggregate.ValueObjects;
using KT.Domain.CourseTemplateAggregate;
using KT.Domain.CourseTemplateAggregate.Entities;
using KT.Domain.CourseTemplateAggregate.ValueObjects;
using KT.Domain.LearnerAggregate;
using KT.Domain.LearnerAggregate.Entities;
using KT.Domain.ModuleTemplateAggregate;
using KT.Domain.ModuleTemplateAggregate.ValueObjects;
using KT.Domain.SessionAggregate;
using KT.Presentation.Contracts.V1.Requests.Common;
using KT.Presentation.Contracts.V1.Requests.Courses;
using KT.Presentation.Contracts.V1.Requests.CourseTemplates;
using KT.Presentation.Contracts.V1.Requests.Learners;
using KT.Presentation.Contracts.V1.Requests.ModuleTemplates;
using KT.Presentation.Contracts.V1.Requests.Sessions;

namespace KT.Presentation.API;

/// <summary>
///     Mapping profile for requests to domain objects.
/// </summary>
public class RequestToDomainMappingProfile : Profile
{
    /// <summary>
    ///     Initializes a new instance of the <see cref="RequestToDomainMappingProfile" /> class.
    /// </summary>
    public RequestToDomainMappingProfile()
    {
        // aggregate roots
        CreateMap<AddLearnerRequest, Learner>();
        CreateMap<AddSessionRequest, Session>();
        CreateMap<AddCourseRequest, Course>();

        // entities
        CreateMap<AddLearningPlanRequest, LearningPlan>();
        CreateMap<AddCourseTemplateRequest, CourseTemplate>();
        CreateMap<AddSessionPlanTemplateRequest, SessionPlanTemplate>();
        CreateMap<AddSessionTemplateRequest, SessionTemplate>();
        CreateMap<AddActivityPlanTemplateRequest, ActivityPlanTemplate>();
        CreateMap<AddActivityTemplateRequest, ActivityTemplate>();
        CreateMap<AddModuleTemplateRequest, ModuleTemplate>();

        // value objects
        CreateMap<AddressRequest, Address>();
        CreateMap<ContactDetailsRequest, ContactDetails>();
        CreateMap<SessionDetailsRequest, ScheduleDetails>();
        CreateMap<CriteriaTemplateRequest, CriteriaTemplate>();
        CreateMap<CriteriaRequest, Criteria>();
    }
}