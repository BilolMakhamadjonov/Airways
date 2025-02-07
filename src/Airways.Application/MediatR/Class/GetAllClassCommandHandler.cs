using Airways.Application.Models.Airline;
using Airways.Application.Models.Class;
using Airways.DataAccess.Repository;
using AutoMapper;
using MediatR;

namespace Airways.Application.MediatR.Class
{
    public class GetAllClassCommand : IRequest<List<ClassResponceModel>> { }

    public class GetAllClassCommandHandler : IRequestHandler<GetAllClassCommand, List<ClassResponceModel>>
    {
        private readonly IClassRepository _classRepository;
        private readonly IMapper _mapper;

        public GetAllClassCommandHandler(IClassRepository classRepository, IMapper mapper)
        {
            _classRepository = classRepository;
            _mapper = mapper;
        }

        public async Task<List<ClassResponceModel>> Handle(GetAllClassCommand request, CancellationToken cancellationToken)
        {
            var classes = await _classRepository.GetAllAsync();
            return _mapper.Map<List<ClassResponceModel>>(classes);
        }
    }
}
