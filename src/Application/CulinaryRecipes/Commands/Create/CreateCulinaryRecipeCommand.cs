using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using CookingMasterApi.Application.Common.Mappings;
using CookingMasterApi.Application.IngredientCategories.Commands.Create;
using CookingMasterApi.Domain.Entities;
using MediatR;

namespace CookingMasterApi.Application.CulinaryRecipes.Commands.Create;
public class CreateCulinaryRecipeCommand : IRequest<CreateCulinaryRecipeCommandResult>, IMapFrom<CulinaryRecipe>
{
    public string RecipeName { get; set; }
    public string RecipeDescription { get; set; }
    public CuisineType CuisineType { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<CreateCulinaryRecipeCommand, CulinaryRecipe>()
            .ForMember(dest => dest.Uid, opt => Guid.NewGuid());
    }
}
