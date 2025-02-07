using Airways.Core.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airways.Core.Entities;

public class Reys : BaseEntity, IAuditedEntity
{
    public int TicketCount { get; set; }
    public string DepartureCity { get; set; }
    public string ArrivalCity { get; set; }
    public DateTime ScheduledDepartureTime { get; set; }
    public DateTime ActualDepartureTime { get; set; }
    public DateTime ScheduledArrivalTime { get; set; }
    public Guid AirlineId { get; set; }
    public Airline Airline { get; set; }
    public Guid AicraftId { get; set; }
    public Aircraft Aircraft { get; set; }
    public List<Review> review = new List<Review>();
    public List<Ticket> tickets = new List<Ticket>();
    public string? CreatedBy { get; set; }
    public DateTime? CreatedOn { get; set; }
    public string? UpdatedBy { get; set; }
    public DateTime? UpdatedOn { get; set; }
}
