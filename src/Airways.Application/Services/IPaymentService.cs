using Airways.Application.Models.Payment;
using Airways.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Airways.Application.Models.Order;

namespace Airways.Application.Services
{
    public interface IPaymentService
    {
        Task<List<PaymentResponceModel>> GetAllAsync(CancellationToken cancellationToken = default);

        Task<CreatePaymentResponceModel> CreateAsync(PaymentCreateModel createTodoItemModel,
      CancellationToken cancellationToken = default);

        Task<BaseResponceModel> DeleteAsync(Guid id, CancellationToken cancellationToken = default);

        Task<IEnumerable<PaymentResponceModel>>
            GetAllByListIdAsync(Guid id, CancellationToken cancellationToken = default);

        Task<UpdatePaymentResponceModel> UpdateAsync(Guid id, PaymentUpdateModel updateTodoItemModel,
            CancellationToken cancellationToken = default);
    }
}
