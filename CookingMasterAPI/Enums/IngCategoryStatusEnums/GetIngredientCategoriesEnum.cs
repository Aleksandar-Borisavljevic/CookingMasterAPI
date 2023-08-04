using System.ComponentModel;

namespace CookingMasterAPI.Enums.IngCategoryStatusEnums
{
    public enum GetIngredientCategoriesEnum
    {
        //TODO: Change this to fit the coresponding ENUM
        [Description("An uknown error has occured. Please contact support.")]
        Undefined = 0,
        [Description("Email with password reset token has been sent to you. Please check your email.")]
        Success = 1,
        [Description("Ingredient not found.")]
        IngredientCategoriesNotFound = 2,
    }
}
