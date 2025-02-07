using Airways.Core.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airways.Core.Entities;

public class Aircraft : BaseEntity, IAuditedEntity
{
    public string Name { get; set; }
    public string Description { get; set; }
    public string Model { get; set; }
    public int SeatCapacity { get; set; }
    public Guid AirlineId { get; set; }
    public Airline Airline { get; set; }
    public List<Reys>? reys { get; set; }
    public string? CreatedBy { get; set; }
    public DateTime? CreatedOn { get; set; }
    public string? UpdatedBy { get; set; }
    public DateTime? UpdatedOn { get; set; }
}
