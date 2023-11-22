namespace CookingMasterApi.Application.Authentication.Commands.ExternalSignIn;

public class ExternalSignInCommandResult
{
    public string AccessToken { get; set; }
    public string RefreshToken { get; set; }

    public ExternalSignInCommandResult(string accessToken, string refreshToken)
    {
        AccessToken = accessToken;
        RefreshToken = refreshToken;
    }

}
