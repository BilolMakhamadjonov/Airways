﻿using Airways.Application.Models.Airline;
using Airways.Application.Models;
using Airways.Core.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Airways.DataAccess.Repository;

namespace Airways.Application.Services.Impl;

public class AirlineService : IAirlineService
{
    private readonly IMapper _mapper;
    private readonly IAirlineRepository _airlineRepository;


    public AirlineService(IAirlineRepository airlineRepository,
        IMapper mapper)
    {
        _airlineRepository = airlineRepository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<AirlineResponceModel>> GetAllByListIdAsync(Guid id,
        CancellationToken cancellationToken = default)
    {
        var todoItems = await _airlineRepository.GetAllAsync(ti => ti.Id == id);

        return _mapper.Map<IEnumerable<AirlineResponceModel>>(todoItems);
    }

    public async Task<CreateAirlineResponceModel> CreateAsync(AirlineCreateModel createTodoItemModel,
        CancellationToken cancellationToken = default)
    {
        var todoItem = _mapper.Map<Airline>(createTodoItemModel);


        return new CreateAirlineResponceModel
        {
            Id = (await _airlineRepository.AddAsync(todoItem)).Id
        };
    }

    public async Task<UpdateAirlineResponceModel> UpdateAsync(Guid id, AirlineUpdateModel updateTodoItemModel,
        CancellationToken cancellationToken = default)
    {
        var todoItem = await _airlineRepository.GetFirstAsync(ti => ti.Id == id);

        _mapper.Map(updateTodoItemModel, todoItem);

        return new UpdateAirlineResponceModel
        {
            Id = (await _airlineRepository.UpdateAsync(todoItem)).Id
        };
    }

    public async Task<List<AirlineResponceModel>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        var result = await _airlineRepository.GetAllAsync();

        var mapper = _mapper.Map<List<AirlineResponceModel>>(result);
        return mapper;
    }

    public async Task<BaseResponceModel> DeleteAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var todoItem = await _airlineRepository.GetFirstAsync(ti => ti.Id == id);

        return new BaseResponceModel
        {
            Id = (await _airlineRepository.DeleteAsync(todoItem)).Id
        };
    }
}
