using System.ComponentModel;

namespace CookingMasterAPI.Enums.IngredientStatusEnums.QueryEnums
{
    public enum GetIngredientsEnum
    {
        //TODO: Change this to fit the coresponding ENUM
        [Description("An uknown error has occured. Please contact support.")]
        Undefined = 0,
        [Description("Successfully obtained Ingredient Category Information.")]
        Success = 1,
        [Description("Ingredient Categories not found.")]
        IngredientsNotFound = 2
    }
}
