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

namespace CookingMasterApi.Application.CulinaryRecipes.Commands.Create;
public class CreateCulinaryRecipeCommandHandler : IRequestHandler<CreateCulinaryRecipeCommand, CreateCulinaryRecipeCommandResult>
{
    private readonly ICookingMasterDbContext _context;
    private readonly IMapper _mapper;

    public CreateCulinaryRecipeCommandHandler(ICookingMasterDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    public async Task<CreateCulinaryRecipeCommandResult> Handle(CreateCulinaryRecipeCommand request, CancellationToken cancellationToken)
    {
        var entity = _mapper.Map<CulinaryRecipe>(request);
        var result = (await _context.CulinaryRecipes.AddAsync(entity)).Entity;

        await _context.SaveChangesAsync(cancellationToken);

        return new CreateCulinaryRecipeCommandResult(result.RecipeName, result.RecipeDescription, result.CuisineType);
    }
}
