namespace CookingMasterApi.Application.Common.Models;

public class AuthResult
{
    public string Username { get; set; }
    public string AccessToken { get; set; }
    public string RefreshToken { get; set; }
    public Guid? PictureUid { get; set; }

    public AuthResult(string username, string accessToken, string refreshToken, Guid? pictureUid)
    {
        Username = username;
        AccessToken = accessToken;
        RefreshToken = refreshToken;
        PictureUid = pictureUid;
    }

}
