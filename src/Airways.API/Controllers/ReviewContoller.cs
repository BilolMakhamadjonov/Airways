using Airways.Application.Models.Review;
using Airways.Application.Models;
using Airways.Application.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Airways.API.Controllers
{
    public class ReviewContoller : ApiController
    {
        private readonly IReviewservice _reviewService;

        public ReviewContoller(IReviewservice reviewService)
        {
            _reviewService = reviewService;
        }
        [HttpGet]
        public async Task<ActionResult<ApiResult<List<ReviewResponceModel>>>> GetAll()
        {
            var result = await _reviewService.GetAllAsync();
            var response = ApiResult<List<ReviewResponceModel>>.Success(result);
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync(ReviewCreateModel createModel)
        {
            return Ok(ApiResult<CreateReviewResponceModel>.Success(
                await _reviewService.CreateAsync(createModel)));
        }
        [HttpPut("{id:guid}")]
        public async Task<IActionResult> UpdateAsync(Guid id, ReviewUpdateModel updateModel)
        {
            return Ok(ApiResult<UpdateReviewResponceModel>.Success(
                await _reviewService.UpdateAsync(id, updateModel)));
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> DeleteAsync(Guid id)
        {
            return Ok(ApiResult<BaseResponceModel>.Success(await _reviewService.DeleteAsync(id)));
        }
    }
}
