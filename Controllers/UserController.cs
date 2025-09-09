using auth_api.Data.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace auth_api.Controllers;

[ApiController]
[Route("api/users")]
class UserController
{
	public IActionResult StoreUser([FromBody] CreateUserDTO createUserDTO)
	{

		throw new NotImplementedException();
	}

}