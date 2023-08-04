using System.ComponentModel;

namespace CookingMasterAPI.Enums.AuthStatusEnums
{
    public enum ResetPasswordEnum
    {
        [Description("An uknown error has occured. Please contact support.")]
        Undefined = 0,
        [Description("Password has succesfully been reset.")]
        Success = 1,
        [Description("User with that email address was not found.")]
        UserNotFound = 2,
        RequestIsValid = 3,
        [Description("Reset token has expired. Please repeat the process to get the new reset token.")]
        ResetTokenExpired = 4,

    }
}
