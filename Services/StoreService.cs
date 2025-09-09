using auth_api.Data.DTOs;
using auth_api.Models;
using AutoMapper;
using Microsoft.AspNetCore.Identity;

namespace auth_api.Services;

public class StoreService
{
	private readonly IMapper _mapper;
	private readonly UserManager<User> _userManager;

	public StoreService(IMapper mapper, UserManager<User> userManager)
	{
		_mapper = mapper;
		_userManager = userManager;
	}

	public async Task StoreUser(CreateUserDTO createUserDTO)
	{
		User user = _mapper.Map<User>(createUserDTO);
		IdentityResult result = await _userManager.CreateAsync(user, createUserDTO.Password);
	}
}