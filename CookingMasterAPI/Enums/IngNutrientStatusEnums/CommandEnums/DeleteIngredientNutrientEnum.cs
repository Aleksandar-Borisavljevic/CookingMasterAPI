using System.ComponentModel;

namespace CookingMasterAPI.Enums.IngNutrientStatusEnums.CommandEnums
{
    public enum DeleteIngredientNutrientEnum
    {
        [Description("An uknown error has occured. Please contact support.")]
        Undefined = 0,
        [Description("Successfully Deleted Ingredient Nutrient.")]
        Success = 1,
        [Description("Ingredient Nutrient Uid info not valid.")]
        UidIsNull = 2,
        [Description("Ingredient Nutrient not found.")]
        IngredientNutrientNotFound = 3
    }
}
