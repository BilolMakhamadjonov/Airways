using Airways.Application.Models;
using Airways.Application.Models.Clas;
using Airways.Application.Models.Class;

namespace Airways.Application.Services;

public interface IClassService
{
    Task<List<ClassResponceModel>> GetAllAsync(CancellationToken cancellationToken = default);

    Task<CreateClassResponceModel> CreateAsync(ClassCreateModel createTodoItemModel,
  CancellationToken cancellationToken = default);

    Task<BaseResponceModel> DeleteAsync(Guid id, CancellationToken cancellationToken = default);

    Task<IEnumerable<ClassResponceModel>>
        GetAllByListIdAsync(Guid id, CancellationToken cancellationToken = default);

    Task<UpdateClassResponceModel> UpdateAsync(Guid id, ClassUpdateModel updateTodoItemModel,
        CancellationToken cancellationToken = default);
}
