using Airways.Application.Models;
using Airways.Application.Services;
using MediatR;

namespace Airways.Application.MediatR.AirlineHandle;

public class DeleteAirlineCommand : IRequest<BaseResponceModel>
{
    public Guid Id { get; set; }

    public DeleteAirlineCommand(Guid id)
    {
        Id = id;
    }
}

public class DeleteAirlineCommandHandler : IRequestHandler<DeleteAirlineCommand, BaseResponceModel>
{
    private readonly IAirlineService _airlineService;

    public DeleteAirlineCommandHandler(IAirlineService airlineService)
    {
        _airlineService = airlineService;
    }

    public async Task<BaseResponceModel> Handle(DeleteAirlineCommand request, CancellationToken cancellationToken)
    {
        var deletedAirline = await _airlineService.DeleteAsync(request.Id, cancellationToken);

        return new BaseResponceModel { Id = deletedAirline.Id };
    }
}

