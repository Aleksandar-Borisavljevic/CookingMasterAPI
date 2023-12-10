using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CookingMasterApi.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CookingMasterApi.Infrastructure.Persistence.Configurations;
public class IngredientConfiguration : IEntityTypeConfiguration<Ingredient>
{
    public void Configure(EntityTypeBuilder<Ingredient> builder)
    {
        builder.Property(t => t.IngredientName)
            .IsRequired()
            .HasMaxLength(100);
        builder.Property(t => t.IconPath)
            .IsRequired()
            .HasMaxLength(50);
    }
}
