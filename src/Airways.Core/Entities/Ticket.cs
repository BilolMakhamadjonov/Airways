using Airways.Core.Common;

namespace Airways.Core.Entities;

public class Ticket : BaseEntity, IAuditedEntity
{
    public double price { get; set; }
    public decimal MaxCharge { get; set; }
    public decimal AdditionalCharge { get; set; }
    public DateTime OrderTime { get; set; }
    public DateTime? ExpirationTime { get; set; } // Bron tugashi voxti
    public int SeatNumber { get; set; }
    public Status status { get; set; }
    public Reys Reys { get; set; }
    public Guid ReysId { get; set; }
    public Guid? UserId { get; set; }
    public User? User { get; set; }
    public Guid ClassId { get; set; }
    public Class Class { get; set; }
    public string? CreatedBy { get; set; }
    public DateTime? CreatedOn { get; set; }
    public string? UpdatedBy { get; set; }
    public DateTime? UpdatedOn { get; set; }
    public int TicketCount { get; set; }


    // Bronni o'chirish uchun metod
    public bool IsExpired()
    {
        return ExpirationTime.HasValue && ExpirationTime.Value <= DateTime.UtcNow;
    }
}
public enum Status
{
    Available,
    Sold,
    Expired
}