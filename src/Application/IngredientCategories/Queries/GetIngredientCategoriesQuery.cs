using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using CookingMasterApi.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CookingMasterApi.Application.IngredientCategories.Queries;
public class GetIngredientCategoriesQuery : IRequest<IQueryable<IngredientCategoryDto>>
{

}

public class GetIngredientCategoryHandler : IRequestHandler<GetIngredientCategoriesQuery, IQueryable<IngredientCategoryDto>>
{
    private readonly ICookingMasterDbContext _context;
    private readonly IMapper _mapper;
    private readonly ICurrentUserService _currentUserService;

    public GetIngredientCategoryHandler(ICookingMasterDbContext context, IMapper mapper, ICurrentUserService currentUserService)
    {
        _context = context;
        _mapper = mapper;
        _currentUserService = currentUserService;
    }

    public async Task<IQueryable<IngredientCategoryDto>> Handle(GetIngredientCategoriesQuery request, CancellationToken cancellationToken)
    {
        var userId = _currentUserService.UserId;
        return _context.IngredientCategories.ProjectTo<IngredientCategoryDto>(_mapper.ConfigurationProvider).AsNoTracking();
    }
}
