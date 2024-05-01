using AutoMapper;
using KT.Application.Sessions.Commands.Create;
using KT.Application.Sessions.Commands.Delete;
using KT.Application.Sessions.Queries.GetSessions;
using KT.Presentation.Contracts.V1.Requests;
using KT.Presentation.Contracts.V1.Responses;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace KT.Presentation.API.V1.Controllers.Sessions;

[Route("[controller]s")]
public class SessionController(ISender mediatr,  IMapper mapper) : ApiController
{
    [HttpGet("")]
    [ProducesResponseType(typeof(IList<SessionResponse>), StatusCodes.Status200OK)]
    public async Task<IActionResult> ListAsync()
    {
        var query = new ListQuery();
        var sessions = await mediatr.Send(query);

        return Ok(mapper.Map<IList<SessionResponse>>(sessions));
    }
    
    [HttpGet("{id:guid}")]
    [ProducesResponseType(typeof(SessionResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(void), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetAsync(Guid id)
    {
        var query = new GetByIdQuery(id);
        var session = await mediatr.Send(query);

        return session.Match(
            authResult => Ok(mapper.Map<SessionResponse>(session.Value)),
            Problem
        );
    }

    [HttpPost("")]
    [ProducesResponseType(typeof(SessionResponse), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(void), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> CreateAsync([FromBody] CreateSessionRequest request)
    {
        var command = new CreateCommand(
            request.CourseId,
            request.SessionType,
            request.StartTime,
            request.EndTime,
            request.CohortId,
            request.Location,
            request.Notes,
            request.MeetingLink);

        var created = await mediatr.Send(command);
        
        return created.Match(
            authResult => CreatedAtAction(nameof(GetAsync), new { id = created.Value.Id }, mapper.Map<SessionResponse>(created.Value)),
            Problem);
    }

    [HttpDelete("{id:guid}")]
    [ProducesResponseType(typeof(void), StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(void), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> DeleteAsync([FromRoute] Guid id)
    {
        var command = new DeleteCommand(id);
        var deleted = await mediatr.Send(command);
        
        return deleted.Match(
            authResult => NoContent(),
            Problem);
    }
}