using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CookingMasterApi.Application.Common.Mappings;
using CookingMasterApi.Domain.Entities;

namespace CookingMasterApi.Application.IngredientCategories.Queries;
public class IngredientCategoryDto : IMapFrom<IngredientCategory>
{
    public string CategoryName { get; set; }
    public string IconPath { get; set; }
}
