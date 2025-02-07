using Airways.Application.Models.Aircraft;
using Airways.Core.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airways.Application.MappingProfiles
{
    public class AircraftMapping : Profile
    {
        public AircraftMapping()
        {
            CreateMap<AircraftCreateModel, Aircraft>();
            CreateMap<AircraftUpdateModel, Aircraft>().ReverseMap();

            CreateMap<Aircraft, AircraftResponceModel>();
        }
    }
}
