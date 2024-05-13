using AutoMapper;
using KT.Presentation.Contracts.V1.Requests;
using KT.Presentation.Contracts.V1.Responses;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace KT.Presentation.API.V1.Controllers.ModuleTemplates;

/// <summary>
/// ModuleTemplates controller.
/// </summary>
[ApiVersion("1.0")]
[Route("api/v{version:apiVersion}/[controller]")]
public class ModuleTemplatesController(ISender mediatr,  IMapper mapper) : ApiController
{
    /// <summary>
    /// List all ModuleTemplates.
    /// </summary>
    [HttpGet("")]
    [ProducesResponseType(typeof(IEnumerable<ModuleTemplateResponse>), StatusCodes.Status200OK)]
    public async Task<IActionResult> ListAsync()
    {
        await Task.CompletedTask;
        throw new NotImplementedException();
        // var query = new ListQuery();
        // var moduleTemplates = await mediatr.Send(query);

        // return Ok(mapper.Map<List<ModuleTemplateResponse>>(moduleTemplates));
    }

    /// <summary>
    /// Get a ModuleTemplate by id.
    /// </summary>
    [HttpGet("{id:guid}")]
    [ProducesResponseType(typeof(ModuleTemplateResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(void), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetAsync([FromRoute] Guid id)
    {
        await Task.CompletedTask;
        throw new NotImplementedException();
        // var query = new GetByIdQuery(id);
        // var moduleTemplate = await mediatr.Send(query);

        // return moduleTemplate.Match(
        //     moduleTemplate => Ok(mapper.Map<ModuleTemplateResponse>(moduleTemplate)),
        //     Problem);
    }

    /// <summary>
    /// Add a ModuleTemplate.
    /// </summary>
    [HttpPost("")]
    [ProducesResponseType(typeof(ModuleTemplateResponse), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(void), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(void), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> AddAsync([FromBody] AddModuleTemplateRequest request)
    {
        await Task.CompletedTask;
        throw new NotImplementedException();
        // var command = new AddModuleTemplateCommand(
        //     request.Title,
        //     request.Description,
        //     request.Code,
        //     request.Level,
        //     request.DurationInWeeks);

        // var added = await mediatr.Send(command);
        
        // return added.Match(
        //     authResult => CreatedAtAction("Get", new { id = added.Value.Id }, mapper.Map<ModuleTemplateResponse>(added.Value)),
        //     Problem);
    }

    /// <summary>
    /// Remove a module template.
    /// </summary>
    [HttpDelete("{id:guid}")]
    [ProducesResponseType(typeof(void), StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(void), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> RemoveModuleTemplateAsync([FromRoute] Guid id)
    {
        await Task.CompletedTask;
        throw new NotImplementedException();
        // var command = new RemoveModuleTemplateCommand(id);
        // var removed = await mediatr.Send(command);
        
        // return removed.Match(
        //     authResult => NoContent(),
        //     Problem);
    }
}