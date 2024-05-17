using AutoMapper;
using KT.Application.Courses.Commands.Add;
using KT.Application.Courses.Commands.Remove;
using KT.Application.Courses.Queries;
using KT.Presentation.Contracts.V1.Requests.Courses;
using KT.Presentation.Contracts.V1.Responses.Courses;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace KT.Presentation.API.V1.Controllers;

/// <summary>
/// Courses controller.
/// </summary>
[ApiVersion("1.0")]
[Route("api/v{version:apiVersion}/[controller]")]
public class CoursesController(ISender mediatr,  IMapper mapper) : ApiController
{
    /// <summary>
    /// Get a list of courses.
    /// </summary>
    [HttpGet("")]
    [ProducesResponseType(typeof(IList<CourseResponse>), StatusCodes.Status200OK)]
    public async Task<IActionResult> ListAsync()
    {
        var query = new ListQuery();
        var courses = await mediatr.Send(query);

        return Ok(mapper.Map<IList<CourseResponse>>(courses));
    }
    
    /// <summary>
    /// Get a course by id.
    /// </summary>
    [HttpGet("{id:guid}")]
    [ProducesResponseType(typeof(CourseResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(void), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetAsync([FromRoute] Guid id)
    {
        var query = new GetByIdQuery(id);
        var courses = await mediatr.Send(query);

        return courses.Match(
            authResult => Ok(mapper.Map<CourseResponse>(courses.Value)),
            Problem
        );
    }

    /// <summary>
    /// Add a course.
    /// </summary>
    [HttpPost("")]
    [ProducesResponseType(typeof(CourseResponse), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(void), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> AddAsync([FromBody] AddCourseRequest request)
    {
        var command = new AddCourseCommand(
            request.LearnerId,
            request.Code,
            request.Title,
            request.Description,
            request.Level,
            request.StartDate,
            request.ExpectedEndDate,
            request.ActualEndDate);

        var created = await mediatr.Send(command);
        
        return created.Match(
            authResult => CreatedAtAction("Get", new { id = created.Value.Id }, mapper.Map<CourseResponse>(created.Value)),
            Problem);
    }

    /// <summary>
    /// Remove a course.
    /// </summary>
    [HttpDelete("{id:guid}")]
    [ProducesResponseType(typeof(void), StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(void), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> RemoveAsync([FromRoute] Guid id)
    {
        var command = new RemoveCourseCommand(id);
        var deleted = await mediatr.Send(command);
        
        return deleted.Match(
            authResult => NoContent(),
            Problem);
    }
}
