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
    Claim[] claims = [
      new(ClaimTypes.NameIdentifier, user.Id),
      new(ClaimTypes.Name, user.UserName),
      new("BirthDate", user.BirthDate.ToString("yyyy-MM-dd"))
    ];

    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("ASDASDASDASDASDASDASD45ASDASDASDASDASDASDASDASDSSAD"));

    var signingCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

    var token = new JwtSecurityToken(
      expires: DateTime.Now.AddHours(1),
      claims: claims,
      signingCredentials: signingCredentials
    );
    
    return new JwtSecurityTokenHandler().WriteToken(token);
  }
}