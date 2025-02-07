using Airways.Core.Entities;

namespace Airways.Application.Models.Tickets;

public class TicketCreateModel
{
    public double price { get; set; }
    public decimal MaxWeight { get; set; }
    public decimal AdditionalCharge { get; set; }
    public DateTime OrderTime { get; set; }
    public DateTime? ExpirationTime { get; set; } // Bron tugashi voxti
    public int SeatNumber { get; set; }
    public Status status { get; set; }
    public Guid Reys_id { get; set; }
    public Guid User_id { get; set; }
    public Guid Class_id { get; set; }
    public Guid PricePolicy_id { get; set; }
    public int TicketCount { get; set; }

}
public class CreateTicketResponceModel : BaseResponceModel { }


