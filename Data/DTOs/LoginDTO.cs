using System.ComponentModel.DataAnnotations;

namespace auth_api.Data.DTOs;

public class LoginDTO
{
  [Required]
  public string Username { get; set; }
  
  [Required]
  public string Password { get; set; }
}