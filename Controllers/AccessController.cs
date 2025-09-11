using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace auth_api.Controllers;

[ApiController]
[Route("api/access")]
public class AccessController : ControllerBase
{
  [HttpGet("public")]
  public IActionResult PublicEndpoint()
  {
    return Ok("This is a public endpoint");
  }

  [HttpGet("private")]
  [Authorize(Policy = "AtLeast18")]
  public IActionResult PrivateEndpoint()
  {
    return Ok("This is a private endpoint");
  }
}