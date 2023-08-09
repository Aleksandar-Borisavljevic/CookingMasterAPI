namespace CookingMasterAPI.Models.Request.IngredientCategoryRequests
{
    public class CreateCategoryRequest
    {
        public string CategoryName { get; set; } = string.Empty;

        public string IconPath { get; set; } = string.Empty;
    }
}
