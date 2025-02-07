using Airways.Application.Models;
using Airways.Application.Models.Payment;
using Airways.Application.Models.PricePolicy;

namespace Airways.Application.Services
{
    public interface IPricePolicyService
    {
        Task<List<PricePolicyResponceModel>> GetAllAsync(CancellationToken cancellationToken = default);

        Task<CreatePricePolicyResponceModel> CreateAsync(PricePolicyCreateModel createTodoItemModel,
      CancellationToken cancellationToken = default);

        Task<BaseResponceModel> DeleteAsync(Guid id, CancellationToken cancellationToken = default);

        Task<IEnumerable<PricePolicyResponceModel>>
            GetAllByListIdAsync(Guid id, CancellationToken cancellationToken = default);

        Task<UpdatePricePolicyResponceModel> UpdateAsync(Guid id, PricePolicyUpdateModel updateTodoItemModel,
            CancellationToken cancellationToken = default);
    }
}
