using AutoMapper;
using KT.Application.CourseTemplates.Commands.Add;
using KT.Application.CourseTemplates.Commands.Remove;
using KT.Application.CourseTemplates.Commands.Update;
using KT.Application.ModuleTemplates.Queries;
using KT.Domain.CourseTemplateAggregate.Entities;
using KT.Presentation.Contracts.V1.Requests.CourseTemplates;
using KT.Presentation.Contracts.V1.Responses.CourseTemplates;
using KT.Presentation.Contracts.V1.Responses.ModuleTemplates;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using GetByIdQuery = KT.Application.CourseTemplates.Queries.GetByIdQuery;
using ListQuery = KT.Application.CourseTemplates.Queries.ListQuery;

namespace KT.Presentation.API.V1.Controllers;

/// <summary>
///     CourseTemplates controller.
/// </summary>
[ApiVersion("1.0")]
[Route("api/v{version:apiVersion}/[controller]")]
public class CourseTemplatesController(ISender mediatr, IMapper mapper) : ApiController
{
    /// <summary>
    ///     List all CourseTemplates.
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
    ///     Get a CourseTemplate by id.
    /// </summary>
    [HttpGet("{id:guid}")]
    [ProducesResponseType(typeof(CourseTemplateResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(void), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetAsync([FromRoute] Guid id)
    {
        var query = new GetByIdQuery(id);
        var courseTemplate = await mediatr.Send(query);

        return courseTemplate.Match(
            ct => Ok(mapper.Map<CourseTemplateResponse>(ct)),
            Problem);
    }

    /// <summary>
    ///     Add a CourseTemplate.
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
            _ => CreatedAtAction("Get", new { id = added.Value.Id }, mapper.Map<CourseTemplateResponse>(added.Value)),
            Problem);
    }

    /// <summary>
    ///     Remove a course template.
    /// </summary>
    [HttpDelete("{id:guid}")]
    [ProducesResponseType(typeof(void), StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(void), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> RemoveAsync([FromRoute] Guid id)
    {
        var command = new RemoveCourseTemplateCommand(id);
        var removed = await mediatr.Send(command);

        return removed.Match(
            _ => NoContent(),
            Problem);
    }

    /// <summary>
    ///     Get a list of module templates for a course template.
    /// </summary>
    [HttpGet("{id:guid}/moduleTemplates")]
    [ProducesResponseType(typeof(IList<ModuleTemplateResponse>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(void), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> ListAsync([FromRoute] Guid id)
    {
        var courseQuery = new GetByIdQuery(id);
        var courseTemplate = await mediatr.Send(courseQuery);
        if (courseTemplate.IsError) return Problem(courseTemplate.Errors);

        var query = new GetByIdsQuery(
            courseTemplate.Value.CourseTemplateModuleTemplates.Select(x => x.ModuleTemplateId).ToList());

        var moduleTemplates = await mediatr.Send(query);

        return moduleTemplates.Match(
            mt => Ok(mapper.Map<IList<ModuleTemplateResponse>>(mt)),
            Problem);
    }

    /// <summary>
    ///     Update the module templates for a course template.
    /// </summary>
    [HttpPut("{id:guid}/moduleTemplates")]
    [ProducesResponseType(typeof(void), StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(void), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(void), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> UpdateAsync([FromRoute] Guid id, [FromBody] IList<Guid> moduleTemplateIds)
    {
        var courseQuery = new GetByIdQuery(id);
        var courseTemplate = await mediatr.Send(courseQuery);
        if (courseTemplate.IsError) return Problem(courseTemplate.Errors);

        var moduleTemplateIdsQuery = new GetByIdsQuery(moduleTemplateIds);
        var moduleTemplates = await mediatr.Send(moduleTemplateIdsQuery);
        if (moduleTemplates.IsError) return Problem(moduleTemplates.Errors);

        var command = new UpdateCourseTemplateCommand(
            courseTemplate.Value.Id,
            courseTemplate.Value.CourseTemplateStatus,
            courseTemplate.Value.Title,
            courseTemplate.Value.Description,
            courseTemplate.Value.Code,
            courseTemplate.Value.Level,
            courseTemplate.Value.DurationInWeeks,
            courseTemplate.Value.ActivityPlanTemplate,
            courseTemplate.Value.SessionPlanTemplate,
            moduleTemplates.Value.Select(x => x.Id).ToList());

        var result = await mediatr.Send(command);

        return result.Match(
            _ => NoContent(),
            Problem);
    }
    
    /// <summary>
    ///     Get the SessionPlanTemplate for a course template.
    /// </summary>
    [HttpGet("{id:guid}/sessionPlanTemplate")]
    [ProducesResponseType(typeof(SessionPlanTemplateResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(void), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetSessionPlanTemplateAsync([FromRoute] Guid id)
    {
        var courseQuery = new GetByIdQuery(id);
        var courseTemplate = await mediatr.Send(courseQuery);
        if (courseTemplate.IsError) return Problem(courseTemplate.Errors);
        
        return courseTemplate.Match(
            ct => Ok(mapper.Map<SessionPlanTemplateResponse>(ct.SessionPlanTemplate)),
            Problem);
    }
    
    /// <summary>
    ///     Update the SessionPlanTemplate for a course template.
    /// </summary>
    [HttpPut("{id:guid}/sessionPlanTemplate")]
    [ProducesResponseType(typeof(void), StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(void), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(void), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> UpdateSessionPlanTemplateAsync([FromRoute] Guid id, [FromBody] AddSessionPlanTemplateRequest request)
    {
        var courseQuery = new GetByIdQuery(id);
        var courseTemplate = await mediatr.Send(courseQuery);
        if (courseTemplate.IsError) return Problem(courseTemplate.Errors);
        
        var sessionPlanTemplate = mapper.Map<SessionPlanTemplate>(request);

        var command = new UpdateCourseTemplateCommand(
            courseTemplate.Value.Id,
            courseTemplate.Value.CourseTemplateStatus,
            courseTemplate.Value.Title,
            courseTemplate.Value.Description,
            courseTemplate.Value.Code,
            courseTemplate.Value.Level,
            courseTemplate.Value.DurationInWeeks,
            courseTemplate.Value.ActivityPlanTemplate,
            sessionPlanTemplate,
            courseTemplate.Value.CourseTemplateModuleTemplates.Select(x => x.ModuleTemplateId).ToList());

        var result = await mediatr.Send(command);

        return result.Match(
            _ => NoContent(),
            Problem);
    }
}