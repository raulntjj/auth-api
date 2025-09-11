using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using auth_api.Models;
using Microsoft.IdentityModel.Tokens;

namespace auth_api.Services;

public class TokenService
{

  private IConfiguration _configuration;
    
  public TokenService(IConfiguration configuration)
  {
    _configuration = configuration;
  }

  public string GenerateToken(User user)
  {
    Claim[] claims =
    [
        new("Id", user.Id),
        new("Username", user.UserName),
        new("BirthDate", user.BirthDate.ToString("yyyy-MM-dd"))
    ];

    var secret =
        new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["SymetricSecurityKey"]));

    var signingCredentials =
        new SigningCredentials(secret, SecurityAlgorithms.HmacSha256);

    var token =
        new JwtSecurityToken(
            expires: DateTime.Now.AddHours(1),
            claims: claims,
            signingCredentials: signingCredentials
        );

    var tokenString = new JwtSecurityTokenHandler().WriteToken(token);
    return tokenString;
  }
}