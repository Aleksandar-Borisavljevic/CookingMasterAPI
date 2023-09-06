using System.ComponentModel;

namespace CookingMasterAPI.Enums.CulinaryRecipeStatusEnums.QueryEnums
{
    public enum GetCulinaryRecipeEnum
    {
        [Description("An uknown error has occured. Please contact support.")]
        Undefined = 0,
        [Description("Successfully obtained Culinary Recipe Information.")]
        Success = 1,
        [Description("Culinary Recipe not found.")]
        CulinaryRecipeNotFound = 2,
        [Description("Culinary Recipe is deleted. Please use another one.")]
        CulinaryRecipeIsDeleted = 3,
        [Description("Culinary Recipe Uid is not found.")]
        UidIsNull = 4
    }
}
