using AutoMapper;
using KT.Domain.Common.ValueObjects;
using KT.Domain.LearnerAggregate;
using KT.Domain.LearnerAggregate.Entities;
using KT.Presentation.Contracts.V1.Requests;

namespace KT.Presentation.API;

public class RequestToDomainMappingProfile : Profile
{
    public RequestToDomainMappingProfile()
    {
        CreateMap<CreateLearnerRequest, Learner>();
        CreateMap<CreateLearningPlanRequest, LearningPlan>();
        CreateMap<AddressRequest, Address>();
        CreateMap<ContactDetailsRequest, ContactDetails>();
    }
}
    