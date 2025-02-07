using Microsoft.AspNetCore.Http;

namespace Airways.Application.DTO;

public class UserDto
{
    public Guid id { get; set; }
    public required string Name { get; set; }
    public required string Email { get; set; }
    public required string Address { get; set; }
    public IFormFile ProfileImageFile { get; set; }
}
