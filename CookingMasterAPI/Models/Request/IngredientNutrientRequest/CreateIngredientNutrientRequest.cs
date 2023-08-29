using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CookingMasterAPI.Models.Request.IngredientRequests
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
