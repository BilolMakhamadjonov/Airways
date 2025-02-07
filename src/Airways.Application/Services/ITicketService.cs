using Airways.Application.Models;
using Airways.Application.Models.Tickets;
using Airways.Core.Entities;

namespace Airways.Application.Services;

public interface ITicketService
{
    Task<List<TicketResponceModel>> GetAllAsync(CancellationToken cancellationToken = default);
    Task<CreateTicketResponceModel> CreateAsync(TicketCreateModel createTodoItemModel,
            CancellationToken cancellationToken = default);
    Task<BaseResponceModel> DeleteAsync(Guid id, CancellationToken cancellationToken = default);
    Task<UpdateTicketResponceModel> UpdateAsync(Guid id, TicketUpdateModel updateTodoItemModel,
        CancellationToken cancellationToken = default);
}
