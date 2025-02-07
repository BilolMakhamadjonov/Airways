using Airways.Application.Models.Aircraft;
using Airways.Application.Models.Clas;
using Airways.Application.Models.Class;
using Airways.Core.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airways.Application.MappingProfiles
{
    public class ClassMapping : Profile
    {
        public ClassMapping()
        {
            CreateMap<ClassCreateModel, Class>();
            CreateMap<ClassUpdateModel, Class>().ReverseMap();

            CreateMap<Class, ClassResponceModel>();

        }
    }
}