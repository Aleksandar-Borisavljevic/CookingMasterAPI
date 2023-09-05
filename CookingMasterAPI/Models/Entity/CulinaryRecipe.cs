using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CookingMasterAPI.Models.Entity
{
    public class CulinaryRecipe
    {
        #region Keys
        [Key]
        public int CulinaryRecipeId { get; set; }

        [ForeignKey("CuisineTypeId")]
        public CuisineType? CuisineType { get; set; }

        [ForeignKey("UserId")]
        public User? User { get; set; }
        #endregion

        [Required]
        public string RecipeName { get; set; } = string.Empty;

        [Required]
        public string RecipeDescription { get; set; } = string.Empty;

        [Required]
        public DateTime CreateDate { get; set; }
        public DateTime? DeleteDate { get; set; }
        public string Uid { get; set; } = string.Empty;
    }
}
