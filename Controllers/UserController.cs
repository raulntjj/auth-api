using auth_api.Data.DTOs;
using auth_api.Models;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace auth_api.Controllers;

[ApiController]
[Route("api/users")]
public class UserController : ControllerBase
{
	private readonly IMapper _mapper;
	private readonly UserManager<User> _userManager;
	public UserController(IMapper mapper, UserManager<User> userManager)
	{
		_mapper = mapper;
		_userManager = userManager;
	}
	
	[HttpPost]
	public async Task<IActionResult> StoreUser(CreateUserDTO createUserDTO)
	{
		User user = _mapper.Map<User>(createUserDTO);
		IdentityResult result = await _userManager.CreateAsync(user, createUserDTO.Password);
		if (result.Succeeded)
		{
			return Ok("User created successfully");
		}

		var errors = result.Errors.Select(e => e.Description).ToList();
		return BadRequest(new { Errors = errors });
	}
}