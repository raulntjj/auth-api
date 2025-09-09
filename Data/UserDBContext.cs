using auth_api.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace auth_api.Data;

public class UserDBContext : IdentityDbContext<User>
{
    public UserDBContext(DbContextOptions<UserDBContext> options) : base(options)
    {
    }
}