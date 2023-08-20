using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CookingMasterAPI.Models.Entity
{
    public class UserIngredient
    {
        [Key]
        public int UserIngredientId { get; set; }

        [Required]
        [ForeignKey("IngredientId")]
        public Ingredient? Ingredient { get; set; }

        [Required]
        [ForeignKey("UserId")]
        public User? User { get; set; }
    }
}
