using AutoMapper;
using KT.Application.Learners.Commands.Create;
using KT.Application.Learners.Queries.GetLearningPlans;
using KT.Presentation.Contracts.V1.Requests;
using KT.Presentation.Contracts.V1.Responses;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using KT.Application.Learners.Commands.Delete;

namespace KT.Presentation.API.V1.Controllers;

[Route("learners/{learnerId:guid}/[controller]s")]
public class LearningPlanController(ISender mediatr,  IMapper mapper) : ApiController
{
    [HttpGet("")]
    [ProducesResponseType(typeof(IList<LearningPlanResponse>), StatusCodes.Status200OK)]
    public async Task<IActionResult> ListAsync([FromRoute] Guid learnerId)
    {
        var query = new ListQuery(learnerId);
        var learningPlans = await mediatr.Send(query);

        return learningPlans.Match(
            authResult => Ok(mapper.Map<IList<LearningPlanResponse>>(learningPlans.Value)),
            Problem);
    }
    
    [HttpGet("{id:guid}")]
    [ProducesResponseType(typeof(LearningPlanResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(void), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetAsync([FromRoute] Guid learnerId, Guid id)
    {
        var query = new GetByIdQuery(learnerId, id);
        var learningPlan = await mediatr.Send(query);

        return learningPlan.Match(
            authResult => Ok(mapper.Map<LearningPlanResponse>(learningPlan.Value)),
            Problem
        );
    }

    [HttpPost("")]
    [ProducesResponseType(typeof(LearningPlanResponse), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(void), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> CreateAsync([FromRoute] Guid learnerId, [FromBody] CreateLearningPlanRequest request)
    {
        var command = new CreateLearningPlanCommand(
            learnerId, request.Title, request.Description, request.StartDate, request.ExpectedEndDate);

        var created = await mediatr.Send(command);
        
        return created.Match(
            authResult => CreatedAtAction(nameof(GetAsync), new { learnerId, id = created.Value.Id }, mapper.Map<LearningPlanResponse>(created.Value)),
            Problem);
    }

    [HttpDelete("{id:guid}")]
    [ProducesResponseType(typeof(void), StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(void), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> DeleteAsync([FromRoute] Guid learnerId, [FromRoute] Guid id)
    {
        var command = new DeleteLearningPlanCommand(learnerId, id);
        var deleted = await mediatr.Send(command);
        
        return deleted.Match(
            authResult => NoContent(),
            Problem);
    }
}