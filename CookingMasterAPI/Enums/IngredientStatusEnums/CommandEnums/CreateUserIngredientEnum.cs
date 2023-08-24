using System.ComponentModel;

namespace CookingMasterAPI.Enums.IngredientStatusEnums.CommandEnums
{
    public enum CreateUserIngredientEnum
    {
        [Description("An uknown error has occured. Please contact support.")]
        Undefined = 0,
        [Description("Successfully Created UserIngredient.")]
        Success = 1,
        [Description("UserUid info not valid.")]
        UserUidIsNull = 2,
        [Description("IngredientUid info not valid.")]
        IngredientUidIsNull = 3,
        [Description("User not found.")]
        UserNotFound = 4,
        [Description("Ingredient not found.")]
        IngredientNotFound = 4,
        [Description("User already has this ingredient.")]
        UserAlreadyHasThisIngredient = 5,
        RequestIsValid = 6
    }
}
