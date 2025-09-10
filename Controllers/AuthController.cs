using auth_api.Data.DTOs;
using auth_api.Services;
using Microsoft.AspNetCore.Mvc;

namespace auth_api.Controllers;

[ApiController]
[Route("api/auth")]
public class AuthController : ControllerBase
{
  private readonly UserService _userService;
  public AuthController(UserService UserService)
  {
    _userService = UserService;
  }

  [HttpPost("register")]
	public async Task<IActionResult> Register(CreateUserDTO createUserDTO)
	{
		await _userService.StoreUser(createUserDTO);
		return Ok("User created successfully");
	}

  [HttpPost("login")]
  public async Task<IActionResult> Login(LoginDTO loginDTO)
  {
    var token = await _userService.LoginUser(loginDTO);
    return Ok(token);
  }
}