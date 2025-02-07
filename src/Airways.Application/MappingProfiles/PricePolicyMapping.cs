using Airways.Application.Models.Clas;
using Airways.Application.Models.Class;
using Airways.Application.Models.PricePolicy;
using Airways.Core.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airways.Application.MappingProfiles
{
    public class PricePolicyMapping : Profile
    {
        public PricePolicyMapping()
        {
            CreateMap<PricePolicyCreateModel, PricePolicy>();
            CreateMap<PricePolicyUpdateModel, PricePolicy>().ReverseMap();

            CreateMap<PricePolicy, PricePolicyResponceModel>();

        }
    }
}
