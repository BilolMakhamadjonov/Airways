using Airways.Application.Models.Clas;
using Airways.Application.Models.Class;
using Airways.Application.Models.Review;
using Airways.Core.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airways.Application.MappingProfiles
{
    public class ReviewMapping : Profile
    {
        public ReviewMapping()
        {
            CreateMap<ReviewCreateModel, Review>();
            CreateMap<ReviewUpdateModel, Review>().ReverseMap();

            CreateMap<Review, ReviewResponceModel>();

        }
    }
}
