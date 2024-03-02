namespace CookingMasterApi.Application.Authentication.Commands.SignIn;

//TODO: koristimo ovako nesto na vise mesta mozda da se napravi zajednicka klasa da bude unutar CommandResulta
public class SignInCommandResult
{
    public string Username { get; set; }
    public string AccessToken { get; set; }
    public string RefreshToken { get; set; }
    public Guid? PictureUid { get; set; }

    public SignInCommandResult(string username, string accessToken, string refreshToken, Guid? pictureUid)
    {
        Username = username;
        AccessToken = accessToken;
        RefreshToken = refreshToken;
        PictureUid = pictureUid;
    }

}
