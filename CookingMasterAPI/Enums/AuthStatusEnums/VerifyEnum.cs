using System.ComponentModel;

namespace CookingMasterAPI.Enums.AuthStatusEnums
{
    public enum VerifyEnum
    {
        [Description("An uknown error has occured. Please contact support.")]
        Undefined = 0,
        [Description("User registration is successfully verified.")]
        Success = 1,
        [Description("Invalid verification token. Please check your email address.")]
        InvalidToken = 2

    }
}
