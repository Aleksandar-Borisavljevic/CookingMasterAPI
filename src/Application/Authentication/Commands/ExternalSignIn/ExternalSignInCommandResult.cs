namespace CookingMasterApi.Application.Authentication.Commands.ExternalSignIn;

public class ExternalSignInCommandResult
{
    public string AuthReturnUrl;

    public ExternalSignInCommandResult(string authReturnUrl)
    {
        AuthReturnUrl = authReturnUrl;
    }

}
