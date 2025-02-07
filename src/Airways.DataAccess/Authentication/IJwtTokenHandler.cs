using Airways.Core.Entities;
using System.IdentityModel.Tokens.Jwt;

namespace Airways.DataAccess.Authentication;

public interface IJwtTokenHandler
{
    JwtSecurityToken GenerateAccesToken(UserForCreationDto user);
    JwtSecurityToken GenerateAccesToken(User user);
    string GenerateRefreshToken();
}
