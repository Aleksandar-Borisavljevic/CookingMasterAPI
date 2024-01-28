using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CookingMasterApi.Application.Ingredients.Queries;

namespace CookingMasterApi.Application.RecipeIngredients.Queries;
public class RecipeIngredientDto 
{
    public IEnumerable<IngredientDto> Ingredients { get; set; }
}
