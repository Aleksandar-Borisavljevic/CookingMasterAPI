using CookingMasterApi.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CookingMasterApi.Application.Common.Interfaces;

public interface ICookingMasterDbContext
{
    DbSet<CuisineType> CuisineTypes { get; }
    DbSet<CulinaryRecipe> CulinaryRecipes { get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}
