namespace CookingMasterApi.Application.Authentication.Commands.SignIn;

public class SignInCommandResult
{
    public string AccessToken { get; set; }
    public string RefreshToken { get; set; }

    public SignInCommandResult(string accessToken, string refreshToken)
    {
        AccessToken = accessToken;
        RefreshToken = refreshToken;
    }

}
