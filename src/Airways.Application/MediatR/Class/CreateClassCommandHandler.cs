using Airways.Application.Models.Clas;
using Airways.Application.Services;
using MediatR;

namespace Airways.Application.MediatR.Class;

public record CreateClassCommand : IRequest<CreateClassResponceModel>
{
    public ClassCreateModel _classCreateModel { get; set; }

    public CreateClassCommand(ClassCreateModel classCreateModel)
    {
        _classCreateModel = classCreateModel;
    }
}

public class CreateClassCommandHandler : IRequestHandler<CreateClassCommand, CreateClassResponceModel>
{
    private readonly IClassService _classService;

    public CreateClassCommandHandler(IClassService classService)
    {
        _classService = classService;
    }

    public async Task<CreateClassResponceModel> Handle(CreateClassCommand request, CancellationToken cancellationToken)
    {
        var createdClass = await _classService.CreateAsync(request._classCreateModel, cancellationToken);

        return new CreateClassResponceModel { Id = createdClass.Id };
    }
}
