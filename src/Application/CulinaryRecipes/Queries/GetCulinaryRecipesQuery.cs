using AutoMapper;
using AutoMapper.QueryableExtensions;
using CookingMasterApi.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CookingMasterApi.Application.CulinaryRecipes.Queries;
public class GetCulinaryRecipesQuery : IRequest<IQueryable<CulinaryRecipeDto>>
{

}

public class GetCulinaryRecipesHandler : IRequestHandler<GetCulinaryRecipesQuery, IQueryable<CulinaryRecipeDto>>
{
    private readonly ICookingMasterDbContext _context;
    private readonly IMapper _mapper;

    public GetCulinaryRecipesHandler(ICookingMasterDbContext context, IMapper mapper, ICurrentUserService currentUserService)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<IQueryable<CulinaryRecipeDto>> Handle(GetCulinaryRecipesQuery request, CancellationToken cancellationToken)
    {
        return _context.CulinaryRecipes.ProjectTo<CulinaryRecipeDto>(_mapper.ConfigurationProvider).AsNoTracking();
    }
}
