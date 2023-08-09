using System.ComponentModel;

namespace CookingMasterAPI.Enums.IngCategoryStatusEnums.QueryEnums
{
    public enum GetIngredientCategoriesEnum
    {
        //TODO: Change this to fit the coresponding ENUM
        [Description("An uknown error has occured. Please contact support.")]
        Undefined = 0,
        [Description("Successfully obtained Ingredient Category Information.")]
        Success = 1,
        [Description("Ingredient Categories not found.")]
        IngredientCategoriesNotFound = 2
    }
}
