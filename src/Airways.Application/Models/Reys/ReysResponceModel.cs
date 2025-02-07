using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airways.Application.Models.Reys;

public class ReysResponceModel
{
    public Guid id { get; set; }
    public int TicketCount { get; set; }
    public string DepartureCity { get; set; }
    public string ArrivalCity { get; set; }
    public DateTime ScheduledDepartureTime { get; set; }
    public DateTime ActualDepartureTime { get; set; }
    public DateTime ScheduledArrivalTime { get; set; }
}
