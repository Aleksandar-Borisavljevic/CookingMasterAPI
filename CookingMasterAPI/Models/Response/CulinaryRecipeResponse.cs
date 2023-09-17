namespace CookingMasterAPI.Models.Response
{
    public record CulinaryRecipeResponse
    (
        string CuisineType,
        UserResponse? User,
        IEnumerable<IngredientResponse>? Ingredients,
        IngredientNutrientResponse? Nutrients,
        string RecipeName,
        string RecipeDescription,
        string Uid
    );
}
