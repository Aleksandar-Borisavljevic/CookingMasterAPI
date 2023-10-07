using System.ComponentModel;

namespace CookingMasterAPI.Enums.CuisineTypeEnums.QueryEnums
{
    public enum GetCuisineTypesEnum
    {
        [Description("An uknown error has occured. Please contact support.")]
        Undefined = 0,
        [Description("Successfully obtained Culinary Recipes Information.")]
        Success = 1,
        [Description("Culinary Recipes not found.")]
        CuisineTypesNotFound = 2,
        [Description("Culinary Recipes are deleted. Please use another one.")]
        CulinaryRecipesAreDeleted = 3,
        [Description("Culinary Recipes Uid is not found.")]
        UidIsNull = 4
    }
}
