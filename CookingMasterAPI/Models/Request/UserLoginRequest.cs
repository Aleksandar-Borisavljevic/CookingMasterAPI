﻿namespace CookingMasterAPI.Models.Request
{
    public class UserLoginRequest
    {
        public string EmailAddress { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
    }
}
