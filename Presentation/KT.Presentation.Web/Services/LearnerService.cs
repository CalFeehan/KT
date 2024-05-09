using KT.Presentation.ClientsGenerated;

namespace KT.Presentation.Web.Services;

public class LearnerService : ILearnerService
{
    private readonly IClient _client;

    public LearnerService(IClient client)
    {
        _client = client;
    }

    public async Task<List<LearnerResponse>> LearnersAllAsync()
    {
        var learners = await _client.LearnersAllAsync();
        return [.. learners];
    }

    public async Task<LearnerResponse> LearnersPOSTAsync(AddLearnerRequest learner)
    {
        var learnerResponse = await _client.LearnersPOSTAsync(learner);
        return learnerResponse;
    }
    
}
