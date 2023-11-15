using System.Text;
using CookingMasterApi.Application.Common.Interfaces;
using CookingMasterApi.Infrastructure.Identity;
using CookingMasterApi.Infrastructure.Options;
using CookingMasterApi.Infrastructure.Persistence;
using CookingMasterApi.Infrastructure.Persistence.Interceptors;
using CookingMasterApi.Infrastructure.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace Microsoft.Extensions.DependencyInjection;

public static class ConfigureServices
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    {
        var jwtSettings = configuration.Read<JwtSettings>();
        services.AddSingleton(jwtSettings);

        services.AddScoped<AuditableEntitySaveChangesInterceptor>();

        if (configuration.GetValue<bool>("UseInMemoryDatabase"))
        {
            services.AddDbContext<CookingMasterDbContext>(options =>
                options.UseInMemoryDatabase("CookingMasterApiDb"));
        }
        else
        {
            services.AddDbContext<CookingMasterDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"),
                    builder => builder.MigrationsAssembly(typeof(CookingMasterDbContext).Assembly.FullName)));
        }

        services.AddScoped<ICookingMasterDbContext>(provider => provider.GetRequiredService<CookingMasterDbContext>());

        services.AddScoped<CookingMasterDbContextInitialiser>();

        services
            .AddDefaultIdentity<ApplicationUser>()
            .AddRoles<IdentityRole>()
            .AddEntityFrameworkStores<CookingMasterDbContext>();


        services.AddTransient<IIdentityService, IdentityService>();
        services.AddScoped<ITokenService, TokenService>();

        services.AddAuthentication(options =>
        {
            options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        })
        .AddJwtBearer(options =>
        {
            options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                ValidIssuer = jwtSettings.Issuer,
                ValidAudience = jwtSettings.Audience,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings.SecretKey)),
                ClockSkew = TimeSpan.Zero
            };
        });

        services.AddAuthorization();

        return services;
    }
}
