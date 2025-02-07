using Airways.Application.Models;
using Airways.Application.Services;
using MediatR;

namespace Airways.Application.MediatR.Class;

public class DeleteClassCommand : IRequest<BaseResponceModel>
{
    public Guid Id { get; set; }

    public DeleteClassCommand(Guid id)
    {
        Id = id;
    }
}

public class DeleteClassCommandHandler : IRequestHandler<DeleteClassCommand, BaseResponceModel>
{
    private readonly IClassService _classService;

    public DeleteClassCommandHandler(IClassService classService)
    {
        _classService = classService;
    }

    public async Task<BaseResponceModel> Handle(DeleteClassCommand request, CancellationToken cancellationToken)
    {
        var deletedClass = await _classService.DeleteAsync(request.Id, cancellationToken);

        return new BaseResponceModel { Id = deletedClass.Id };
    }
}
