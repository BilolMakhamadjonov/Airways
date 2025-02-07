using Airways.Core.Common;

namespace Airways.Core.Entities;

public class Airline : BaseEntity, IAuditedEntity
{
    public string Name { get; set; }
    public string Country { get; set; }
    public Guid Code { get; set; }
    public ICollection<Aircraft>? aircrafts { get; set; }
    public List<Reys>? reys { get; set; }
    public string? CreatedBy { get; set; }
    public DateTime? CreatedOn { get; set; }
    public string? UpdatedBy { get; set; }
    public DateTime? UpdatedOn { get; set; }
    //
    public string? Message { get; set; }
    public DateTime Date { get; set; }
}
