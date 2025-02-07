using Airways.Application.Models.Order;
using Airways.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Airways.Application.Models.Class;

namespace Airways.Application.Services
{
    public interface IOrderService
    {
        Task<List<OrderResponceModel>> GetAllAsync(CancellationToken cancellationToken = default);

        Task<CreateOrderResponceModel> CreateAsync(OrderCreateModel createTodoItemModel,
      CancellationToken cancellationToken = default);

        Task<BaseResponceModel> DeleteAsync(Guid id, CancellationToken cancellationToken = default);

        Task<UpdateOrderResponceModel> UpdateAsync(Guid id, OrderUpdateModel updateTodoItemModel,
            CancellationToken cancellationToken = default);
    }
}
