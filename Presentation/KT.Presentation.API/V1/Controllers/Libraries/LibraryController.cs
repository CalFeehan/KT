using AutoMapper;
using KT.Application.Libraries.Commands.Create;
using KT.Application.Libraries.Commands.Delete;
using KT.Application.Libraries.Queries.GetCourse;
using KT.Presentation.Contracts.V1.Requests;
using KT.Presentation.Contracts.V1.Responses;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace KT.Presentation.API.V1.Controllers.Libraries;

[Route("libraries")]
public class LibraryController(ISender mediatr,  IMapper mapper) : ApiController
{
    [HttpGet("")]
    [ProducesResponseType(typeof(IList<LibraryResponse>), StatusCodes.Status200OK)]
    public async Task<IActionResult> ListAsync()
    {
        var query = new ListQuery();
        var libraries = await mediatr.Send(query);

        return Ok(mapper.Map<IList<LibraryResponse>>(libraries));
    }
    
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

    [HttpPost("")]
    [ProducesResponseType(typeof(LibraryResponse), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(void), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> CreateAsync([FromBody] CreateLibraryRequest request)
    {
        var command = new CreateCommand();

        var created = await mediatr.Send(command);
        
        return created.Match(
            authResult => CreatedAtAction(nameof(GetAsync), new { id = created.Value.Id }, mapper.Map<LibraryResponse>(created.Value)),
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