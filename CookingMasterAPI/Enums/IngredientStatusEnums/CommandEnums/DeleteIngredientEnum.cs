using System.ComponentModel;

namespace CookingMasterAPI.Enums.IngredientStatusEnums.CommandEnums
{
    public enum DeleteIngredientEnum
    {
        [Description("An uknown error has occured. Please contact support.")]
        Undefined = 0,
        [Description("Successfully Deleted Ingredient.")]
        Success = 1,
        [Description("Ingredient Uid info not valid.")]
        UidIsNull = 2,
        [Description("Ingredients not found.")]
        IngredientsNotFound = 3,
        [Description("Ingredient  not found.")]
        IngredientNotFound = 4
    }
}
