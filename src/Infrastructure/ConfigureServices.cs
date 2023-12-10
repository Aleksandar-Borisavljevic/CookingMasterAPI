using System.Runtime.Serialization.Formatters;
using System.Security.Claims;
using System.Text;
using CookingMasterApi.Application.Common.Interfaces;
using CookingMasterApi.Infrastructure.Identity;
using CookingMasterApi.Infrastructure.Options;
using CookingMasterApi.Infrastructure.Persistence;
using CookingMasterApi.Infrastructure.Persistence.Interceptors;
using CookingMasterApi.Infrastructure.Services;
using IdentityModel;
using Microsoft.AspNetCore.Authentication.Google;
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
        services.AddSingleton(configuration.Read<RefreshTokenSettings>());
        services.AddSingleton(configuration.Read<EmailSettings>());
        services.AddSingleton(configuration.Read<BlobStorageSettings>());

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
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequiredLength = 1;
                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireUppercase = false;
                options.Password.RequiredUniqueChars = 0;
                //options.Tokens.EmailConfirmationTokenProvider = TokenOptions.DefaultEmailProvider;
                //options.Tokens.PasswordResetTokenProvider = TokenOptions.DefaultPhoneProvider;
            })
            .AddRoles<IdentityRole>()
            .AddEntityFrameworkStores<CookingMasterDbContext>();

        services.Configure<DataProtectionTokenProviderOptions>(options =>
        {
            options.TokenLifespan = TimeSpan.FromDays(5);
        });


        services.AddScoped<IIdentityService, IdentityService>();
        services.AddScoped<ITokenService, TokenService>();
        services.AddScoped<IRefreshTokenService, RefreshTokenService>();
        services.AddScoped<ICulinaryRecipeService, CulinaryRecipeService>();
        services.AddScoped<IEmailService, EmailService>();
        services.AddScoped<IFileService, FileService>();

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
            googleOptions.Events.OnCreatingTicket = (context) =>
            {
                var picture = context.User.GetProperty(JwtClaimTypes.Picture).GetString();
                context.Identity.AddClaim(new Claim(JwtClaimTypes.Picture, picture));
                return Task.CompletedTask;
            };
        })
        .AddFacebook(facebookOptions =>
        {
            facebookOptions.AppId = facebookSettings.ClientId;
            facebookOptions.AppSecret = facebookSettings.ClientSecret;
            facebookOptions.Fields.Add(JwtClaimTypes.Picture);
            facebookOptions.Events.OnCreatingTicket = (context) =>
            {
                //Facebook need to fix this
                var picture = context.User.GetProperty(JwtClaimTypes.Picture).GetProperty("data").GetProperty("url").GetString();
                context.Identity.AddClaim(new Claim(JwtClaimTypes.Picture, picture));
                return Task.CompletedTask;
            };
        }); ;



        services.AddAuthorization();

        return services;
    }
}
