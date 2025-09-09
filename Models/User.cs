using Microsoft.AspNetCore.Identity;

namespace auth_api.Models;

public class User : IdentityUser
{
	public DateTime BirthDate { get; set; }
	public User(): base() { }
}