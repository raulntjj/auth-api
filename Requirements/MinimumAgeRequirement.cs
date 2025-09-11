using Microsoft.AspNetCore.Authorization;

namespace auth_api.Requirements;

public class MinimumAgeRequirement : IAuthorizationRequirement
{
  public int MinimumAge { get; }
  
  public MinimumAgeRequirement(int minimumAge)
  {
    MinimumAge = minimumAge;
  }
}