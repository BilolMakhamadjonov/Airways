using Airways.Application.MediatR.AirlineHandle;
using Airways.Application.Models;
using Airways.Application.Models.Airline;
using Airways.Application.Services;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Airways.API.Controllers;

public class AirlineController : ApiController
{
    private readonly IMediator _mediator;
    private readonly IAirlineService _airlineService;

    public AirlineController(IMediator mediator, IAirlineService airlineService)
    {
        _mediator = mediator;
        _airlineService = airlineService;
    }

    [HttpGet]
    public async Task<ActionResult<ApiResult<List<AirlineResponceModel>>>> GetAll()
    {
        var result = await _airlineService.GetAllAsync();
        var response = ApiResult<List<AirlineResponceModel>>.Success(result);
        return Ok(response);
    }

    [HttpPost("Create")]
    public async Task<IActionResult> CreateAsync([FromBody] AirlineCreateModel createAirlineModel)
    {
        var result = await _mediator.Send(new CreateAirlineCommand(createAirlineModel));
        return Ok(ApiResult<CreateAirlineResponceModel>.Success(result));
    }

    [HttpPut("Update{id}")]
    public async Task<IActionResult> UpdateAsync(Guid id, AirlineUpdateModel updateAirlineModel)
    {
        var result = await _mediator.Send(new UpdateAirlineCommand(id, updateAirlineModel));
        return Ok(ApiResult<UpdateAirlineResponceModel>.Success(result));
    }

    [HttpDelete("Delete{id}")]
    public async Task<IActionResult> DeleteAsync(Guid id)
    {
        var result = await _mediator.Send(new DeleteAirlineCommand(id));
        return Ok(ApiResult<BaseResponceModel>.Success(result));
    }
}

