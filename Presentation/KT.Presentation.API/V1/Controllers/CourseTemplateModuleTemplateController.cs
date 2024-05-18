using AutoMapper;
using KT.Application.CourseTemplates.Commands.Update;
using KT.Application.ModuleTemplates.Queries;
using KT.Presentation.Contracts.V1.Responses.ModuleTemplates;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using GetByIdQuery = KT.Application.CourseTemplates.Queries.GetByIdQuery;

namespace KT.Presentation.API.V1.Controllers;

/// <summary>
///     Courses controller.
/// </summary>
[ApiVersion("1.0")]
[Route("api/v{version:apiVersion}/coursetemplate/{courseId:guid}/moduleTemplates")]
public class CourseTemplateModuleTemplateController(ISender mediatr, IMapper mapper) : ApiController
{
    /// <summary>
    ///     Get a list of module templates for a course template.
    /// </summary>
    [HttpGet("")]
    [ProducesResponseType(typeof(IList<ModuleTemplateResponse>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(void), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> ListAsync([FromRoute] Guid courseId)
    {
        var courseQuery = new GetByIdQuery(courseId);
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
    [HttpPut("")]
    [ProducesResponseType(typeof(void), StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(void), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(void), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> UpdateAsync([FromRoute] Guid courseId, [FromBody] IList<Guid> moduleTemplateIds)
    {
        var courseQuery = new GetByIdQuery(courseId);
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
}