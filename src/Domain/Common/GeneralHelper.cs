
namespace CookingMasterApi.Domain.Common;
public static class GeneralHelper
{
    public static bool IsHttpUrl(string returnUrl)
    {
        return Uri.TryCreate(returnUrl, UriKind.Absolute, out Uri uriResult)
            && (uriResult.Scheme == Uri.UriSchemeHttp || uriResult.Scheme == Uri.UriSchemeHttps);
    }
}
