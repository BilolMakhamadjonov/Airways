using Airways.Application.Models.Clas;
using Airways.Application.Models.Class;
using Airways.Application.Models.Tickets;
using Airways.Core.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airways.Application.MappingProfiles
{
    public class TicketMapping : Profile
    {
        public TicketMapping()
        {
            CreateMap<TicketCreateModel, Ticket>();
            CreateMap<TicketUpdateModel, Ticket>().ReverseMap();

            CreateMap<Ticket, TicketResponceModel>();

        }
    }
}
