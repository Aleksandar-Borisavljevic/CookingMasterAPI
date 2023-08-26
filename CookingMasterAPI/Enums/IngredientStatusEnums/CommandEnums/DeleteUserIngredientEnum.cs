using System.ComponentModel;

namespace CookingMasterAPI.Enums.IngredientStatusEnums.CommandEnums
{
    public enum DeleteUserIngredientEnum
    {
        [Description("An uknown error has occured. Please contact support.")]
        Undefined = 0,
        [Description("Successfully Created UserIngredient.")]
        Success = 1,
        [Description("UserUid info not valid.")]
        UserUidIsNull = 2,
        [Description("IngredientUid info not valid.")]
        IngredientUidIsNull = 3,
        [Description("UserIngredient not found.")]
        UserIngredientNotFound = 4
    }
}
