using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airways.Application.Models.Review;

public class ReviewResponceModel
{
    public Guid id { get; set; }
    public int Rating { get; set; }
    public string Comment { get; set; }
}
