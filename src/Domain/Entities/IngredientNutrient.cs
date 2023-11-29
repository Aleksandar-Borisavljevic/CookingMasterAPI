using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookingMasterApi.Domain.Entities;
    public class IngredientNutrient : BaseAuditableEntity
{
    public int Id { get; set; }
    public decimal Calories { get; set; }
    public decimal Protein { get; set; }
    public decimal Carbohydrates { get; set; }
    public decimal Fat { get; set; }
    public decimal Sugar { get; set; }
    public Guid Uid { get; set; } = Guid.NewGuid();
}
