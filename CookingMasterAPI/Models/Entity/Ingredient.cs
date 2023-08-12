using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace CookingMasterAPI.Models.Entity
{
    public class Ingredient
    {
        [Key]
        public int IngredientId { get; set; }

        [ForeignKey("CategoryId")]
        public IngredientCategory? IngredientCategory { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(100)")]
        public string IngredientName { get; set; } = string.Empty;

        [Required]
        [Column(TypeName = "nvarchar(50)")]
        public string IconPath { get; set; } = string.Empty;

        [Required]
        public DateTime CreateDate { get; set; }

        public DateTime? DeleteDate { get; set; }


        [Required]
        [Column(TypeName = "nvarchar(100)")]
        public string Uid { get; set; } = string.Empty;
    }
}
