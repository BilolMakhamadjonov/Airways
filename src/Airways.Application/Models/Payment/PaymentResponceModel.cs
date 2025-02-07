using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airways.Application.Models.Payment;

public class PaymentResponceModel
{
    public Guid id {  get; set; }
    public decimal Amount { get; set; }
    public PayStatus payStatus { get; set; }
    public CardType paymentType { get; set; }
}
