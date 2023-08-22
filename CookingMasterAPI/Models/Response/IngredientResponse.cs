namespace CookingMasterAPI.Models.Response
{
    public record IngredientResponse
    (        
        string IngredientName,
        string IconPath,
        DateTime CreateDate,
        DateTime? DeleteDate,
        IngredientCategoryResponse IngredientCategory,
        string Uid

    );
}
