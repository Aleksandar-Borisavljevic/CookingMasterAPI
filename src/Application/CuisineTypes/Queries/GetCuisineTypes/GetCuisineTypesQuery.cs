using AutoMapper;
using AutoMapper.QueryableExtensions;
using CookingMasterApi.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CookingMasterApi.Application.CuisineTypes.Queries.GetCuisineTypes;

public record GetCuisineTypesQuery : IRequest<IQueryable<CuisineTypeDto>>
{
}

public class GetCuisineTypesQueryHandler : IRequestHandler<GetCuisineTypesQuery, IQueryable<CuisineTypeDto>>
{
    private readonly ICookingMasterDbContext _context;
    private readonly IMapper _mapper;

    public GetCuisineTypesQueryHandler(ICookingMasterDbContext context, IMapper mapper, ICurrentUserService currentUserService)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<IQueryable<CuisineTypeDto>> Handle(GetCuisineTypesQuery request, CancellationToken cancellationToken)
    {
        return _context.CuisineTypes.ProjectTo<CuisineTypeDto>(_mapper.ConfigurationProvider).AsNoTracking();
    }
}
