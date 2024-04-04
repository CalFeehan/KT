using KT.Application.Students.Commands;
using KT.Presentation.Contracts.V1.Responses;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace KT.Presentation.API.V1.Controllers;

[ApiController]
[Route("[controller]")]
public class StudentController(ISender mediatr) : ControllerBase
{
    private readonly ISender _mediatr = mediatr;

    // TODO: Remove the name portion of this and further logic.
    [HttpGet("")]
    public async Task<IActionResult> ListAsync(
        [FromQuery] string forename, [FromQuery] string surname)
    {
        await Task.Delay(10);
        return Ok();
    }
    
    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetAsync(Guid id)
    {
        await Task.Delay(10);
        return Ok();
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> DeleteAsync(Guid id)
    {
        var command = new DeleteCommand(id);
        var deleted = await _mediatr.Send(command);
        return NoContent();
    }
}