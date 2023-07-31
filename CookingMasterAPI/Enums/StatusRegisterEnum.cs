using System.ComponentModel;

namespace CookingMasterAPI.Enums
{
    public enum StatusRegisterEnum
    {
        [Description("An uknown error has occured. Please contact support.")]
        Undefined = 0,
        [Description("User successfully created.")]
        Success = 1,
        [Description("User info not valid.")]
        RequestIsNull = 2,
        [Description("User with this email already exists.")]
        MailAlreadyInUse = 3,

        RequestIsValid = 4
    }
}
