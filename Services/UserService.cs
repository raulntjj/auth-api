using auth_api.Data.DTOs;
using auth_api.Models;
using AutoMapper;
using Microsoft.AspNetCore.Identity;

namespace auth_api.Services;

public class UserService
{
	private readonly IMapper _mapper;
	private readonly UserManager<User> _userManager;
	private readonly SignInManager<User> _signInManager;
	private readonly TokenService _tokenService;

	public UserService(
		IMapper mapper,
		UserManager<User> userManager,
		SignInManager<User> signInManager,
		TokenService tokenService
	) {
		_mapper = mapper;
		_userManager = userManager;
		_signInManager = signInManager;
		_tokenService = tokenService;
	}

	public async Task StoreUser(CreateUserDTO createUserDTO)
	{
		User user =
			_mapper.Map<User>(createUserDTO);

		await _userManager
			.CreateAsync(user, createUserDTO.Password);
	}

	public async Task<string> LoginUser(LoginDTO loginDTO)
	{
		var result =
			await _signInManager.PasswordSignInAsync(loginDTO.Username, loginDTO.Password, false, false);

		if (!result.Succeeded)
			throw new Exception("Invalid Login Attempt");

		var user = _signInManager
				.UserManager
				.Users
				.FirstOrDefault(user => user.NormalizedUserName == loginDTO.Username.ToUpper());

		if (user is null)
			throw new Exception("User Not Found");
		
		var token =
			_tokenService.GenerateToken(user);

		return token;
	}
}