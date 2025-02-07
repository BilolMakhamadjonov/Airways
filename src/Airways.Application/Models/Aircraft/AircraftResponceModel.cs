using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airways.Application.Models.Aircraft;

public class AircraftResponceModel
{
    public string Name { get; set; }
    public string Description { get; set; }
    public string Model { get; set; }
    public int SeatCapacity { get; set; }
}