using System.ComponentModel;

namespace CookingMasterAPI.Enums.IngredientStatusEnums.CommandEnums
{
    public enum CreateIngredientEnum
    {
        [Description("An uknown error has occured. Please contact support.")]
        Undefined = 0,
        [Description("Successfully Created Ingredient Category.")]
        Success = 1,
        [Description("Ingredient Category info not valid.")]
        RequestIsNull = 2,
        [Description("Ingredient Category already exists.")]
        RecordAlreadyExists = 3,
        RequestIsValid = 4
    }
}
