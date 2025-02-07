using Airways.Application.Models.Airline;
using Airways.Application.Services;
using Airways.Core.Entities;
using Airways.DataAccess.Repository;
using AutoMapper;
using MediatR;

namespace Airways.Application.MediatR.AirlineHandle
{
    public record CreateAirlineCommand : IRequest<CreateAirlineResponceModel>
    {
        public AirlineCreateModel _airlineCreateModel { get; set; }

        public CreateAirlineCommand(AirlineCreateModel airlineCreateModel)
        {
            _airlineCreateModel = airlineCreateModel;
        }
    }

    public class CreateAirlineCommandHandler : IRequestHandler<CreateAirlineCommand, CreateAirlineResponceModel>
    {
        private readonly IAirlineService _airlineService;

        public CreateAirlineCommandHandler(IAirlineService airlineService)
        {
            _airlineService = airlineService;
        }

        public async Task<CreateAirlineResponceModel> Handle(CreateAirlineCommand request, CancellationToken cancellationToken)
        {
            var createdAirline = await _airlineService.CreateAsync(request._airlineCreateModel, cancellationToken);

            return new CreateAirlineResponceModel { Id = createdAirline.Id };
        }
    }

}
