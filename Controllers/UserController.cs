using auth_api.Data.DTOs;
using auth_api.Models;
using auth_api.Services;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace auth_api.Controllers;

[ApiController]
[Route("api/users")]
public class UserController : ControllerBase
{
	private readonly StoreService _storeService;
	public UserController(StoreService storeService)
	{
		_storeService = storeService;
	}
	
	[HttpPost]
	public async Task<IActionResult> StoreUser(CreateUserDTO createUserDTO)
	{
		await _storeService.StoreUser(createUserDTO);
		return Ok("User created successfully");
	}
}