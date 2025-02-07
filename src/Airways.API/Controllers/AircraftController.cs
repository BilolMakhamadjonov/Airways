using Airways.Application.Models;
using Airways.Application.Models.Aircraft;
using Airways.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace Airways.API.Controllers
{
    public class AircraftController : ApiController
    {
        private readonly IAircraftService _aicraftService;


        public AircraftController(IAircraftService aicraftService)
        {
            _aicraftService = aicraftService;
        }

        [HttpGet]
        public async Task<ActionResult<ApiResult<List<AircraftResponceModel>>>> GetAll()
        {
            var result = await _aicraftService.GetAllAsync();
            var response = ApiResult<List<AircraftResponceModel>>.Success(result);
            return Ok(response);
        }
        [HttpPost]
        public async Task<IActionResult> CreateAsync(AircraftCreateModel createModel)
        {
            var result = await _aicraftService.CreateAsync(createModel);

            if (result == null) return BadRequest(ApiResult<AircraftCreateResponceModel>.Failure());

            return Ok(ApiResult<AircraftCreateResponceModel>.Success(result));
        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> UpdateAsync(Guid id, AircraftUpdateModel updateModel)
        {
            return Ok(ApiResult<UpdateAircraftResponceModel>.Success(
                await _aicraftService.UpdateAsync(id, updateModel)));
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> DeleteAsync(Guid id)
        {
            return Ok(ApiResult<BaseResponceModel>.Success(await _aicraftService.DeleteAsync(id)));
        }
    }
}
