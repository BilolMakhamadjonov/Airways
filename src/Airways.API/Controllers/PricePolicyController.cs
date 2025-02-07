using Airways.Application.Models.PricePolicy;
using Airways.Application.Models;
using Airways.Application.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Airways.API.Controllers
{
    [Authorize(Policy = "Admin")]
    [Route("api/pricepolicy")]
    public class PricePolicyController : ApiController
    {
        private readonly IPricePolicyService _pricepolicyService;

        public PricePolicyController(IPricePolicyService pricepolicyService)
        {
            _pricepolicyService = pricepolicyService;
        }

        [HttpGet]
        public async Task<ActionResult<ApiResult<List<PricePolicyResponceModel>>>> GetAll()
        {
            var result = await _pricepolicyService.GetAllAsync();
            var response = ApiResult<List<PricePolicyResponceModel>>.Success(result);
            return Ok(response);
        }
        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> CreateAsync(PricePolicyCreateModel createModel)
        {
            return Ok(ApiResult<CreatePricePolicyResponceModel>.Success(
                await _pricepolicyService.CreateAsync(createModel)));
        }
        [HttpPut("{id:guid}")]
        public async Task<IActionResult> UpdateAsync(Guid id, PricePolicyUpdateModel updateModel)
        {
            return Ok(ApiResult<UpdatePricePolicyResponceModel>.Success(
                await _pricepolicyService.UpdateAsync(id, updateModel)));
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> DeleteAsync(Guid id)
        {
            return Ok(ApiResult<BaseResponceModel>.Success(await _pricepolicyService.DeleteAsync(id)));
        }
    }
}
