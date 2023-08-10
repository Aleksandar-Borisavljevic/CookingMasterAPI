namespace CookingMasterAPI.Models.Response
{
    public record IngredientCategoryResponse
    (        
        string CategoryName,
        string IconPath,
        DateTime CreateDate,
        DateTime? DeleteDate,
        string Uid
    );
}
