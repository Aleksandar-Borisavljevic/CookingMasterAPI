using System.ComponentModel;

namespace CookingMasterAPI.Enums.IngCategoryStatusEnums.CommandEnums
{
    public enum CreateIngredientCategoryEnum
    {
        [Description("An uknown error has occured. Please contact support.")]
        Undefined = 0,
        [Description("Successfully Created Ingredient Category.")]
        Success = 1,
        [Description("Category info not valid.")]
        RequestIsNull = 2,
        RequestIsValid = 3
    }
}
