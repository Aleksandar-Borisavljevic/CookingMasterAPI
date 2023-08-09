namespace CookingMasterAPI.Models.Request.AuthRequests
{
    public class ResetPasswordRequest
    {
        public string EmailAddress { get; set; } = string.Empty;
        public string ResetPasswordToken { get; set; } = string.Empty;
        public string NewPassword { get; set; } = string.Empty;
        public string ConfirmPassword { get; set; } = string.Empty;

    }
}
