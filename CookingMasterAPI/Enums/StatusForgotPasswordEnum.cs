using System.ComponentModel;

namespace CookingMasterAPI.Enums
{
    public enum StatusForgotPasswordEnum
    {
        [Description("An uknown error has occured. Please contact support.")]
        Undefined = 0,
        [Description("Email with password reset token has been sent to you. Please check your email.")]
        Success = 1,
        [Description("User with this email address does not exist.")]
        UserDoesNotExist = 2,
    }
}
