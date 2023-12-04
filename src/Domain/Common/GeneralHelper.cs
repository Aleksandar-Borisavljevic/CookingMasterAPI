
namespace CookingMasterApi.Domain.Common;
public static class GeneralHelper
{
    public static bool IsHttpUrl(string returnUrl)
    {
        return Uri.TryCreate(returnUrl, UriKind.Absolute, out Uri uriResult)
            && (uriResult.Scheme == Uri.UriSchemeHttp || uriResult.Scheme == Uri.UriSchemeHttps);
    }

    public static string GenerateRegisterHtml(string username, string returnUrl)
    {
        return $"Hello {username} <br> <a href='{returnUrl}' > Register </>";
    }

    public static string GenerateResetPasswordHtml(string username, string returnUrl)
    {
        return $"Hello {username} <br> <a href='{returnUrl}' > Reset Password </>";
    }
}
