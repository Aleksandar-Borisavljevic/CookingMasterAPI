namespace CookingMasterAPI.Helpers
{
    public static class ExceptionManager
    {
        public const string requestIsNull = "User info not valid";
        public const string mailAlreadyInUse = "User with this email already exists";
        public const string undefinedException = "An unknown exception has occured.";
        public const string userDoesNotExist = "User doesn't exist.";
        public const string invalidPassword = "Password is not valid.";
    }
}
