using CookingMasterApi.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CookingMasterApi.Infrastructure.Persistence.Configurations;

public class CulinaryRecipeConfiguration : IEntityTypeConfiguration<CulinaryRecipe>
{
    public void Configure(EntityTypeBuilder<CulinaryRecipe> builder)
    {
        builder.Property(t => t.RecipeName).IsRequired();
    }
}
