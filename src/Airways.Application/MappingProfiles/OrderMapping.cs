using Airways.Application.Models.Clas;
using Airways.Application.Models.Class;
using Airways.Application.Models.Order;
using Airways.Core.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airways.Application.MappingProfiles
{
    public class OrderMapping : Profile
    {
        public OrderMapping()
        {
            CreateMap<OrderCreateModel, Order>();
            CreateMap<OrderUpdateModel, Order>().ReverseMap();

            CreateMap<Order, OrderResponceModel>();

        }
    }
}
