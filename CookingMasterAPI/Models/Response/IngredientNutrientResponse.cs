namespace CookingMasterAPI.Models.Response
{
    public record IngredientNutrientResponse
    (       
        decimal Calories,
        decimal Protein,
        decimal Carbohydrates,
        decimal Fat,
        decimal Sugar,
        string Uid
    );
}
