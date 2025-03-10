﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airways.Application.Models.Airline;

public class AirlineUpdateModel
{
    public string Name { get; set; }
    public string Country { get; set; }
    public Guid Code { get; set; }
}
public class UpdateAirlineResponceModel : BaseResponceModel { }
