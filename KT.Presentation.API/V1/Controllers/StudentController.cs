using AutoMapper;
using KT.Application.Students.Commands;
using KT.Application.Students.Queries.GetStudents;
using KT.Presentation.Contracts.V1.Responses;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace KT.Presentation.API.V1.Controllers;

[ApiController]
[Route("[controller]")]
public class StudentController(ISender mediatr,  IMapperBase mapper) : ControllerBase
{
    [HttpGet("")]
    public async Task<IActionResult> ListAsync()
    {
        var query = new ListQuery();
        var students = await mediatr.Send(query);
        
        var response = mapper.Map<IList<StudentResponse>>(students);
        return Ok(response);
    }
    
    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetAsync(Guid id)
    {
        var query = new GetByIdQuery(id);
        var student = await mediatr.Send(query);

        var response = mapper.Map<StudentResponse>(student);
        return Ok(response);
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> DeleteAsync(Guid id)
    {
        var command = new DeleteCommand(id);
        var deleted = await mediatr.Send(command);
        
        return deleted > 0 ? NoContent() : NotFound();
    }
}