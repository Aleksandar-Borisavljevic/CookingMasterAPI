using System.ComponentModel;

namespace CookingMasterAPI.Enums.IngCategoryStatusEnums
{
    public enum GetIngredientCategoryEnum
    {
        [Description("An uknown error has occured. Please contact support.")]
        Undefined = 0,
        [Description("Successfully obtained Ingredient Category Information.")]
        Success = 1,
        [Description("No Ingredient Categories were found.")]
        IngredientCategoriesNotFound = 2,
        [Description("Ingredient Category not found.")]
        IngredientCategoryNotFound = 3
    }
}
