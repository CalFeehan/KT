using AutoMapper;
using KT.Application.Students.Commands;
using KT.Application.Students.Queries.GetStudents;
using KT.Presentation.Contracts.V1.Responses;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace KT.Presentation.API.V1.Controllers;

[Route("[controller]s")]
public class StudentController(ISender mediatr,  IMapper mapper) : ApiController
{
    [HttpGet("")]
    [ProducesResponseType(typeof(IList<StudentResponse>), StatusCodes.Status200OK)]
    public async Task<IActionResult> ListAsync()
    {
        var query = new ListQuery();
        var students = await mediatr.Send(query);
        
        var response = mapper.Map<IList<StudentResponse>>(students);
        return Ok(response);
    }
    
    [HttpGet("{id:guid}")]
    [ProducesResponseType(typeof(StudentResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(void), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetAsync([FromRoute] Guid id)
    {
        var query = new GetByIdQuery(id);
        var student = await mediatr.Send(query);

        return student.Match(
            authResult => Ok(mapper.Map<StudentResponse>(student.Value)),
            Problem
        );
    }

    [HttpDelete("{id:guid}")]
    [ProducesResponseType(typeof(void), StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(void), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> DeleteAsync(Guid id)
    {
        var command = new DeleteCommand(id);
        var deleted = await mediatr.Send(new DeleteCommand(id));
        
        return deleted.Match(
            authResult => NoContent(),
            Problem);
    }
}