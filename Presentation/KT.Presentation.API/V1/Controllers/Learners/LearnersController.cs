using AutoMapper;
using KT.Application.Learners.Commands.Create;
using KT.Application.Learners.Commands.Delete;
using KT.Application.Learners.Queries.GetLearners;
using KT.Domain.Common.ValueObjects;
using KT.Presentation.Contracts.V1.Requests;
using KT.Presentation.Contracts.V1.Responses;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace KT.Presentation.API.V1.Controllers.Learners;

/// <summary>
/// Learners controller.
/// </summary>
[ApiVersion("1.0")]
[Route("api/v{version:apiVersion}/[controller]")]
public class LearnersController(ISender mediatr,  IMapper mapper) : ApiController
{
    /// <summary>
    /// Get a list of learners.
    /// </summary>
    [HttpGet("")]
    [ProducesResponseType(typeof(IList<LearnerResponse>), StatusCodes.Status200OK)]
    public async Task<IActionResult> ListAsync()
    {
        var query = new ListQuery();
        var learners = await mediatr.Send(query);
        
        var response = mapper.Map<IList<LearnerResponse>>(learners);
        return Ok(response);
    }
    
    /// <summary>
    /// Get a learner by id.
    /// </summary>
    [HttpGet("{id:guid}")]
    [ProducesResponseType(typeof(LearnerResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(void), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetAsync([FromRoute] Guid id)
    {
        var query = new GetByIdQuery(id);
        var learner = await mediatr.Send(query);

        return learner.Match(
            authResult => Ok(mapper.Map<LearnerResponse>(learner.Value)),
            Problem
        );
    }

    /// <summary>
    /// Create a learner.
    /// </summary>
    [HttpPost("")]
    [ProducesResponseType(typeof(LearnerResponse), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(void), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> CreateAsync([FromBody] CreateLearnerRequest request)
    {
        var command = new CreateCommand(request.Forename, request.Surname, DateOnly.FromDateTime(request.DateOfBirth), 
            Address.Create(request.Address.Line1, request.Address.Line2, request.Address.City, request.Address.County, request.Address.Postcode),
            ContactDetails.Create(request.ContactDetails.Email, request.ContactDetails.Phone, request.ContactDetails.ContactPreference));

        var created = await mediatr.Send(command);
        
        return created.Match(
            authResult => CreatedAtAction(nameof(GetAsync), new { id = created.Value.Id }, mapper.Map<LearnerResponse>(created.Value)),
            Problem);
    }

    /// <summary>
    /// Delete a learner by id.
    /// </summary>
    [HttpDelete("{id:guid}")]
    [ProducesResponseType(typeof(void), StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(void), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> DeleteAsync(Guid id)
    {
        var command = new DeleteCommand(id);
        var deleted = await mediatr.Send(command);
        
        return deleted.Match(
            authResult => NoContent(),
            Problem);
    }
}