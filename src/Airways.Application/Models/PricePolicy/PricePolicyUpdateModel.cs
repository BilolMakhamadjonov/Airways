using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airways.Application.Models.PricePolicy;

public class PricePolicyUpdateModel
{
    public decimal DiscountPercentage { get; set; }
    public string Conditions { get; set; }
}
public class UpdatePricePolicyResponceModel : BaseResponceModel { }
