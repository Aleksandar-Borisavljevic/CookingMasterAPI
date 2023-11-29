using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookingMasterApi.Domain.Entities;
    public class Ingredient : BaseAuditableEntity
{
        public int Id { get; set; }
        public int IngredientCategoryId { get; set; }
        public IngredientCategory IngredientCategory { get; set; }
        public int IngredientNutrientId { get; set; }
        public IngredientNutrient IngredientNutrient { get; set; }
        public string IngredientName { get; set; }
        public string IconPath { get; set; }
        public short UnitOfMeasure { get; set; }
        public Guid Uid { get; set; } = Guid.NewGuid();
}
