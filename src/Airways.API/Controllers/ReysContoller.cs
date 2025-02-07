using Airways.Application.Models.Reys;
using Airways.Application.Models;
using Airways.Application.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Airways.Core.Entities;

namespace Airways.API.Controllers
{
    public class ReysContoller : ApiController
    {
        private readonly IReysService _reysService;

        public ReysContoller(IReysService reysService)
        {
            _reysService = reysService;
        }
        [HttpGet]
        public async Task<ActionResult<ApiResult<List<ReysResponceModel>>>> GetAll()
        {
            var result = await _reysService.GetAllAsync();
            var response = ApiResult<List<ReysResponceModel>>.Success(result);
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync(ReysCreateModel createModel)
        {
            var result = await _reysService.CreateAsync(createModel);
            return Ok(ApiResult<CreateReysResponceModel>.Success(result));

        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> UpdateAsync(Guid id, ReysUpdateModel updateModel)
        {
            return Ok(ApiResult<UpdateReysResponceModel>.Success(
                await _reysService.UpdateAsync(id, updateModel)));
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> DeleteAsync(Guid id)
        {
            return Ok(ApiResult<BaseResponceModel>.Success(await _reysService.DeleteAsync(id)));
        }
    }
}
