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

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        base.OnModelCreating(builder);

        builder.Entity<CulinaryRecipe>()
               .Property(b => b.RecipeName)
               .IsRequired();
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
