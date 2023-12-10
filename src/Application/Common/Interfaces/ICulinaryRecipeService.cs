using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CookingMasterApi.Application.CulinaryRecipes.Commands.Create;
using CookingMasterApi.Domain.Entities;

namespace CookingMasterApi.Application.Common.Interfaces;
public interface ICulinaryRecipeService
{
    Task<CulinaryRecipe> CreateAsync(CreateCulinaryRecipeCommand request, CancellationToken cancellationToken);
}
