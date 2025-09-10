using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using auth_api.Models;
using Microsoft.IdentityModel.Tokens;

namespace auth_api.Services;

public class TokenService
{
  public string GenerateToken(User user)
  {
    Claim[] claims = new Claim[]
    {
      new Claim(ClaimTypes.NameIdentifier, user.Id),
      new Claim(ClaimTypes.Name, user.UserName),
      new Claim(ClaimTypes.Email, user.Email),
      new Claim("BirthDate", user.BirthDate.ToString("yyyy-MM-dd"))
    };

    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("JHSJIDHU8"));

    var signingCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

    var token = new JwtSecurityToken(
      expires: DateTime.Now.AddHours(1),
      claims: claims,
      signingCredentials: signingCredentials
    );

    throw new NotImplementedException();
  }
}