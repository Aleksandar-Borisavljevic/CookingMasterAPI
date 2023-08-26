namespace CookingMasterAPI.Models.Response
{
    public record IngredientResponse
    (
        int IngredientId,
        string IngredientName,
        string IconPath,
        DateTime CreateDate,
        DateTime? DeleteDate,
        IngredientCategoryResponse IngredientCategory,
        string Uid

    );
}
