namespace CookingMasterAPI.Models.Request.IngredientRequests
{
    public class CreateIngredientRequest : BaseIngredientRequest
    {
        public string? IngredientCategoryUid { get; set; }
    }
}
