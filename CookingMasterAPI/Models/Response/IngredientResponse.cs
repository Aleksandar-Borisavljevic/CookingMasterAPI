namespace CookingMasterAPI.Models.Response
{
    public record IngredientResponse
    (
        int IngredientId,
        string IngredientName,
        string IconPath,
        short UnitOfMeasure,
        short Amount,
        DateTime CreateDate,
        DateTime? DeleteDate,
        IngredientNutrientResponse IngredientNutrient,
        IngredientCategoryResponse IngredientCategory,
        string Uid
    );
}
