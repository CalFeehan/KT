using KT.Presentation.ClientsGenerated;

namespace KT.Presentation.Web.Services;

public class LearnerService : ILearnerService
{
    public async Task<List<LearnerResponse>> LearnersAllAsync()
    {
        var client = new Client("http://localhost:5130", new HttpClient());
        var learners = await client.LearnersAllAsync();
        return [.. learners];
    }

    public async Task<LearnerResponse> LearnersPOSTAsync(CreateLearnerRequest learner)
    {
        var client = new Client("http://localhost:5130", new HttpClient());
        var learnerResponse = await client.LearnersPOSTAsync(learner);
        return learnerResponse;
    }
    
}
