namespace CookingMasterAPI.Models.Request.IngredientNutrientRequests
{
    public class CreateIngredientNutrientRequest
    {
        public string? IngredientUid { get; set; }

        public decimal Calories { get; set; }

        public decimal Protein { get; set; }

        public decimal Carbohydrates { get; set; }

        public decimal Fat { get; set; }

        public decimal Sugar { get; set; }
    }
}
