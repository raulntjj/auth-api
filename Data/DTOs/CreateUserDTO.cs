using System.ComponentModel.DataAnnotations;

namespace auth_api.Data.DTOs;

class CreateUserDTO
{
	[Required]
	public string Username { get; set; }
	[Required]
	[DataType(DataType.Password)]
	public string Password { get; set; }
	[Required]
	public string BirthDate { get; set; }
	[Required]
	[Compare("Password", ErrorMessage = "Passwords do not match")]
	public string ConfirmPassword { get; set; }
}