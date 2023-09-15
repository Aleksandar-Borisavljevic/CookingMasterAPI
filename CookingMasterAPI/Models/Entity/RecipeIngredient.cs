using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CookingMasterAPI.Models.Entity
{
    public class RecipeIngredient
    {
        [Key]
        public int RecipeIngredientId { get; set; }

        [ForeignKey("CulinaryRecipeId")]
        public CulinaryRecipe? CulinaryRecipe { get; set; }

        [ForeignKey("IngredientId")]
        public Ingredient? Ingredient { get; set; }

        [Required]
        public short Amount { get; set; }
    }
}
