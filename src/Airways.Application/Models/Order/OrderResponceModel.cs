using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airways.Application.Models.Order;

public class OrderResponceModel
{
    public Guid Id { get; set; }
    public decimal TotalPrice { get; set; }
}
