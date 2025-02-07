using Airways.Application.Models.Reys;
using Airways.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Airways.Application.Models.Review;

namespace Airways.Application.Services
{
    public interface IReysService
    {
        Task<List<ReysResponceModel>> GetAllAsync(CancellationToken cancellationToken = default);

        Task<CreateReysResponceModel> CreateAsync(ReysCreateModel createTodoItemModel,
      CancellationToken cancellationToken = default);

        Task<BaseResponceModel> DeleteAsync(Guid id, CancellationToken cancellationToken = default);

        Task<IEnumerable<ReysResponceModel>>
            GetAllByListIdAsync(Guid id, CancellationToken cancellationToken = default);

        Task<UpdateReysResponceModel> UpdateAsync(Guid id, ReysUpdateModel updateTodoItemModel,
            CancellationToken cancellationToken = default);
    }
}
