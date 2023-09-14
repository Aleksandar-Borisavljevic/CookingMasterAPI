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
        [Column(TypeName = "nvarchar(200)")]
        public string RecipeName { get; set; } = string.Empty;

        [Required]
        [Column(TypeName = "nvarchar(MAX)")]
        public string RecipeDescription { get; set; } = string.Empty;

        [Required]
        public DateTime CreateDate { get; set; }
        public DateTime? DeleteDate { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        public string Uid { get; set; } = string.Empty;
    }
}
