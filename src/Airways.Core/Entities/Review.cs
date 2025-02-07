using Airways.Core.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airways.Core.Entities;

public class Review : BaseEntity, IAuditedEntity
{
    public int Rating { get; set; }
    public string Comment { get; set; }
    public Guid UserId { get; set; }
    public User User { get; set; }
    public Guid ReysId { get; set; }
    public Reys Reys { get; set; }
    public string? CreatedBy { get; set; }
    public DateTime? CreatedOn { get; set; }
    public string? UpdatedBy { get; set; }
    public DateTime? UpdatedOn { get; set; }
}
