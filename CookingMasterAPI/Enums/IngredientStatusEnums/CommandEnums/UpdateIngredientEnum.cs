using System.ComponentModel;

namespace CookingMasterAPI.Enums.IngredientStatusEnums.CommandEnums
{
    public enum UpdateIngredientEnum
    {
        //TODO: Sort this enum to accordingly
        [Description("An uknown error has occured. Please contact support.")]
        Undefined = 0,
        [Description("Successfully Updated Ingredient Category.")]
        Success = 1,
        [Description("Ingredient Category info not valid.")]
        RequestIsNull = 2,
        [Description("Ingredient Category Not Found.")]
        NotFound = 3,
        RequestIsValid = 4,
        [Description("Ingredient Uid not found.")]
        UidNotFound = 5
    }
}
