namespace Airways.Application.Models.Airline;

public class AirlineCreateModel
{ 
    public string Name { get; set; }
    public string Country { get; set; }
    public Guid Code { get; set; }
}
public class CreateAirlineResponceModel : BaseResponceModel { }
