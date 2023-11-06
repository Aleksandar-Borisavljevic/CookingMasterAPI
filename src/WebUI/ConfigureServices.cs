using CookingMasterApi.Application.Common.Interfaces;
using CookingMasterApi.Infrastructure.Persistence;
using CookingMasterApi.WebUI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData;

namespace Microsoft.Extensions.DependencyInjection;

public static class ConfigureServices
{
    public static IServiceCollection AddWebUIServices(this IServiceCollection services)
    {
        services.AddDatabaseDeveloperPageExceptionFilter();

        services.AddScoped<ICurrentUserService, CurrentUserService>();

        services.AddHttpContextAccessor();

        services.AddHealthChecks()
            .AddDbContextCheck<CookingMasterDbContext>();

        services.AddControllers().AddOData(options =>
                options.Select().Filter().Count().OrderBy().SetMaxTop(null).Expand()
        );

        services.AddSwaggerGen();


        // Customise default API behaviour
        services.Configure<ApiBehaviorOptions>(options =>
            options.SuppressModelStateInvalidFilter = true);


        return services;
    }
}
