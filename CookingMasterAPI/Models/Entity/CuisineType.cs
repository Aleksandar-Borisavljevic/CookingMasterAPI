using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CookingMasterAPI.Models.Entity
{
    public class CuisineType
    {
        [Key]
        public int CuisineId { get; set; }

        [Required]
        public string CuisineName { get; set; } = string.Empty;

        [Required]
        [Column(TypeName = "nvarchar(100)")]
        public string Uid { get; set; } = string.Empty;
    }
}
