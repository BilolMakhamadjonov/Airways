using Airways.Core.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airways.Core.Entities;

public class Order : BaseEntity, IAuditedEntity
{
    public decimal TotalPrice { get; set; }
    public Guid UserId { get; set; }
    public User User { get; set; }
    public Guid TicketsId { get; set; }
    public Ticket Ticket { get; set; }
    public List<Payment> Payment = new List<Payment>();
    public string? CreatedBy { get; set; }
    public DateTime? CreatedOn { get; set; }
    public string? UpdatedBy { get; set; }
    public DateTime? UpdatedOn { get; set; }
}
