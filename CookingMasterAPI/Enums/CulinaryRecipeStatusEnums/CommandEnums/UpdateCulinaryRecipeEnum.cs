using System.ComponentModel;

namespace CookingMasterAPI.Enums.CulinaryRecipeStatusEnums.CommandEnums
{
    public enum UpdateCulinaryRecipeEnum
    {
        [Description("An uknown error has occured. Please contact support.")]
        Undefined = 0,
        [Description("Successfully Updated Culinary Recipe.")]
        Success = 1,
        [Description("Culinary Recipe info not valid.")]
        RequestIsNull = 2,
        [Description("Culinary Recipe Not Found.")]
        CulinaryRecipeNotFound = 3,
        [Description("Culinary Recipe Uid Not Found.")]
        CulinaryRecipeUidIsNull = 3,
        RequestIsValid = 4,
    }
}
