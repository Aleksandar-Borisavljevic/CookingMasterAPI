namespace CookingMasterAPI.Helpers
{
    public static class ExtensionMethods
    {
        // Check if the password contains a character that's an uppercase
        public static bool HasUpperCaseLetter(this string password)
        {
            return password.Any(char.IsUpper);
            //return password.Any(p => char.IsUpper(p));
        }
    }
}
