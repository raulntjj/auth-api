using auth_api.Data.DTOs;
using auth_api.Models;
using AutoMapper;

namespace auth_api.Profiles;

class UserProfile : Profile
{
	public UserProfile()
	{
		CreateMap<CreateUserDTO, User>();	
	}
}