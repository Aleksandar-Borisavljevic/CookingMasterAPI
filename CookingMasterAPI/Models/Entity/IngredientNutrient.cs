using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CookingMasterAPI.Models.Entity
{
    public class IngredientNutrient
    {
        [Key]
        public int IngredientNutrientId { get; set; }

        [Required]
        [ForeignKey("IngredientId")]
        public Ingredient? Ingredient { get; set; }

        [Required]
        [Column(TypeName = "decimal(4, 2)")]
        public decimal Calories { get; set; }

        [Required]
        [Column(TypeName = "decimal(4, 2)")]
        public decimal Protein { get; set; }

        [Required]
        [Column(TypeName = "decimal(4, 2)")]
        public decimal Carbohydrates { get; set; }

        [Required]
        [Column(TypeName = "decimal(4, 2)")]
        public decimal Fat { get; set; }

        [Required]
        [Column(TypeName = "decimal(4, 2)")]
        public decimal Sugar { get; set; }

        [Required]
        public DateTime CreateDate { get; set; }
        public DateTime? DeleteDate { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(100)")]
        public string Uid { get; set; } = string.Empty;
    }
}
