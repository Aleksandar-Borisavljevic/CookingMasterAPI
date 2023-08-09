using System.ComponentModel;

namespace CookingMasterAPI.Enums.IngCategoryStatusEnums.CommandEnums
{
    public enum CreateIngredientCategoryEnum
    {
        //TODO: Sort these statuses later on
        [Description("An uknown error has occured. Please contact support.")]
        Undefined = 0,
        [Description("Successfully Created Ingredient Category.")]
        Success = 1,
        [Description("Category info not valid.")]
        RequestIsNull  = 2,
        IsValid = 3
    }
}
