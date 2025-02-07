using Airways.Application.MediatR.Class;
using Airways.Application.Models;
using Airways.Application.Models.Clas;
using Airways.Application.Models.Class;
using Airways.Application.Services;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Airways.API.Controllers;

public class ClassController : ApiController
{
    private readonly IMediator _mediator;
    private readonly IClassService _classService;

    public ClassController(IMediator mediator, IClassService classService)
    {
        _mediator = mediator;
        _classService = classService;
    }

    [HttpGet]
    public async Task<ActionResult<ApiResult<List<ClassResponceModel>>>> GetAll()
    {
        var result = await _classService.GetAllAsync();
        var response = ApiResult<List<ClassResponceModel>>.Success(result);
        return Ok(response);
    }

    [HttpPost("Create")]
    public async Task<IActionResult> CreateAsync([FromBody] ClassCreateModel createClassModel)
    {
        var result = await _mediator.Send(new CreateClassCommand(createClassModel));
        return Ok(ApiResult<CreateClassResponceModel>.Success(result));
    }

    [HttpPut("Update{id}")]
    public async Task<IActionResult> UpdateAsync(Guid id, ClassUpdateModel updateClassModel)
    {
        var result = await _mediator.Send(new UpdateClassCommand(id, updateClassModel));
        return Ok(ApiResult<UpdateClassResponceModel>.Success(result));
    }

    [HttpDelete("Delete{id}")]
    public async Task<IActionResult> DeleteAsync(Guid id)
    {
        var result = await _mediator.Send(new DeleteClassCommand(id));
        return Ok(ApiResult<BaseResponceModel>.Success(result));
    }
}
