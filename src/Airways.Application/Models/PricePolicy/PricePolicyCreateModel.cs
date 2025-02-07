using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airways.Application.Models.PricePolicy;

[Authorize(policy:"Admin")]
public class PricePolicyCreateModel
{
    public decimal DiscountPercentage { get; set; }
    public string Conditions { get; set; }
}
public class CreatePricePolicyResponceModel : BaseResponceModel { }
