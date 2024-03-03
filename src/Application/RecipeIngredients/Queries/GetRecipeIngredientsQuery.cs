using AutoMapper;
using AutoMapper.QueryableExtensions;
using CookingMasterApi.Application.Common.Interfaces;
using CookingMasterApi.Application.Ingredients.Queries;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CookingMasterApi.Application.RecipeIngredients.Queries;

public class GetRecipeIngredientsQuery : IRequest<IEnumerable<IngredientDto>>
{
    public Guid RecipeUid { get; set; }
}

public class GetRecipeIngredientsHandler : IRequestHandler<GetRecipeIngredientsQuery, IEnumerable<IngredientDto>>
{
    private readonly ICookingMasterDbContext _context;
    private readonly IMapper _mapper;

    public GetRecipeIngredientsHandler(ICookingMasterDbContext context, IMapper mapper, ICurrentUserService currentUserService)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<IEnumerable<IngredientDto>> Handle(GetRecipeIngredientsQuery request, CancellationToken cancellationToken)
    {
        var recipe = _context.CulinaryRecipes.SingleOrDefault(x => x.Uid == request.RecipeUid);

        if (recipe == null)
        {
            return null;
        }

        var ingredients = _context.Ingredients
            .Where(i => _context.RecipeIngredients
            .Any(ri => ri.CulinaryRecipeId == recipe.Id && ri.IngredientId == i.Id))
            .ProjectTo<IngredientDto>(_mapper.ConfigurationProvider)
            .AsNoTracking()
            .ToList();

        return ingredients;
    }
}
