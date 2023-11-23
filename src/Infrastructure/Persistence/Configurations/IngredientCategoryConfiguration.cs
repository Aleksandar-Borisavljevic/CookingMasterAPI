using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CookingMasterApi.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CookingMasterApi.Infrastructure.Persistence.Configurations;
public class IngredientCategoryConfiguration : IEntityTypeConfiguration<IngredientCategory>
{
    public void Configure(EntityTypeBuilder<IngredientCategory> builder)
    {
        builder.Property(t => t.CategoryName)
            .IsRequired()
            .HasMaxLength(50);

        builder.Property(t => t.IconPath)
            .IsRequired()
            .HasMaxLength(50);
    }
}
