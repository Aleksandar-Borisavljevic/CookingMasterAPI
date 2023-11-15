using Microsoft.Extensions.Configuration;

namespace CookingMasterApi.Infrastructure.Options;

public static class OptionsExtensions
{
    public static T? Read<T>(this IConfiguration configuration)
    {
        var sectionName = $"{nameof(Options)}:{typeof(T).Name}";
        var section = configuration.GetSection(sectionName);
        if (section == null)
        {
            return default;
        }

        return section.Get<T>();
    }
}
