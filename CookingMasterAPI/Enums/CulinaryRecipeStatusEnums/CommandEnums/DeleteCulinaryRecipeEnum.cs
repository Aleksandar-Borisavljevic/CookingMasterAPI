using System.ComponentModel;

namespace CookingMasterAPI.Enums.CulinaryRecipeStatusEnums.CommandEnums
{
    public enum DeleteCulinaryRecipeEnum
    {
        [Description("An uknown error has occured. Please contact support.")]
        Undefined = 0,
        [Description("Successfully Deleted Culinary Recipe.")]
        Success = 1,
        [Description("Culinary Recipe info not valid.")]
        CulinaryRecipeUidIsNull = 2,
        [Description("Culinary Recipe not found.")]
        CulinaryRecipeNotFound = 3
    }
}
