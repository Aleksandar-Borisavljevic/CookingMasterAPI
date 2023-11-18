namespace CookingMasterApi.Application.Authentication.Commands.Refresh;

public class RefreshCommandResult
{
    public string AccessToken { get; set; }
    public string RefreshToken { get; set; }

    public RefreshCommandResult(string accessToken, string refreshToken)
    {
        AccessToken = accessToken;
        RefreshToken = refreshToken;
    }

}
