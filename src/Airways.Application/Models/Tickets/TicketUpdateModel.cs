using Airways.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airways.Application.Models.Tickets;

public class TicketUpdateModel
{
    public double price { get; set; }
    public decimal MaxWeight { get; set; }
    public decimal AdditionalCharge { get; set; }
    DateTime OrderTime { get; set; }
    public int SeatNumber { get; set; }
    public Status status { get; set; }
    public Guid Reys_id { get; set; }
    public Guid User_id { get; set; }
    public Guid Cllass_id { get; set; }
    public Guid PricePolicy_id { get; set; }
}
public class UpdateTicketResponceModel : BaseResponceModel { }

