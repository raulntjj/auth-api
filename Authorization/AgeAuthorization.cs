using System.Security.Claims;
using auth_api.Requirements;
using Microsoft.AspNetCore.Authorization;

namespace auth_api.Authorization;

public class AgeAuthorization : AuthorizationHandler<MinimumAgeRequirement>
{
  protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, MinimumAgeRequirement requirement)
  {
    var BirthDateClaim =
      context.User.FindFirst(claim => claim.Type == "BirthDate");

    if (BirthDateClaim is null)
      return Task.CompletedTask;

    var BirthDate =
      Convert.ToDateTime(BirthDateClaim.Value);

    var userAge =
      DateTime.Today.Year - BirthDate.Year;

    if (BirthDate > DateTime.Today.AddYears(-userAge))
        userAge--;

    if (userAge >= requirement.MinimumAge)
      context.Succeed(requirement);
    
    return Task.CompletedTask;
  }
}