namespace CookingMasterApi.Application.Password.Commands.ResetPassword;

public class ResetPasswordCommandResult
{
    public string AccessToken { get; set; }
    public string RefreshToken { get; set; }
    public Guid? PictureUid { get; set; }

    public ResetPasswordCommandResult(string accessToken, string refreshToken, Guid? pictureUid)
    {
        AccessToken = accessToken;
        RefreshToken = refreshToken;
        PictureUid = pictureUid;
    }

}
