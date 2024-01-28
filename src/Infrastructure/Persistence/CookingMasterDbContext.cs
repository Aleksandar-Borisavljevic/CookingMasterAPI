using System.Reflection;
using CookingMasterApi.Application.Common.Interfaces;
using CookingMasterApi.Domain.Entities;
using CookingMasterApi.Infrastructure.Identity;
using CookingMasterApi.Infrastructure.Persistence.Interceptors;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CookingMasterApi.Infrastructure.Persistence;

public class CookingMasterDbContext : IdentityDbContext<ApplicationUser>, ICookingMasterDbContext
{
    private readonly AuditableEntitySaveChangesInterceptor _auditableEntitySaveChangesInterceptor;

    public CookingMasterDbContext(
        DbContextOptions<CookingMasterDbContext> options,
        AuditableEntitySaveChangesInterceptor auditableEntitySaveChangesInterceptor): base(options)
    {
        _auditableEntitySaveChangesInterceptor = auditableEntitySaveChangesInterceptor;
    }
    public DbSet<CuisineType> CuisineTypes => Set<CuisineType>();
    public DbSet<CulinaryRecipe> CulinaryRecipes => Set<CulinaryRecipe>();
    public DbSet<RefreshToken> RefreshTokens => Set<RefreshToken>();
    public DbSet<FileDetails> FileDetails => Set<FileDetails>();
    public DbSet<IngredientCategory> IngredientCategories => Set<IngredientCategory>();
    public DbSet<IngredientNutrient> IngredientNutrients => Set<IngredientNutrient>();
    public DbSet<Ingredient> Ingredients => Set<Ingredient>();
    public DbSet<RecipeIngredient> RecipeIngredients => Set<RecipeIngredient>();

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        base.OnModelCreating(builder);

        SeedData.SeedCuisineTypes(builder);
        SeedData.SeedIngredientCategories(builder);
        SeedData.SeedIngredientNutrients(builder);
        SeedData.SeedIngredients(builder);
        SeedData.SeedCulinaryRecipe(builder);
        SeedData.SeedRecipeIngredients(builder);
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.AddInterceptors(_auditableEntitySaveChangesInterceptor);
    }

    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        return await base.SaveChangesAsync(cancellationToken);
    }
}
