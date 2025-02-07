using Airways.Core.Common;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airways.Core.Entities;

public class Payment : BaseEntity, IAuditedEntity
{
    public decimal Amount { get; set; }
    public PayStatus payStatus { get; set; }
    public CardType paymentType { get; set; }
    public Guid UserId { get; set; }
    public User User { get; set; }
    public Guid OrderId { get; set; }
    public Order Order { get; set; }
    public string? CreatedBy { get; set; }
    public DateTime? CreatedOn { get; set; }
    public string? UpdatedBy { get; set; }
    public DateTime? UpdatedOn { get; set; }
}

public enum PayStatus
{
    Paid,
    Pending,
    Failed
}

public enum CardType
{
    Uzcard,
    Humo,
    Visa,
    Mastercard
}