using System.Text;
using AppManagement.Application.Abstractions.Identity;
using AppManagement.Application.Abstractions.Repositories;
using AppManagement.Infrastructure.Identity.DbContext;
using AppManagement.Infrastructure.Identity.Models;
using AppManagement.Infrastructure.Identity.Services;
using AppManagement.Infrastructure.Identity.Settings;
using AppManagement.Infrastructure.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

namespace AppManagement.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services,
        IConfiguration configuration
    )
    {
        services.AddIdentityServices(configuration);
        services.AddScoped<IArtistRepository, ArtistRepository>();
        services.AddScoped<IAlbumRepository, AlbumRepository>();
        services.AddScoped<ISongRepository, SongRepository>();


        return services;
    }

    private static IServiceCollection AddIdentityServices(
        this IServiceCollection services,
        IConfiguration configuration
    )
    {
        services.AddDbContext<ApplicationIdentityDbContext>(options =>
        {
            options.UseSqlServer(
                configuration.GetConnectionString("AppManagementConnectionString")
            );
        });

        services.Configure<JwtSettings>(configuration.GetSection("JwtSettings"));

        services
            .AddIdentity<ApplicationUser, IdentityRole>()
            .AddEntityFrameworkStores<ApplicationIdentityDbContext>()
            .AddDefaultTokenProviders();

        services.AddTransient<IAuthenticationService, AuthenticationService>();
        services.AddTransient<IUserService, UserService>();

        services
            .AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ClockSkew = TimeSpan.Zero,
                    ValidIssuer = configuration["JwtSettings:Issuer"],
                    ValidAudience = configuration["JwtSettings:Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey(
                        Encoding.UTF8.GetBytes(configuration["JwtSettings:Key"])
                    ),
                };
            });

        return services;
    }
}
