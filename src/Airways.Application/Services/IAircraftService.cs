using Airways.Application.DTO;
using Airways.Application.Models;
using Airways.Application.Models.Aircraft;

namespace Airways.Application.Services
{
    public interface IAircraftService
    {
        Task<AircraftCreateResponceModel> CreateAsync(AircraftCreateModel createTodoItemModel,
      CancellationToken cancellationToken = default);

        Task<List<AircraftResponceModel>> GetAllAsync(CancellationToken cancellationToken = default);
        Task<BaseResponceModel> DeleteAsync(Guid id, CancellationToken cancellationToken = default);

        Task<IEnumerable<AircraftResponceModel>>
            GetAllByListIdAsync(Guid id, CancellationToken cancellationToken = default);

        Task<UpdateAircraftResponceModel> UpdateAsync(Guid id, AircraftUpdateModel updateTodoItemModel,
            CancellationToken cancellationToken = default);

    }
}
