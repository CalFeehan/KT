using AutoMapper;
using KT.Application.Libraries.Commands.Add;
using KT.Application.Libraries.Commands.Remove;
using KT.Application.Libraries.Queries.GetCourse;
using KT.Presentation.Contracts.V1.Requests;
using KT.Presentation.Contracts.V1.Responses;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace KT.Presentation.API.V1.Controllers.Libraries;

/// <summary>
/// Libraries controller.
/// </summary>
[ApiVersion("1.0")]
[Route("api/v{version:apiVersion}/[controller]")]
public class LibrariesController(ISender mediatr,  IMapper mapper) : ApiController
{
    /// <summary>
    /// Get a list of libraries.
    /// </summary>
    [HttpGet("")]
    [ProducesResponseType(typeof(IList<LibraryResponse>), StatusCodes.Status200OK)]
    public async Task<IActionResult> ListAsync()
    {
        var query = new ListQuery();
        var libraries = await mediatr.Send(query);

        return Ok(mapper.Map<IList<LibraryResponse>>(libraries));
    }
    
    /// <summary>
    /// Get a library by id.
    /// </summary>
    [HttpGet("{id:guid}")]
    [ProducesResponseType(typeof(LibraryResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(void), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetAsync(Guid id)
    {
        var query = new GetByIdQuery(id);
        var library = await mediatr.Send(query);

        return library.Match(
            authResult => Ok(mapper.Map<LibraryResponse>(library.Value)),
            Problem
        );
    }

    /// <summary>
    /// Add a library.
    /// </summary>
    [HttpPost("")]
    [ProducesResponseType(typeof(LibraryResponse), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(void), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> AddAsync([FromBody] AddLibraryRequest request)
    {
        var command = new AddLibraryCommand();

        var created = await mediatr.Send(command);
        
        return created.Match(
            authResult => CreatedAtAction(nameof(GetAsync), new { id = created.Value.Id }, mapper.Map<LibraryResponse>(created.Value)),
            Problem);
    }

    /// <summary>
    /// Remove a library by id.
    /// </summary>
    [HttpDelete("{id:guid}")]
    [ProducesResponseType(typeof(void), StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(void), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> RemoveAsync([FromRoute] Guid id)
    {
        var command = new RemoveLibraryCommand(id);
        var deleted = await mediatr.Send(command);
        
        return deleted.Match(
            authResult => NoContent(),
            Problem);
    }

    /// <summary>
    /// Add a course template to a library.
    /// </summary>
    [HttpPost("{libraryId:guid}/course-templates")]
    [ProducesResponseType(typeof(void), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(void), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(void), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> AddCourseTemplateAsync([FromRoute] Guid libraryId, [FromBody] AddCourseTemplateRequest request)
    {
        var command = new AddCourseTemplateCommand(
            libraryId,
            request.Title,
            request.Description,
            request.Code,
            request.Level,
            request.DurationInWeeks);

        var added = await mediatr.Send(command);
        
        return added.Match(
            authResult => NoContent(),
            Problem);
    }

    /// <summary>
    /// Remove a course template from a library.
    /// </summary>
    [HttpDelete("{libraryId:guid}/course-templates/{courseTemplateId:guid}")]
    [ProducesResponseType(typeof(void), StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(void), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> RemoveCourseTemplateAsync([FromRoute] Guid libraryId, [FromRoute]
    Guid courseTemplateId)
    {
        var command = new RemoveCourseTemplateCommand(libraryId, courseTemplateId);
        var removed = await mediatr.Send(command);
        
        return removed.Match(
            authResult => NoContent(),
            Problem);
    }
}