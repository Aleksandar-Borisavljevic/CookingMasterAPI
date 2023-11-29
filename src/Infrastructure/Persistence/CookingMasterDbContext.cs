using System.Reflection;
using System.Reflection.Emit;
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
    public DbSet<IngredientCategory> IngredientCategories => Set<IngredientCategory>();
    public DbSet<IngredientNutrient> IngredientNutrients => Set<IngredientNutrient>();
    public DbSet<Ingredient> Ingredients => Set<Ingredient>();

    protected override void OnModelCreating(ModelBuilder builder) //TODO: separate file for seed data
    {
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        base.OnModelCreating(builder);

        builder.Entity<CuisineType>().HasData(
          new CuisineType { Id = -1, Uid = Guid.NewGuid(), CuisineName = "Italian"},
          new CuisineType { Id = -2, Uid = Guid.NewGuid(), CuisineName = "Indian" },
          new CuisineType { Id = -3, Uid = Guid.NewGuid(), CuisineName = "Mexican" },
          new CuisineType { Id = -4, Uid = Guid.NewGuid(), CuisineName = "Chinese" },
          new CuisineType { Id = -5, Uid = Guid.NewGuid(), CuisineName = "French" },
          new CuisineType { Id = -6, Uid = Guid.NewGuid(), CuisineName = "Thai" }
      );
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
