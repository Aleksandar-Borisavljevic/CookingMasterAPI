﻿using System.Text;
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
        var refreshTokenSettings = configuration.Read<RefreshTokenSettings>();
        services.AddSingleton(jwtSettings);
        services.AddSingleton(refreshTokenSettings);

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
            .AddDefaultIdentity<ApplicationUser>(options =>
            {
                options.User.RequireUniqueEmail = true;
                options.Tokens.EmailConfirmationTokenProvider = TokenOptions.DefaultEmailProvider;
                options.Tokens.PasswordResetTokenProvider = TokenOptions.DefaultPhoneProvider;
            })
            .AddRoles<IdentityRole>()
            .AddEntityFrameworkStores<CookingMasterDbContext>();

        services.Configure<DataProtectionTokenProviderOptions>(options =>
        {
            options.TokenLifespan = TimeSpan.FromDays(5);
        });


        services.AddTransient<IIdentityService, IdentityService>();
        services.AddScoped<ITokenService, TokenService>();
        services.AddScoped<IRefreshTokenService, RefreshTokenService>();

        var googleSettings = configuration.Read<GoogleSettings>();
        var facebookSettings = configuration.Read<FacebookSettings>();

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
        }).AddGoogle(googleOptions =>
        {
            googleOptions.ClientId = googleSettings.ClientId;
            googleOptions.ClientSecret = googleSettings.ClientSecret;
        })
        .AddFacebook(facebookOptions =>
        {
            facebookOptions.AppId = googleSettings.ClientId;
            facebookOptions.AppSecret = googleSettings.ClientSecret;
        }); ;



        services.AddAuthorization();

        return services;
    }
}
