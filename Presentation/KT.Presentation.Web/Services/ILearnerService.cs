using KT.Presentation.ClientsGenerated;

namespace KT.Presentation.Web.Services;

public interface ILearnerService
{
    Task<List<LearnerResponse>> LearnersAllAsync();

    Task<LearnerResponse> LearnersPOSTAsync(AddLearnerRequest learner);
}