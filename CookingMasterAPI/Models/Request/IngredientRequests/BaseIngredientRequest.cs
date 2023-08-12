namespace CookingMasterAPI.Models.Request.IngredientRequests
{
    public abstract class BaseIngredientRequest
    {
        public string IngredientName { get; set; } = string.Empty;

        public string IconPath { get; set; } = string.Empty;
    }
}
