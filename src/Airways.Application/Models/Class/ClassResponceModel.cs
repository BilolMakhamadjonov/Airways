using Airways.Application.Models.Clas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airways.Application.Models.Class;

public class ClassResponceModel
{
    public Guid id { get; set; }
    public ClassType className { get; set; }
    public string description { get; set; }
}
