using System.ComponentModel;

namespace CookingMasterAPI.Enums.IngNutrientStatusEnums.QueryEnums
{
    public enum GetIngredientNutrientEnum
    {
        [Description("An uknown error has occured. Please contact support.")]
        Undefined = 0,
        [Description("Successfully obtained Ingredient Nutrient Information.")]
        Success = 1,
        [Description("Ingredient Nutrient not found.")]
        IngredientNutrientNotFound = 3,
        [Description("Ingredient Nutrient is deleted. Please use another one.")]
        IngredientNutrientIsDeleted = 4,
        [Description("Ingredient Nutrient Uid is not found.")]
        UidIsNull = 5
    }
}
