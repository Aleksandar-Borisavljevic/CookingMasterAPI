namespace CookingMasterAPI.Models.Request.IngredientCategoryRequests
{
    public abstract class BaseIngredientCategoryRequest
    {
        public string CategoryName { get; set; } = string.Empty;

        public string IconPath { get; set; } = string.Empty;
    }
}
