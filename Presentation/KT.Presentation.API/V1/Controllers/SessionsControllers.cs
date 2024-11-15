﻿using AutoMapper;
using KT.Application.Sessions.Commands.Add;
using KT.Application.Sessions.Commands.Remove;
using KT.Application.Sessions.Queries;
using KT.Presentation.Contracts.V1.Requests.Sessions;
using KT.Presentation.Contracts.V1.Responses.Sessions;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace KT.Presentation.API.V1.Controllers;

/// <summary>
///     Sessions controller.
/// </summary>
[ApiVersion("1.0")]
[Route("api/v{version:apiVersion}/[controller]")]
public class SessionsController(ISender mediatr, IMapper mapper) : ApiController
{
    /// <summary>
    ///     Get a list of sessions.
    /// </summary>
    [HttpGet("")]
    [ProducesResponseType(typeof(IList<SessionResponse>), StatusCodes.Status200OK)]
    public async Task<IActionResult> ListAsync()
    {
        var query = new ListQuery();
        var sessions = await mediatr.Send(query);

        return Ok(mapper.Map<IList<SessionResponse>>(sessions));
    }

    /// <summary>
    ///     Get a session by id.
    /// </summary>
    [HttpGet("{id:guid}")]
    [ProducesResponseType(typeof(SessionResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(void), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetAsync(Guid id)
    {
        var query = new GetByIdQuery(id);
        var session = await mediatr.Send(query);

        return session.Match(
            value => Ok(mapper.Map<SessionResponse>(value)),
            Problem
        );
    }

    /// <summary>
    ///     Add a session.
    /// </summary>
    [HttpPost("")]
    [ProducesResponseType(typeof(SessionResponse), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(void), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> AddAsync([FromBody] AddSessionRequest request)
    {
        var command = new AddSessionCommand(
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
            value =>
                CreatedAtAction("Get", new { id = value.Id }, mapper.Map<SessionResponse>(value)),
            Problem);
    }

    /// <summary>
    ///     Remove a session by id.
    /// </summary>
    [HttpDelete("{id:guid}")]
    [ProducesResponseType(typeof(void), StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(void), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> RemoveAsync([FromRoute] Guid id)
    {
        var command = new RemoveSessionCommand(id);
        var deleted = await mediatr.Send(command);

        return deleted.Match(
            _ => NoContent(),
            Problem);
    }
}