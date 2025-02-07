using Airways.Application.Models.Clas;
using Airways.Application.Models.Class;
using Airways.Application.Models.Payment;
using Airways.Core.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airways.Application.MappingProfiles
{
    public class PaymentMapping : Profile
    {
        public PaymentMapping()
        {
            CreateMap<PaymentCreateModel, Payment>();
            CreateMap<PaymentUpdateModel, Payment>().ReverseMap();

            CreateMap<Payment, PaymentResponceModel>();

        }
    }
}
