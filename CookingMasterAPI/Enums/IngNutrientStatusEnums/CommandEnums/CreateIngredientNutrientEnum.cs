using System.ComponentModel;

namespace CookingMasterAPI.Enums.IngNutrientStatusEnums.CommandEnums
{
    public enum CreateIngredientNutrientEnum
    {
        [Description("An uknown error has occured. Please contact support.")]
        Undefined = 0,
        [Description("Successfully Created Ingredient Nutrients.")]
        Success = 1,
        [Description("Ingredient Nutrient info not valid.")]
        RequestIsNull = 2,
        ResultIsNull = 3,
        [Description("Ingredient Nutrients already exist.")]
        IngredientNutrientsAlreadyExist = 4,
        RequestIsValid = 5
    }
}
