using CookingMasterAPI.Models.Entity;

namespace CookingMasterAPI.Models.Request.CulinaryRecipeRequests
{
    public class CreateCulinaryRecipeRequest
    {
        public string CuisineTypeUid { get; set; } = string.Empty;
        public string UserUid { get; set; } = string.Empty;
        public string RecipeName { get; set; } = string.Empty;
        public string RecipeDescription { get; set; } = string.Empty;
        public required Dictionary<string, short> IngredientUids { get; set; }
    }
}
