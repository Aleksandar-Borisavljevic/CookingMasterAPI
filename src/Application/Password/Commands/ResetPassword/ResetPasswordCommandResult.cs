namespace CookingMasterApi.Application.Password.Commands.ResetPassword;

public class ResetPasswordCommandResult
{
    public string AccessToken { get; set; }
    public string RefreshToken { get; set; }

    public ResetPasswordCommandResult(string accessToken, string refreshToken)
    {
        AccessToken = accessToken;
        RefreshToken = refreshToken;
    }

}
