using System.ComponentModel;

namespace CookingMasterAPI.Enums.IngredientStatusEnums.QueryEnums
{
    public enum GetIngredientEnum
    {
        [Description("An uknown error has occured. Please contact support.")]
        Undefined = 0,
        [Description("Successfully obtained Ingredient Category Information.")]
        Success = 1,
        [Description("No Ingredient Categories were found.")]
        IngredientsNotFound = 2,
        [Description("Ingredient Category not found.")]
        IngredientNotFound = 3,
        [Description("Category is deleted. Please use another one.")]
        IngredientIsDeleted = 4,
        [Description("Ingredient Uid info not valid.")]
        UidIsNull = 5
    }
}
