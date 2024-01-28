using AutoMapper;
using AutoMapper.QueryableExtensions;
using CookingMasterApi.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CookingMasterApi.Application.Ingredients.Queries;
public class GetIngredientsQuery : IRequest<IQueryable<IngredientDto>>
{

}

public class GetIngredientHandler : IRequestHandler<GetIngredientsQuery, IQueryable<IngredientDto>>
{
    private readonly ICookingMasterDbContext _context;
    private readonly IMapper _mapper;

    public GetIngredientHandler(ICookingMasterDbContext context, IMapper mapper, ICurrentUserService currentUserService)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<IQueryable<IngredientDto>> Handle(GetIngredientsQuery request, CancellationToken cancellationToken)
    {
        return _context.Ingredients.ProjectTo<IngredientDto>(_mapper.ConfigurationProvider).AsNoTracking();
    }
}
