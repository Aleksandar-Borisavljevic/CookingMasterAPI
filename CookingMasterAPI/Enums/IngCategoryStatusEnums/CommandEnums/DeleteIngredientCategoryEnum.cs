using System.ComponentModel;

namespace CookingMasterAPI.Enums.IngCategoryStatusEnums.CommandEnums
{
    public enum DeleteIngredientCategoryEnum
    {
        //TODO: Sort these statuses later on
        [Description("An uknown error has occured. Please contact support.")]
        Undefined = 0,
        [Description("Successfully Deleted Ingredient Category.")]
        Success = 1,
        [Description("Category info not valid.")]
        UidIsNull = 2,
        [Description("Ingredient Categories not found.")]
        IngredientCategoriesNotFound = 3,
        [Description("Ingredient Category not found.")]
        IngredientCategoryNotFound = 4
    }
}
