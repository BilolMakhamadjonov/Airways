using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airways.Application.Models.Review;

public class ReviewUpdateModel
{
    public int Rating { get; set; }
    public string Comment { get; set; }
    public Guid User_id { get; set; }
    public Guid Reys_id { get; set; }
}
public class UpdateReviewResponceModel : BaseResponceModel { }

