using Airways.Application.Models.Airline;
using Airways.Application.Services;
using MediatR;

namespace Airways.Application.MediatR.AirlineHandle;

public class UpdateAirlineCommand : IRequest<UpdateAirlineResponceModel>
{
    public Guid Id { get; set; }
    public AirlineUpdateModel AirlineUpdateModel { get; set; }

    public UpdateAirlineCommand(Guid id, AirlineUpdateModel airlineUpdateModel)
    {
        Id = id;
        AirlineUpdateModel = airlineUpdateModel;
    }
}

public class UpdateAirlineCommandHandler : IRequestHandler<UpdateAirlineCommand, UpdateAirlineResponceModel>
{
    private readonly IAirlineService _airlineService;

    public UpdateAirlineCommandHandler(IAirlineService airlineService)
    {
        _airlineService = airlineService;
    }

    public async Task<UpdateAirlineResponceModel> Handle(UpdateAirlineCommand request, CancellationToken cancellationToken)
    {
        var updatedAirline = await _airlineService.UpdateAsync(request.Id, request.AirlineUpdateModel, cancellationToken);

        return new UpdateAirlineResponceModel { Id = updatedAirline.Id };
    }
}
