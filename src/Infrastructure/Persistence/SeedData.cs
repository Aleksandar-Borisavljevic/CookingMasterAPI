using CookingMasterApi.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CookingMasterApi.Infrastructure.Persistence;
public static class SeedData
{
    private const string _RECIPE_DESCRIPTION_SPAGGETI = "Instructions:\r\n\r\nCook the spaghetti according to package instructions. Drain and set aside.\r\n\r\nIn a large pan, heat olive oil over medium heat. Add the chopped onion and sauté until softened.\r\n\r\nAdd minced garlic to the pan and sauté for another 1-2 minutes until fragrant.\r\n\r\nAdd ground beef to the pan and cook until browned, breaking it apart with a spoon as it cooks.\r\n\r\nStir in grated carrots and chopped celery. Cook for a few minutes until the vegetables begin to soften.\r\n\r\nAdd crushed tomatoes, tomato paste, dried oregano, and dried basil to the pan. Season with salt and pepper to taste. Stir well to combine.\r\n\r\nReduce the heat to low, cover the pan, and let the sauce simmer for at least 20-30 minutes to allow the flavors to meld.\r\n\r\nTaste and adjust the seasoning if necessary.\r\n\r\nServe the Bolognese sauce over the cooked spaghetti.\r\n\r\nOptionally, garnish with grated Parmesan cheese and fresh basil or parsley.\r\n\r\nEnjoy your homemade Spaghetti Bolognese! Feel free to customize the recipe based on your preferences.";
    private const string _RECIPE_DESCRIPTION_PIZZA = "Preheat the Oven:\r\nPreheat your oven to the temperature recommended for your pizza dough (usually around 450°F or 230°C).\r\n\r\nPrepare the Pizza Dough:\r\nIf using store-bought dough, follow the instructions on the package. If making homemade dough, roll it out on a floured surface to your desired thickness.\r\n\r\nAssemble the Pizza:\r\nPlace the rolled-out pizza dough on a pizza stone or baking sheet. Drizzle a bit of olive oil over the dough. Spread a thin layer of tomato sauce over the dough, leaving a border around the edges.\r\n\r\nAdd Cheese and Basil:\r\nArrange slices of fresh mozzarella evenly over the sauce. Tear fresh basil leaves and scatter them over the cheese. Season with salt and pepper to taste. Optionally, sprinkle grated Parmesan cheese on top.\r\n\r\nBake in the Oven:\r\nTransfer the pizza to the preheated oven and bake according to the dough's instructions or until the crust is golden and the cheese is melted and bubbly.\r\n\r\nServe:\r\nOnce the pizza is out of the oven, let it cool for a few minutes before slicing. Serve hot and enjoy your homemade Margherita Pizza!\r\n\r\nFeel free to customize the recipe to your liking. Margherita Pizza is known for its simplicity and fresh flavors, making it a delicious and classic choice.";
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
            new IngredientNutrient { Id = 1, Uid = Guid.NewGuid(), Calories = 105, Protein = 1.3m, Carbohydrates = 27m, Fat = 1m, Sugar = 14m, Created = DateTime.Now }, //banana
             new IngredientNutrient { Id = 2, Uid = Guid.NewGuid(), Calories = 18m, Protein = 0.9m, Carbohydrates = 3.9m, Fat = 0.2m, Sugar = 2.6m, Created = DateTime.Now }, //tomato
             new IngredientNutrient { Id = 3, Uid = Guid.NewGuid(), Calories = 29m, Protein = 1.1m, Carbohydrates = 9.3m, Fat = 0.3m, Sugar = 2.5m, Created = DateTime.Now }, //lemon
             new IngredientNutrient { Id = 4, Uid = Guid.NewGuid(), Calories = 23m, Protein = 3.2m, Carbohydrates = 2.7m, Fat = 0.6m, Sugar = 0.3m, Created = DateTime.Now }, //basil
             new IngredientNutrient { Id = 5, Uid = Guid.NewGuid(), Calories = 40m, Protein = 1.9m, Carbohydrates = 8.8m, Fat = 0.4m, Sugar = 5.3m, Created = DateTime.Now } //redchilipapper
        );
    }

    public static void SeedIngredients(ModelBuilder builder)
    {
        builder.Entity<Ingredient>().HasData(
            new Ingredient { Id = 1, Uid = Guid.NewGuid(), IngredientName = "Banana", IconPath = "banana", IngredientCategoryId = 1, IngredientNutrientId = 1, Created = DateTime.Now },
            new Ingredient { Id = 2, Uid = Guid.NewGuid(), IngredientName = "Tomato", IconPath = "tomato", IngredientCategoryId = 2, IngredientNutrientId = 2, Created = DateTime.Now },
            new Ingredient { Id = 3, Uid = Guid.NewGuid(), IngredientName = "Lemon", IconPath = "lemon", IngredientCategoryId = 1, IngredientNutrientId = 3, Created = DateTime.Now },
            new Ingredient { Id = 4, Uid = Guid.NewGuid(), IngredientName = "Basil", IconPath = "basil", IngredientCategoryId = 3, IngredientNutrientId = 4, Created = DateTime.Now },
            new Ingredient { Id = 5, Uid = Guid.NewGuid(), IngredientName = "Red Chili Papper", IconPath = "redchillipapper", IngredientCategoryId = 2, IngredientNutrientId = 5, Created = DateTime.Now }
        );
    }

    public static void SeedCulinaryRecipe(ModelBuilder builder)
    {
        builder.Entity<CulinaryRecipe>().HasData(
            new CulinaryRecipe { Id = 1, Uid = Guid.NewGuid(), RecipeName = "Spaghetti Bolognese", RecipeDescription = _RECIPE_DESCRIPTION_SPAGGETI, CuisineTypeId = 1, Created = DateTime.Now },
            new CulinaryRecipe { Id = 2, Uid = Guid.NewGuid(), RecipeName = "Margherita Pizza", RecipeDescription = _RECIPE_DESCRIPTION_PIZZA, CuisineTypeId = 1, Created = DateTime.Now }
        );
    }

    public static void SeedRecipeIngredients(ModelBuilder builder)
    {
        builder.Entity<RecipeIngredient>().HasData(
            new RecipeIngredient { Id = 1, CulinaryRecipeId = 1, IngredientId = 1, Created = DateTime.Now },
            new RecipeIngredient { Id = 2, CulinaryRecipeId = 2, IngredientId = 2, Created = DateTime.Now },
            new RecipeIngredient { Id = 3, CulinaryRecipeId = 2, IngredientId = 4, Created = DateTime.Now },
            new RecipeIngredient { Id = 4, CulinaryRecipeId = 2, IngredientId = 5, Created = DateTime.Now }
        );
    }
}
