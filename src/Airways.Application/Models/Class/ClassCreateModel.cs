using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airways.Application.Models.Clas;

public class ClassCreateModel
{
    public ClassType className { get; set; }
    public string description { get; set; }
}
public class CreateClassResponceModel : BaseResponceModel { }

public enum ClassType
{
    Economy,
    Business,
    FirstClass
}
