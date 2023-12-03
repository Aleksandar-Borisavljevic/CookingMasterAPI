using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using CookingMasterApi.Application.Common.Interfaces;
using CookingMasterApi.Application.CulinaryRecipes.Commands.Create;
using CookingMasterApi.Domain.Entities;
using CookingMasterApi.Infrastructure.Persistence.Configurations;
using Microsoft.EntityFrameworkCore;

namespace CookingMasterApi.Infrastructure.Services;
public class CulinaryRecipeService : ICulinaryRecipeService
{
    private readonly ICookingMasterDbContext _context;
    private readonly IMapper _mapper;
    public CulinaryRecipeService(ICookingMasterDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<CulinaryRecipe> CreateAsync(CreateCulinaryRecipeCommand request, CancellationToken cancellationToken)
    {
        var cuisineType = await _context.CuisineTypes.FirstOrDefaultAsync(x => x.Uid == request.CuisineTypeUid);

        if (cuisineType is null)
        {
            //TODO throw some exception
        }

        var entity = _mapper.Map<CulinaryRecipe>(request);

        entity.CuisineType = cuisineType;

        var result = (await _context.CulinaryRecipes.AddAsync(entity)).Entity;

        await _context.SaveChangesAsync(cancellationToken);

        return result;
    }
}
