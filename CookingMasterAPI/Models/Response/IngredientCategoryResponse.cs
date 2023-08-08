namespace CookingMasterAPI.Models.Response
{
    public record IngredientCategoryResponse
    (
        int CategoryId,
        string CategoryName,
        string IconPath,
        DateTime CreateDate,
        DateTime? DeleteDate
    );
}
