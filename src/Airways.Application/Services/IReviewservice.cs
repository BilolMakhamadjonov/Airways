using Airways.Application.Models.Review;
using Airways.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Airways.Application.Models.PricePolicy;

namespace Airways.Application.Services
{
    public interface IReviewservice
    {
        Task<List<ReviewResponceModel>> GetAllAsync(CancellationToken cancellationToken = default);

        Task<CreateReviewResponceModel> CreateAsync(ReviewCreateModel createTodoItemModel,
      CancellationToken cancellationToken = default);

        Task<BaseResponceModel> DeleteAsync(Guid id, CancellationToken cancellationToken = default);

        Task<IEnumerable<ReviewResponceModel>>
            GetAllByListIdAsync(Guid id, CancellationToken cancellationToken = default);

        Task<UpdateReviewResponceModel> UpdateAsync(Guid id, ReviewUpdateModel updateTodoItemModel,
            CancellationToken cancellationToken = default);
    }
}
