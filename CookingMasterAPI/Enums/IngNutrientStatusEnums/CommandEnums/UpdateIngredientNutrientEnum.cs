using System.ComponentModel;

namespace CookingMasterAPI.Enums.IngNutrientStatusEnums.CommandEnums
{
    public enum UpdateIngredientNutrientEnum
    {
        [Description("An uknown error has occured. Please contact support.")]
        Undefined = 0,
        [Description("Successfully Updated Ingredient Nutrient.")]
        Success = 1,
        [Description("Ingredient Nutrient info not valid.")]
        RequestIsNull = 2,
        [Description("Ingredient Nutrient Not Found.")]
        NotFound = 3,
        RequestIsValid = 4
    }
}
