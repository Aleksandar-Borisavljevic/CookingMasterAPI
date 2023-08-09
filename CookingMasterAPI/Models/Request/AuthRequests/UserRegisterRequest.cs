namespace CookingMasterAPI.Models.Request.AuthRequests
{
    public class UserRegisterRequest
    {
        //[Required, MaxLength(50)]
        public string Username { get; set; } = string.Empty;

        //[Required, EmailAddress]
        public string EmailAddress { get; set; } = string.Empty;

        //[Required, MinLength(6, ErrorMessage = "Please enter at least 6 characters.")]
        public string Password { get; set; } = string.Empty;

        //[Required, Compare("Password")]
        public string ConfirmPassword { get; set; } = string.Empty;
    }
}
