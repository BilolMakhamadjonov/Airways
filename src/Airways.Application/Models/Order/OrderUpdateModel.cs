using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airways.Application.Models.Order;

public class OrderUpdateModel
{
    public decimal TotalPrice { get; set; }
    public Guid User_id { get; set; }
    public Guid Ticked_id { get; set; }
}
public class UpdateOrderResponceModel : BaseResponceModel { }
