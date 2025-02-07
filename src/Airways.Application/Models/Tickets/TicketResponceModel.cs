using Airways.Core.Entities;

namespace Airways.Application.Models.Tickets;

public class TicketResponceModel
{
    public Guid id { get; set; }
    public double price { get; set; }
    public decimal MaxWeight { get; set; }
    public decimal AdditionalCharge { get; set; }
    DateTime OrderTime { get; set; }
    public int SeatNumber { get; set; }
    Status status { get; set; }
}
