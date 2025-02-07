using Airways.Core.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airways.Core.Entities;

public class PricePolicy : BaseEntity, IAuditedEntity
{
    public decimal DiscountPercentage { get; set; }
    public string Conditions { get; set; }
    public List<Ticket> tickets = new List<Ticket>();
    public string? CreatedBy { get; set; }
    public DateTime? CreatedOn { get; set; }
    public string? UpdatedBy { get; set; }
    public DateTime? UpdatedOn { get; set; }
}
