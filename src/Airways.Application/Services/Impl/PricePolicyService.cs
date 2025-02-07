using Airways.Application.Models.PricePolicy;
using Airways.Application.Models;
using Airways.Core.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Airways.DataAccess.Repository;
using Airways.Application.Models.Order;
using Airways.Application.Models.Payment;
using Airways.DataAccess.Repository.Impl;

namespace Airways.Application.Services.Impl
{
    public class PricePolicyService : IPricePolicyService
    {
        private readonly IMapper _mapper;
        private readonly IPricePolyceRepository _pricepolicyRepository;

        public PricePolicyService(IPricePolyceRepository pricepolicyRepository,
            IMapper mapper)
        {
            _pricepolicyRepository = pricepolicyRepository;
            _mapper = mapper;
        }

        public async Task<List<PricePolicyResponceModel>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            var result = await _pricepolicyRepository.GetAllAsync();

            var mapper = _mapper.Map<List<PricePolicyResponceModel>>(result);
            return mapper;
        }

        public async Task<IEnumerable<PricePolicyResponceModel>> GetAllByListIdAsync(Guid id,
            CancellationToken cancellationToken = default)
        {
            var todoItems = await _pricepolicyRepository.GetAllAsync(ti => ti.Id == id);

            return _mapper.Map<IEnumerable<PricePolicyResponceModel>>(todoItems);
        }

        public async Task<CreatePricePolicyResponceModel> CreateAsync(PricePolicyCreateModel createTodoItemModel,
            CancellationToken cancellationToken = default)
        {
            var todoItem = _mapper.Map<PricePolicy>(createTodoItemModel);


            return new CreatePricePolicyResponceModel
            {
                Id = (await _pricepolicyRepository.AddAsync(todoItem)).Id
            };
        }

        public async Task<UpdatePricePolicyResponceModel> UpdateAsync(Guid id, PricePolicyUpdateModel updateTodoItemModel,
            CancellationToken cancellationToken = default)
        {
            var todoItem = await _pricepolicyRepository.GetFirstAsync(ti => ti.Id == id);

            _mapper.Map(updateTodoItemModel, todoItem);

            return new UpdatePricePolicyResponceModel
            {
                Id = (await _pricepolicyRepository.UpdateAsync(todoItem)).Id
            };
        }

        public async Task<BaseResponceModel> DeleteAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var todoItem = await _pricepolicyRepository.GetFirstAsync(ti => ti.Id == id);

            return new BaseResponceModel
            {
                Id = (await _pricepolicyRepository.DeleteAsync(todoItem)).Id
            };
        }
    }
}
