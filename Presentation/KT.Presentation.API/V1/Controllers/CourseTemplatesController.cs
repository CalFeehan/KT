using AutoMapper;
using KT.Application.CourseTemplates.Commands.Add;
using KT.Application.CourseTemplates.Commands.Remove;
using KT.Application.CourseTemplates.Queries;
using KT.Presentation.Contracts.V1.Requests.CourseTemplates;
using KT.Presentation.Contracts.V1.Responses.CourseTemplates;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace KT.Presentation.API.V1.Controllers;

/// <summary>
/// CourseTemplates controller.
/// </summary>
[ApiVersion("1.0")]
[Route("api/v{version:apiVersion}/[controller]")]
public class CourseTemplatesController(ISender mediatr,  IMapper mapper) : ApiController
{
    /// <summary>
    /// List all CourseTemplates.
    /// </summary>
    [HttpGet("")]
    [ProducesResponseType(typeof(IEnumerable<CourseTemplateResponse>), StatusCodes.Status200OK)]
    public async Task<IActionResult> ListAsync()
    {
        var query = new ListQuery();
        var courseTemplates = await mediatr.Send(query);

        return Ok(mapper.Map<List<CourseTemplateResponse>>(courseTemplates));
    }

    /// <summary>
    /// Get a CourseTemplate by id.
    /// </summary>
    [HttpGet("{id:guid}")]
    [ProducesResponseType(typeof(CourseTemplateResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(void), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetAsync([FromRoute] Guid id)
    {
        var query = new GetByIdQuery(id);
        var courseTemplate = await mediatr.Send(query);

        return courseTemplate.Match(
            courseTemplate => Ok(mapper.Map<CourseTemplateResponse>(courseTemplate)),
            Problem);
    }

    /// <summary>
    /// Add a CourseTemplate.
    /// </summary>
    [HttpPost("")]
    [ProducesResponseType(typeof(CourseTemplateResponse), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(void), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(void), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> AddAsync([FromBody] AddCourseTemplateRequest request)
    {
        var command = new AddCourseTemplateCommand(
            request.Title,
            request.Description,
            request.Code,
            request.Level,
            request.DurationInWeeks);

        var added = await mediatr.Send(command);
        
        return added.Match(
            authResult => CreatedAtAction("Get", new { id = added.Value.Id }, mapper.Map<CourseTemplateResponse>(added.Value)),
            Problem);
    }

    /// <summary>
    /// Remove a course template.
    /// </summary>
    [HttpDelete("{id:guid}")]
    [ProducesResponseType(typeof(void), StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(void), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> RemoveAsync([FromRoute] Guid id)
    {
        var command = new RemoveCourseTemplateCommand(id);
        var removed = await mediatr.Send(command);
        
        return removed.Match(
            authResult => NoContent(),
            Problem);
    }
    
    // /// <summary>
    // /// Update a course template.
    // /// </summary>
    // [HttpPut("{id:guid}")]
    // [ProducesResponseType(typeof(CourseTemplateResponse), StatusCodes.Status200OK)]
    // [ProducesResponseType(typeof(void), StatusCodes.Status400BadRequest)]
    // [ProducesResponseType(typeof(void), StatusCodes.Status404NotFound)]
    // public async Task<IActionResult> UpdateAsync([FromRoute] Guid id, [FromBody] UpdateCourseTemplateRequest request)
    // {
    //     var command = new UpdateCourseTemplateCommand(
    //         id,
    //         request.Title,
    //         request.Description,
    //         request.Code,
    //         request.Level,
    //         request.DurationInWeeks,
    //         request.CourseTemplateStatus);

    //     var updated = await mediatr.Send(command);
        
    //     return updated.Match(
    //         authResult => Ok(mapper.Map<CourseTemplateResponse>(updated.Value)),
    //         Problem);
    // }

    // /// <summary>
    // /// Update the module templates of a course template.
    // /// </summary>
    // [HttpPut("{id:guid}/module-templates")]
    // [ProducesResponseType(typeof(CourseTemplateResponse), StatusCodes.Status200OK)]
    // [ProducesResponseType(typeof(void), StatusCodes.Status400BadRequest)]
    // [ProducesResponseType(typeof(void), StatusCodes.Status404NotFound)]
    // public async Task<IActionResult> UpdateModuleTemplatesAsync([FromRoute] Guid id, [FromBody] UpdateModuleTemplatesRequest request)
    // {
    //     var command = new UpdateModuleTemplatesCommand(
    //         id,
    //         request.ModuleTemplateIds);

    //     var updated = await mediatr.Send(command);
        
    //     return updated.Match(
    //         authResult => Ok(mapper.Map<CourseTemplateResponse>(updated.Value)),
    //         Problem);
    // }

    // /// <summary>
    // /// Add a module template to a course template.
    // /// </summary>
    // [HttpPost("{id:guid}/module-templates/{moduleTemplateId:guid}")]
    // [ProducesResponseType(typeof(void), StatusCodes.Status204NoContent)]
    // [ProducesResponseType(typeof(void), StatusCodes.Status404NotFound)]
    // public async Task<IActionResult> AddModuleTemplateAsync([FromRoute] Guid id, [FromRoute] Guid moduleTemplateId)
    // {
    //     var command = new AddModuleTemplateCommand(id, moduleTemplateId);
    //     var added = await mediatr.Send(command);
        
    //     return added.Match(
    //         authResult => NoContent(),
    //         Problem);
    // }

    // /// <summary>
    // /// Remove a module template from a course template.
    // /// </summary>
    // [HttpDelete("{id:guid}/module-templates/{moduleTemplateId:guid}")]
    // [ProducesResponseType(typeof(void), StatusCodes.Status204NoContent)]
    // [ProducesResponseType(typeof(void), StatusCodes.Status404NotFound)]
    // public async Task<IActionResult> RemoveModuleTemplateAsync([FromRoute] Guid id, [FromRoute] Guid moduleTemplateId)
    // {
    //     var command = new RemoveModuleTemplateCommand(id, moduleTemplateId);
    //     var removed = await mediatr.Send(command);
        
    //     return removed.Match(
    //         authResult => NoContent(),
    //         Problem);
    // }
}