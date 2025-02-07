using Airways.Application.Models.Airline;
using Airways.DataAccess.Repository;
using AutoMapper;
using MediatR;

namespace Airways.Application.MediatR.AirlineHandle
{
    public class GetAllAirlinesCommand : IRequest<List<AirlineResponceModel>> { }

    public class GetAllAirlinesCommandHandler : IRequestHandler<GetAllAirlinesCommand, List<AirlineResponceModel>>
    {
        private readonly IAirlineRepository _airlineRepository;
        private readonly IMapper _mapper;

        public GetAllAirlinesCommandHandler(IAirlineRepository airlineRepository, IMapper mapper)
        {
            _airlineRepository = airlineRepository;
            _mapper = mapper;
        }

        public async Task<List<AirlineResponceModel>> Handle(GetAllAirlinesCommand request, CancellationToken cancellationToken)
        {
            var airlines = await _airlineRepository.GetAllAsync();
            return _mapper.Map<List<AirlineResponceModel>>(airlines);
        }
    }
}
