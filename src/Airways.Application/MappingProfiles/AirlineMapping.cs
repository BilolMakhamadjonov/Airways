using Airways.Application.Models.Airline;
using Airways.Core.Entities;
using AutoMapper;

namespace Airways.Application.MappingProfiles;

public class AirlineMapping : Profile
{
    public AirlineMapping()
    {
        CreateMap<AirlineCreateModel, Airline>();

        CreateMap<AirlineUpdateModel, Airline>().ReverseMap();

        CreateMap<Airline, AirlineResponceModel>();
    }
}
