using System.Text;
using auth_api.Authorization;
using auth_api.Data;
using auth_api.Models;
using auth_api.Requirements;
using auth_api.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);

var connString = builder.Configuration["ConnectionStrings:UserConnection"];
builder.Services.AddDbContext<UserDBContext>(options =>
{
    options.UseMySql(
        connString, ServerVersion.AutoDetect(connString)
    );
});

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddSingleton<IAuthorizationHandler, AgeAuthorization>();
builder.Services.AddScoped<UserService>();
builder.Services.AddScoped<TokenService>();

builder.Services
    .AddIdentity<User, IdentityRole>()
    .AddEntityFrameworkStores<UserDBContext>()
    .AddDefaultTokenProviders();

var secretKey = builder.Configuration["SymetricSecurityKey"];
builder.Services.AddAuthentication(options => 
    options.DefaultAuthenticateScheme =
        JwtBearerDefaults.AuthenticationScheme
).AddJwtBearer(options =>
    options.TokenValidationParameters =
        new TokenValidationParameters {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey =
                new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey)),
            ValidateAudience = false,
            ValidateIssuer = false,
            ClockSkew = TimeSpan.Zero,
        }
);

builder.Services.AddAuthorization(options =>
    options.AddPolicy("AtLeast18", policy =>
         policy.AddRequirements(new MinimumAgeRequirement(18))
    )
);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
