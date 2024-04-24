using AutoMapper;
using KT.Application.Qualifications.Queries.GetQualifications;
using KT.Presentation.Contracts.V1.Responses;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace KT.Presentation.API.V1.Controllers;

[Route("[controller]s")]
public class QualificationController(ISender mediatr,  IMapper mapper) : ApiController
{
    [HttpGet("")]
    [ProducesResponseType(typeof(IList<QualificationResponse>), StatusCodes.Status200OK)]
    public async Task<IActionResult> ListAsync()
    {
        var query = new ListQuery();
        var qualifications = await mediatr.Send(query);
        
        var response = mapper.Map<IList<QualificationResponse>>(qualifications);
        return Ok(response);
    }
    
    [HttpGet("{id:guid}")]
    [ProducesResponseType(typeof(QualificationResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(void), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetAsync([FromRoute] Guid id)
    {
        var query = new GetByIdQuery(id);
        var qualification = await mediatr.Send(query);

        return qualification.Match(
            authResult => Ok(mapper.Map<QualificationResponse>(qualification.Value)),
            Problem
        );
    }
}