using CookingMasterApi.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CookingMasterApi.Application.Common.Interfaces;

public interface ICookingMasterDbContext
{
    DbSet<CuisineType> CuisineTypes { get; }
    DbSet<CulinaryRecipe> CulinaryRecipes { get; }
    DbSet<RefreshToken> RefreshTokens { get; }
    DbSet<FileDetails> FileDetails { get; }
    DbSet<IngredientCategory> IngredientCategories { get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}
