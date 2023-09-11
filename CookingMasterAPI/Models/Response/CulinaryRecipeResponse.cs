namespace CookingMasterAPI.Models.Response
{
    public record CulinaryRecipeResponse
    (
        string CuisineType,
        UserResponse? User,
        IEnumerable<IngredientResponse>? Ingredients,
        string RecipeName,
        string RecipeDescription,
        string Uid
    );
}
