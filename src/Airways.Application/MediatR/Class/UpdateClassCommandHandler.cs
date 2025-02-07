using Airways.Application.Models.Airline;
using Airways.Application.Models.Clas;
using Airways.Application.Services;
using MediatR;

namespace Airways.Application.MediatR.Class;

public class UpdateClassCommand : IRequest<UpdateClassResponceModel>
{
    public Guid Id { get; set; }
    public ClassUpdateModel _classUpdateModel { get; set; }

    public UpdateClassCommand(Guid id, ClassUpdateModel classUpdateModel)
    {
        Id = id;
        _classUpdateModel = classUpdateModel;
    }
}

public class UpdateClassCommandHandler : IRequestHandler<UpdateClassCommand, UpdateClassResponceModel>
{
    private readonly IClassService _classService;

    public UpdateClassCommandHandler(IClassService classService)
    {
        _classService = classService;
    }

    public async Task<UpdateClassResponceModel> Handle(UpdateClassCommand request, CancellationToken cancellationToken)
    {
        var updatedClass = await _classService.UpdateAsync(request.Id, request._classUpdateModel, cancellationToken);

        return new UpdateClassResponceModel { Id = updatedClass.Id };
    }
}
