using System.ComponentModel;

namespace CookingMasterAPI.Enums.IngredientStatusEnums.QueryEnums
{
    public enum GetIngredientsEnum
    {
        //TODO: Change this to fit the coresponding ENUM
        [Description("An uknown error has occured. Please contact support.")]
        Undefined = 0,
        [Description("Successfully obtained Ingredients Information.")]
        Success = 1,
        [Description("Ingredients not found.")]
        IngredientsNotFound = 2
    }
}
