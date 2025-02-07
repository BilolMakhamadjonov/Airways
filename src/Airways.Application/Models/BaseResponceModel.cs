using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airways.Application.Models;

public class BaseResponceModel
{
    public Guid Id { get; set; }

    public static implicit operator bool(BaseResponceModel v)
    {
        throw new NotImplementedException();
    }
}