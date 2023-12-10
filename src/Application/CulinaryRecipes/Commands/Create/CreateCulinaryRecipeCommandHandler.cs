using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using CookingMasterApi.Application.Common.Interfaces;
using CookingMasterApi.Application.IngredientCategories.Commands.Create;
using CookingMasterApi.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CookingMasterApi.Application.CulinaryRecipes.Commands.Create;
public class CreateCulinaryRecipeCommandHandler : IRequestHandler<CreateCulinaryRecipeCommand, CreateCulinaryRecipeCommandResult>
{
    readonly ICulinaryRecipeService _service;
    public CreateCulinaryRecipeCommandHandler(ICulinaryRecipeService service)
    {
        _service = service;
    }
    public async Task<CreateCulinaryRecipeCommandResult> Handle(CreateCulinaryRecipeCommand request, CancellationToken cancellationToken)
    {
        var result = await _service.CreateAsync(request, cancellationToken);

        return new CreateCulinaryRecipeCommandResult(result.RecipeName, result.RecipeDescription, result.CuisineType);
    }
}
