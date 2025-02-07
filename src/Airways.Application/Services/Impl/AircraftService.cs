using Airways.Application.DTO;
using Airways.Application.Models;
using Airways.Application.Models.Aircraft;
using Airways.Core.Entities;
using Airways.DataAccess.Repository;
using Airways.DataAccess.Repository.Impl;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace Airways.Application.Services.Impl
{
    public class AircraftService : IAircraftService
    {
        private readonly IMapper _mapper;
        private readonly IAircraftRepository _aircraftRepository;

        public AircraftService(IAircraftRepository aircraftRepository,
            IMapper mapper)
        {
            _aircraftRepository = aircraftRepository;
            _mapper = mapper;
        }


        public async Task<List<AircraftResponceModel>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            var result = await _aircraftRepository.GetAllAsync();

            var mapper = _mapper.Map<List<AircraftResponceModel>>(result);
            return mapper;
        }

        public async Task<IEnumerable<AircraftResponceModel>> GetAllByListIdAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var todoItems = await _aircraftRepository.GetAllAsync(ti => ti.Id == id);


            return (IEnumerable<AircraftResponceModel>)_mapper.Map<AircraftResponceModel>(todoItems);
        }

        public async Task<AircraftCreateResponceModel> CreateAsync(AircraftCreateModel createModel,
            CancellationToken cancellationToken = default)
        {
            var todoItem = _mapper.Map<Aircraft>(createModel);
            var result = await _aircraftRepository.AddAsync(todoItem);

            if (result == null) return null;

            return new AircraftCreateResponceModel
            {
                Id = result.Id
            };
        }

        public async Task<UpdateAircraftResponceModel> UpdateAsync(Guid id, AircraftUpdateModel updateTodoItemModel,
            CancellationToken cancellationToken = default)
        {
            var todoItem = await _aircraftRepository.GetFirstAsync(ti => ti.Id == id);

            _mapper.Map(updateTodoItemModel, todoItem);

            return new UpdateAircraftResponceModel
            {
                Id = (await _aircraftRepository.UpdateAsync(todoItem)).Id
            };
        }

        public async Task<BaseResponceModel> DeleteAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var todoItem = await _aircraftRepository.GetFirstAsync(ti => ti.Id == id);

            return new BaseResponceModel
            {
                Id = (await _aircraftRepository.DeleteAsync(todoItem)).Id
            };
        }
    }
}
