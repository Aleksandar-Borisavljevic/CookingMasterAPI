using System.ComponentModel;

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

        public static string GetEnumDescription(this Enum enumValue)
        {
            var field = enumValue.GetType().GetField(enumValue.ToString());
            if (field is null)
            {
                throw new ArgumentException("Item not found.", nameof(enumValue));
            }
            if (Attribute.GetCustomAttribute(field, typeof(DescriptionAttribute)) is DescriptionAttribute attribute)
            {
                return attribute.Description;
            }
            throw new ArgumentException("Item not found.", nameof(enumValue));
        }

        public static string CreateUniqueSequence(this string caption)
        {
            string currentDate = DateTime.Now.ToString("yyyyMMddHHmmss");
            return $"{caption}-{currentDate}";
        }
    }
}
