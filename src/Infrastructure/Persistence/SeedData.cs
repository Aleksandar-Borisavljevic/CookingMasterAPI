using CookingMasterApi.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CookingMasterApi.Infrastructure.Persistence;
public static class SeedData
{
    private const string _RECIPE_DESCRIPTION = "Instructions:\r\n\r\nCook the spaghetti according to package instructions. Drain and set aside.\r\n\r\nIn a large pan, heat olive oil over medium heat. Add the chopped onion and sauté until softened.\r\n\r\nAdd minced garlic to the pan and sauté for another 1-2 minutes until fragrant.\r\n\r\nAdd ground beef to the pan and cook until browned, breaking it apart with a spoon as it cooks.\r\n\r\nStir in grated carrots and chopped celery. Cook for a few minutes until the vegetables begin to soften.\r\n\r\nAdd crushed tomatoes, tomato paste, dried oregano, and dried basil to the pan. Season with salt and pepper to taste. Stir well to combine.\r\n\r\nReduce the heat to low, cover the pan, and let the sauce simmer for at least 20-30 minutes to allow the flavors to meld.\r\n\r\nTaste and adjust the seasoning if necessary.\r\n\r\nServe the Bolognese sauce over the cooked spaghetti.\r\n\r\nOptionally, garnish with grated Parmesan cheese and fresh basil or parsley.\r\n\r\nEnjoy your homemade Spaghetti Bolognese! Feel free to customize the recipe based on your preferences.";

    public static void SeedCuisineTypes(ModelBuilder builder)
    {
        builder.Entity<CuisineType>().HasData(
            new CuisineType { Id = 1, Uid = Guid.NewGuid(), CuisineName = "Italian", Created = DateTime.Now },
            new CuisineType { Id = 2, Uid = Guid.NewGuid(), CuisineName = "Indian", Created = DateTime.Now },
            new CuisineType { Id = 3, Uid = Guid.NewGuid(), CuisineName = "Mexican", Created = DateTime.Now },
            new CuisineType { Id = 4, Uid = Guid.NewGuid(), CuisineName = "Chinese", Created = DateTime.Now },
            new CuisineType { Id = 5, Uid = Guid.NewGuid(), CuisineName = "French", Created = DateTime.Now },
            new CuisineType { Id = 6, Uid = Guid.NewGuid(), CuisineName = "Thai", Created = DateTime.Now }
        );
    }

    public static void SeedIngredientCategories(ModelBuilder builder)
    {
        builder.Entity<IngredientCategory>().HasData(
            new IngredientCategory { Id = 1, Uid = Guid.NewGuid(), CategoryName = "Fruit", IconPath = "fruit", Created = DateTime.Now },
            new IngredientCategory { Id = 2, Uid = Guid.NewGuid(), CategoryName = "Vegetables", IconPath = "vegetables", Created = DateTime.Now },
            new IngredientCategory { Id = 3, Uid = Guid.NewGuid(), CategoryName = "Spices", IconPath = "spices", Created = DateTime.Now },
            new IngredientCategory { Id = 4, Uid = Guid.NewGuid(), CategoryName = "Meat", IconPath = "meat", Created = DateTime.Now },
            new IngredientCategory { Id = 5, Uid = Guid.NewGuid(), CategoryName = "Seafood", IconPath = "seafood", Created = DateTime.Now },
            new IngredientCategory { Id = 6, Uid = Guid.NewGuid(), CategoryName = "Cereals", IconPath = "cereals", Created = DateTime.Now },
            new IngredientCategory { Id = 7, Uid = Guid.NewGuid(), CategoryName = "Dairy Product", IconPath = "dairyproduct", Created = DateTime.Now },
            new IngredientCategory { Id = 8, Uid = Guid.NewGuid(), CategoryName = "Nuts", IconPath = "nuts", Created = DateTime.Now },
            new IngredientCategory { Id = 9, Uid = Guid.NewGuid(), CategoryName = "Other", IconPath = "other", Created = DateTime.Now }
        );
    }

    public static void SeedIngredientNutrients(ModelBuilder builder)
    {
        builder.Entity<IngredientNutrient>().HasData(
            new IngredientNutrient { Id = 1, Uid = Guid.NewGuid(), Calories = 105, Protein = 1.3m, Carbohydrates = 27, Fat = 1, Sugar = 14, Created = DateTime.Now }
        );
    }

    public static void SeedIngredients(ModelBuilder builder)
    {
        builder.Entity<Ingredient>().HasData(
            new Ingredient { Id = 1, Uid = Guid.NewGuid(), IngredientName = "Banana", IconPath = "banana", IngredientCategoryId = 1, IngredientNutrientId = 1, Created = DateTime.Now }
        );
    }

    public static void SeedCulinaryRecipe(ModelBuilder builder)
    {
        builder.Entity<CulinaryRecipe>().HasData(
            new CulinaryRecipe { Id = 1, Uid = Guid.NewGuid(), RecipeName = "Spaghetti Bolognese", RecipeDescription = _RECIPE_DESCRIPTION, CuisineTypeId = 1, Created = DateTime.Now }
        );
    }

    public static void SeedRecipeIngredients(ModelBuilder builder)
    {
        builder.Entity<RecipeIngredient>().HasData(
            new RecipeIngredient { Id = 1, CulinaryRecipeId = 1, IngredientId = 1, Created = DateTime.Now }
        );
    }
}
