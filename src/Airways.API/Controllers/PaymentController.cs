using Airways.Application.Models.Payment;
using Airways.Application.Models;
using Airways.Application.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Airways.API.Controllers
{
    public class PaymentController : ApiController
    {
        private readonly IPaymentService _paymentService;

        public PaymentController(IPaymentService paymentService)
        {
            _paymentService = paymentService;
        }
        [HttpGet]
        public async Task<ActionResult<ApiResult<List<PaymentResponceModel>>>> GetAll()
        {
            var result = await _paymentService.GetAllAsync();
            var response = ApiResult<List<PaymentResponceModel>>.Success(result);
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync(PaymentCreateModel createModel)
        {
            return Ok(ApiResult<CreatePaymentResponceModel>.Success(
                await _paymentService.CreateAsync(createModel)));
        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> UpdateAsync(Guid id, PaymentUpdateModel updateModel)
        {
            return Ok(ApiResult<UpdatePaymentResponceModel>.Success(
                await _paymentService.UpdateAsync(id, updateModel)));
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> DeleteAsync(Guid id)
        {
            return Ok(ApiResult<BaseResponceModel>.Success(await _paymentService.DeleteAsync(id)));
        }
    }
}
