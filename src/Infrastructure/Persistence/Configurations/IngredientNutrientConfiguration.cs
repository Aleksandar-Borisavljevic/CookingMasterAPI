using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CookingMasterApi.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CookingMasterApi.Infrastructure.Persistence.Configurations;
public class IngredientNutrientConfiguration : IEntityTypeConfiguration<IngredientNutrient>
{
    public void Configure(EntityTypeBuilder<IngredientNutrient> builder)
    {
       
    }
}
