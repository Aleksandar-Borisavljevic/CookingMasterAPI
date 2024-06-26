﻿using System.ComponentModel;

namespace CookingMasterAPI.Enums.AuthStatusEnums
{
    public enum LoginEnum
    {
        [Description("An uknown error has occured. Please contact support.")]
        Undefined = 0,
        [Description("Successfully logged in.")]
        Success = 1,
        [Description("User info not valid.")]
        RequestIsNull = 2,
        RequestIsValid = 3,
        [Description("User doesn't exist.")]
        UserNotFound = 4,
        [Description("User is not verified.")]
        UserNotVerified = 5,
        [Description("The password that has been entered is not valid.")]
        InvalidPassword = 6,
    }
}
