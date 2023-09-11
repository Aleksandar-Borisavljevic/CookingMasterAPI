using System.ComponentModel;

namespace CookingMasterAPI.Enums.CulinaryRecipeStatusEnums.CommandEnums
{
    public enum CreateCulinaryRecipeEnum
    {
        [Description("An uknown error has occured. Please contact support.")]
        Undefined = 0,
        [Description("Successfully Created Culinary Recipe.")]
        Success = 1,
        [Description("Culinary Recipe info not valid.")]
        RequestIsNull = 2,
        [Description("Culinary Recipe already exists.")]
        CulinaryRecipeAlreadyExists = 3,
        RequestIsValid = 4
    }
}
