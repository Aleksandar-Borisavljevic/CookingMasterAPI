namespace CookingMasterApi.Application.Authentication.Commands.SignIn;

public class SignInCommandResult
{
    public string AccessToken { get; set; }
    public string RefreshToken { get; set; }
    public Guid? PictureUid { get; set; }

    public SignInCommandResult(string accessToken, string refreshToken, Guid? pictureUid)
    {
        AccessToken = accessToken;
        RefreshToken = refreshToken;
        PictureUid = pictureUid;
    }

}
