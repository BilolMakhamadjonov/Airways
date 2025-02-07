using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airways.Application.Models.Payment;

public class PaymentUpdateModel
{
    public decimal Amount { get; set; }
    public PayStatus payStatus { get; set; }
    public CardType paymentType { get; set; }
    public Guid User_id { get; set; }
    public Guid Order_id { get; set; }
}
public class UpdatePaymentResponceModel : BaseResponceModel { }
