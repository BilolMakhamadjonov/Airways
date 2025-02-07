using Airways.Application.Models.Tickets;
using Airways.Application.Models;
using Airways.Application.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Airways.API.Controllers
{
    public class TicketContoller : ApiController
    {
        private readonly ITicketService _ticketService;
        private readonly IPaymentService paymentService;

        public TicketContoller(ITicketService ticketService)
        {
            _ticketService = ticketService;
        }
        [HttpGet]
        public async Task<ActionResult<ApiResult<List<TicketResponceModel>>>> GetAll()
        {
            var result = await _ticketService.GetAllAsync();
            var response = ApiResult<List<TicketResponceModel>>.Success(result);
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync(TicketCreateModel createModel)
        {
            var result = await _ticketService.CreateAsync(createModel);
            return Ok(ApiResult<CreateTicketResponceModel>.Success(result));

        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> UpdateAsync(Guid id, TicketUpdateModel updateModel)
        {
            return Ok(ApiResult<UpdateTicketResponceModel>.Success(
                await _ticketService.UpdateAsync(id, updateModel)));
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> DeleteAsync(Guid id)
        {
            return Ok(ApiResult<BaseResponceModel>.Success(await _ticketService.DeleteAsync(id)));
        }
    }
}
