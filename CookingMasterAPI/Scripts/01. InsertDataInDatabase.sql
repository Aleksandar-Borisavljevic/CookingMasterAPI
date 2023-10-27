USE CookingMasterDB

GO

DELETE FROM [CookingMasterDB].[dbo].[RecipeIngredients];

GO 

DELETE FROM [CookingMasterDB].[dbo].[UserIngredients];

GO

DELETE FROM [CookingMasterDB].[dbo].[CulinaryRecipes];

GO

DELETE FROM [CookingMasterDB].[dbo].[Users];

GO

DELETE FROM [CookingMasterDB].[dbo].[RecipeIngredients]

GO

DELETE FROM [CookingMasterDB].[dbo].[Ingredients];

GO

DELETE FROM [CookingMasterDB].[dbo].[IngredientNutrients]

GO

DELETE FROM [CookingMasterDB].[dbo].[IngredientCategories];

GO

DELETE FROM [CookingMasterDB].[dbo].[CuisineTypes]

GO

DBCC CHECKIDENT ('dbo.Ingredients', RESEED, 0);
DBCC CHECKIDENT ('dbo.IngredientCategories', RESEED, 0);
DBCC CHECKIDENT ('dbo.RecipeIngredients', RESEED, 0);
DBCC CHECKIDENT ('dbo.UserIngredients', RESEED, 0);
DBCC CHECKIDENT ('dbo.IngredientNutrients', RESEED, 0);
DBCC CHECKIDENT ('dbo.CuisineTypes', RESEED, 0);
DBCC CHECKIDENT ('dbo.Users', RESEED, 0);

GO

INSERT INTO Users (Username, EmailAddress, PasswordHash, PasswordSalt, VerificationToken, VerifiedAt, Uid)
VALUES('Admin', 'admin@gmail.com', 0x8A2C23CB6511E38FB54692A30C0224210BE7DE47050F7FB962424B55D5648B79B0E8A9386206A22E93369C29D147D7DB470321272C6B38C0247AE2749FEFC5BA, 0x4E07391EBA122D042C02C711932C8C3967961306E0DD8B8B7ED804AA014F3814AC07ED6388ECE7B7572AA177E9EEB6BD49A3858C2821516D3C4FAA3511DCFA86965E2CAAD09737C78445A81522291F1513407CA8BCB4A3EAC5C2314CB06B31A8E1614C602320F4A4A1AC5EE75FC8027EC8E77F55A41BD8C8E6563510A7C50620,'724464', '2023-10-23 20:06:18.8078634', 'Admin-20231023200557')

INSERT INTO CuisineTypes (CuisineName, Uid)
VALUES('Italian', 'Italian-1909772648542')
INSERT INTO CuisineTypes (CuisineName, Uid)
VALUES('Indian', 'Indian-1909772648542')
INSERT INTO CuisineTypes (CuisineName, Uid)
VALUES('Mexican', 'Mexican-1909772648542')
INSERT INTO CuisineTypes (CuisineName, Uid)
VALUES('Chinese', 'Chinese-1909772648542')
INSERT INTO CuisineTypes (CuisineName, Uid)
VALUES('French', 'French-1909772648542')
INSERT INTO CuisineTypes (CuisineName, Uid)
VALUES('Thai', 'Thai-1909772648542')

INSERT INTO CulinaryRecipes (CuisineTypeId, UserId, RecipeName, RecipeDescription, CreateDate, Uid)
VALUES (1, 1, 'Pizza Margherita', 'Ingredients:

1 pizza dough
1/2 cup tomato sauce
1 1/2 cups fresh mozzarella cheese, sliced
1/4 cup fresh basil leaves
2 tablespoons olive oil
Salt and pepper to taste
Instructions:

Preheat your oven to its highest temperature (usually around 500°F or 260°C). If you have a pizza stone, place it in the oven while it preheats.

Roll out the pizza dough into a thin round shape on a floured surface.

Transfer the rolled-out dough to a pizza peel or an inverted baking sheet dusted with cornmeal or flour. This will make it easier to transfer the pizza to the hot oven.

Spread the tomato sauce evenly over the pizza dough, leaving a small border around the edge for the crust.

Arrange the sliced mozzarella cheese over the tomato sauce.

Tear the fresh basil leaves and scatter them over the pizza.

Drizzle the olive oil over the top, and season with a pinch of salt and freshly ground black pepper.

Carefully transfer the pizza to the hot oven (either onto the pizza stone or directly onto a baking sheet) and bake for about 10-12 minutes or until the crust is golden and the cheese is bubbling and slightly browned.

Remove the pizza from the oven, let it cool for a minute, then slice and enjoy your delicious Margherita pizza!

This classic pizza is all about simple, high-quality ingredients. Enjoy!', GETDATE(), 'Italian-1909772648542')
INSERT INTO CulinaryRecipes (CuisineTypeId, UserId, RecipeName, RecipeDescription, CreateDate, Uid)
VALUES (1, 1, 'Spaghetti Carbonara','Ingredients:

12 ounces (340 grams) of spaghetti
2 large eggs
1 cup (about 100 grams) of grated Pecorino Romano cheese
2-3 cloves of garlic, minced
4-6 slices of pancetta or guanciale, diced (about 4 ounces or 115 grams)
Freshly ground black pepper
Salt
Fresh parsley, chopped (for garnish, optional)
Instructions:

Prepare the Ingredients:

Begin by grating the Pecorino Romano cheese and setting it aside.
Mince the garlic and set it aside.
Dice the pancetta or guanciale into small pieces.
Cook the Spaghetti:

Bring a large pot of salted water to a boil.
Add the spaghetti and cook according to the package instructions until al dente. This typically takes about 8-10 minutes.
Before draining the pasta, reserve about 1/2 cup of pasta cooking water, then drain the spaghetti.
Cook the Pancetta or Guanciale:

While the pasta is cooking, heat a large skillet over medium heat.
Add the diced pancetta or guanciale and cook until it becomes crispy and golden brown, usually about 4-5 minutes.
Remove the cooked pancetta/guanciale from the skillet and set it aside on a plate lined with paper towels.
Prepare the Carbonara Sauce:

In a bowl, whisk together the eggs and grated Pecorino Romano cheese. Add a generous amount of freshly ground black pepper (usually about 1/2 teaspoon) to the mixture.
Combine the Pasta and Sauce:

Add the minced garlic to the skillet (with the pancetta/guanciale drippings) and cook for about 1 minute until fragrant.
Return the cooked pasta to the skillet and toss it in the garlic and drippings until well coated.
Add the Egg and Cheese Mixture:

Remove the skillet from the heat to avoid scrambling the eggs.
Quickly pour the egg and cheese mixture over the pasta and toss it vigorously until the sauce thickens and coats the pasta evenly. If the sauce is too thick, you can add some of the reserved pasta cooking water a little at a time to achieve the desired consistency.
Serve:

Add the crispy pancetta or guanciale back to the skillet and toss to combine.
Garnish with additional Pecorino Romano and chopped parsley if desired.
Serve immediately while it is hot.
Enjoy your homemade Spaghetti Carbonara! It is a classic Roman dish that is creamy, savory, and absolutely delicious.', GETDATE(), 'Italian-1909772648542')

INSERT INTO CulinaryRecipes (CuisineTypeId, UserId, RecipeName, RecipeDescription, CreateDate, Uid)
VALUES (3, 1, 'Cheese Quesadillas', 'Ingredients:

4 large flour tortillas
2 cups shredded cheese (such as cheddar, Monterey Jack, or a blend)
1/2 cup diced onions (optional)
1/2 cup diced bell peppers (optional)
1/2 cup diced cooked chicken, beef, or sautéed vegetables (optional)
2 tablespoons vegetable oil or butter
Salsa, sour cream, and guacamole for serving (optional)
Instructions:

Prepare the Filling (if using):

If you are adding onions, bell peppers, or any other fillings, sauté them in a little oil over medium heat until they are tender. If you are using pre-cooked meat or vegetables, make sure they are diced or shredded and set them aside.
Assemble the Quesadillas:

Lay out one tortilla on a clean surface or plate.
Sprinkle a quarter of the shredded cheese evenly over half of the tortilla.
If you are using any additional fillings, add them on top of the cheese.
Fold the other half of the tortilla over the filling to create a half-moon shape.
Cook the Quesadillas:

Heat a large skillet or griddle over medium heat and add about a teaspoon of vegetable oil or butter.
Carefully place one quesadilla in the skillet and cook for about 2-3 minutes on each side or until the tortilla is crispy and the cheese is melted.
You can press down gently with a spatula to help the quesadilla hold together.
Repeat for Remaining Quesadillas:

Remove the cooked quesadilla from the skillet and keep it warm.
Repeat the process for the remaining quesadillas, adding a bit more oil or butter to the skillet if needed.
Serve:

Cut each quesadilla into wedges.
Serve hot with your choice of toppings, such as salsa, sour cream, and guacamole.
Quesadillas are a versatile dish, so feel free to get creative with the fillings. You can also use corn tortillas if you prefer a different texture. Enjoy your delicious homemade quesadillas!', GETDATE(), 'Mexican-1909772648542')
INSERT INTO CulinaryRecipes (CuisineTypeId, UserId, RecipeName, RecipeDescription, CreateDate, Uid)
VALUES (3, 1, 'Chilaquiles', 'Ingredients:

For the Sauce:

2 cups of red or green salsa (homemade or store-bought)
1/2 cup of chicken or vegetable broth
1/2 onion, finely chopped
2 cloves of garlic, minced
1-2 chipotle peppers in adobo sauce (adjust to your preferred level of spiciness), minced (optional)
1 teaspoon cumin
1 teaspoon chili powder
Salt and pepper to taste
For the Chilaquiles:

6 cups of tortilla chips (slightly stale chips work great)
1 cup shredded cheese (such as queso fresco, Monterey Jack, or cheddar)
2-3 eggs (optional)
1/4 cup chopped fresh cilantro
1/4 cup diced red onion
Sour cream for serving (optional)
Instructions:

Prepare the Sauce:

In a saucepan, heat a little oil over medium heat.
Add the chopped onion and garlic and sauté for a few minutes until they become soft and translucent.
Stir in the cumin and chili powder, and cook for an additional minute.
Add the salsa, chicken or vegetable broth, and chipotle peppers (if using). Simmer the sauce for about 10-15 minutes, stirring occasionally. Season with salt and pepper to taste.
Cook the Eggs (Optional):

In a separate skillet, cook the eggs to your preferred style (fried or scrambled). Set them aside.
Assemble the Chilaquiles:

In a large pan, pour the sauce over the tortilla chips.
Gently stir to coat the chips with the sauce, ensuring they are well coated but not soggy.
Serve:

Top the saucy chips with shredded cheese, chopped cilantro, diced red onion, and the cooked eggs (if using).
Serve hot, garnished with a dollop of sour cream if desired.
Chilaquiles can be customized with additional toppings such as sliced avocado, sliced radishes, or crumbled queso fresco. It is a flavorful and comforting Mexican dish that is often enjoyed for breakfast or brunch.', GETDATE(), 'Mexican-1909772648542')
INSERT INTO CulinaryRecipes (CuisineTypeId, UserId, RecipeName, RecipeDescription, CreateDate, Uid)
VALUES (2, 1, 'Samosa','Ingredients:

For the Dough:

2 cups all-purpose flour (maida)
4 tablespoons ghee or vegetable oil
A pinch of salt
Water, as needed
For the Filling:

2 cups boiled and mashed potatoes
1 cup boiled and coarsely mashed green peas
1/2 cup finely chopped carrots
1/2 cup finely chopped green beans
1/2 cup finely chopped onions
2-3 green chilies, finely chopped (adjust to your spice preference)
1-inch piece of ginger, grated
2 cloves of garlic, minced
1 teaspoon cumin seeds
1 teaspoon coriander seeds
1 teaspoon garam masala
1/2 teaspoon turmeric powder
1 teaspoon ground coriander
Salt to taste
Vegetable oil for frying
Instructions:

For the Dough:

In a mixing bowl, combine the all-purpose flour and a pinch of salt.
Add the ghee or vegetable oil and mix it into the flour using your fingers until the mixture resembles breadcrumbs.
Gradually add water and knead the dough until it is smooth and firm. Cover it with a damp cloth and let it rest for about 30 minutes.
For the Filling:

In a large skillet, heat a couple of tablespoons of vegetable oil over medium heat.
Add cumin seeds and coriander seeds, and sauté for a minute or until they start to splutter.
Add the chopped onions and cook until they become translucent.
Add the grated ginger and minced garlic and cook for another minute.
Stir in the chopped green chilies, garam masala, turmeric, ground coriander, and salt. Cook for a couple of minutes.
Add the chopped vegetables (carrots, green beans) and cook until they soften.
Add the mashed potatoes and green peas. Stir well to combine and cook for a few more minutes.
Remove the filling from the heat and let it cool.
Assemble and Fry Samosas:

Divide the rested dough into small, equal-sized balls and roll each ball into a thin oval or circle (about 6 inches in diameter).
Cut each circle in half to make two semi-circles.
Fold each semi-circle into a cone shape, sealing the edges with a little water.
Fill each cone with a couple of tablespoons of the prepared filling.
Seal the open edge to form a triangular or cone shape.
Heat vegetable oil in a deep pan or fryer for deep-frying. Make sure the oil is hot, but not smoking.
Carefully slide the filled samosas into the hot oil and fry them until they turn golden brown and crispy, turning occasionally to ensure even frying.
Remove the samosas with a slotted spoon and drain on paper towels to remove excess oil.
Serve the samosas hot with tamarind chutney, mint chutney, or ketchup. Enjoy your homemade Indian samosas!', GETDATE(), 'Indian-1909772648542')
INSERT INTO CulinaryRecipes (CuisineTypeId, UserId, RecipeName, RecipeDescription, CreateDate, Uid)
VALUES (2, 1, 'Biryani','Ingredients:

For Marinating Chicken:

1 kg (2.2 pounds) chicken, cut into pieces
1 cup yogurt
1 tablespoon ginger-garlic paste
1 teaspoon red chili powder
1 teaspoon turmeric powder
Salt to taste
2 tablespoons vegetable oil
For Rice:

2 cups Basmati rice
Water for soaking
4-5 cups water for cooking rice
2-3 green cardamom pods
2-3 cloves
1 bay leaf
1-inch cinnamon stick
Salt to taste
For Biryani:

2 onions, thinly sliced
2 tomatoes, chopped
2 green chilies, slit
2 teaspoons ginger-garlic paste
1/2 cup fresh coriander leaves, chopped
1/2 cup fresh mint leaves, chopped
1/2 teaspoon red chili powder
1/2 teaspoon garam masala
1/2 teaspoon turmeric powder
1/2 cup vegetable oil or ghee (clarified butter)
Saffron strands soaked in 2 tablespoons of warm milk (optional, for garnish)
Instructions:

Marinating Chicken:

In a bowl, mix the yogurt, ginger-garlic paste, red chili powder, turmeric powder, salt, and vegetable oil.
Add the chicken pieces and coat them with the marinade.
Cover and refrigerate for at least 1 hour (or longer for better flavor).
Preparing the Rice:

Wash the Basmati rice in cold water until the water runs clear.
Soak the rice in water for about 30 minutes.
In a large pot, bring 4-5 cups of water to a boil.
Add the soaked rice, green cardamom pods, cloves, bay leaf, cinnamon stick, and salt.
Cook the rice until it is 70-80% cooked (still slightly firm), then drain the water.
Assembling the Biryani:

In a large, heavy-bottomed pot or a biryani pot, heat the vegetable oil or ghee over medium heat.
Add the sliced onions and fry until they become golden brown and crisp. Remove some fried onions for garnish.
Add the ginger-garlic paste and green chilies to the remaining fried onions. Sauté for a few minutes.
Add the chopped tomatoes and cook until they become soft and the oil begins to separate.
Add the marinated chicken and cook until it changes color and starts to brown.
Add the red chili powder, turmeric, and garam masala. Cook for a few minutes.
Layer the partially cooked rice on top of the chicken mixture.
Sprinkle chopped fresh coriander and mint leaves over the rice.
Drizzle the saffron milk over the top for a beautiful color and aroma.
Cover the pot with a tight-fitting lid, sealing it with dough or foil to trap steam.
Cook on low heat for about 20-25 minutes, allowing the biryani to steam. This is known as "dum cooking."
Once done, gently fluff the biryani with a fork and serve, garnishing with the fried onions.
Chicken Biryani is traditionally served with raita (yogurt with spices) or a cucumber and mint salad. Enjoy your homemade Indian Biryani!', GETDATE(), 'Indian-1909772648542')

INSERT INTO IngredientCategories (CategoryName, IconPath, CreateDate, Uid)
 VALUES ('All Ingredients', 'allingredients', GETDATE(), 'All Ingredients-20230822194117')
INSERT INTO IngredientCategories (CategoryName, IconPath, CreateDate, Uid)
 VALUES ('Fruit', 'fruit', GETDATE(), 'Fruit-20230822194117')
 INSERT INTO IngredientCategories (CategoryName, IconPath, CreateDate, Uid)
 VALUES ('Vegetables', 'vegetables', GETDATE(), 'Vegetables-20230822194136')
 INSERT INTO IngredientCategories (CategoryName, IconPath, CreateDate, Uid)
 VALUES ('Spices', 'spices', GETDATE(), 'Spices-20230822194144')
 INSERT INTO IngredientCategories (CategoryName, IconPath, CreateDate, Uid)
 VALUES ('Meat', 'meat', GETDATE(), 'Meat-20230822194155')
 INSERT INTO IngredientCategories (CategoryName, IconPath, CreateDate, Uid)
 VALUES ('Seafood', 'seafood', GETDATE(), 'Seafood-20230822194204')
 INSERT INTO IngredientCategories (CategoryName, IconPath, CreateDate, Uid)
 VALUES ('Cereals', 'cereals', GETDATE(), 'Cereals-20230822194215')
 INSERT INTO IngredientCategories (CategoryName, IconPath, CreateDate, Uid)
 VALUES ('Dairy Product', 'dairyproduct', GETDATE(), 'Dairy Product-20230822194117')
  INSERT INTO IngredientCategories (CategoryName, IconPath, CreateDate, Uid)
 VALUES ('Nuts', 'nuts', GETDATE(), 'Nuts-20230822194117')
 INSERT INTO IngredientCategories (CategoryName, IconPath, CreateDate, Uid)
 VALUES ('Other', 'other', GETDATE(), 'Other-20230822194117')

GO

INSERT INTO IngredientNutrients (Calories, Protein, Carbohydrates, Fat, Sugar, CreateDate, Uid)
VALUES (89, 1.06, 22.84, 0.33, 12.23, GETDATE(), 'Nut-Banana-20230822194215')
INSERT INTO IngredientNutrients (Calories, Protein, Carbohydrates, Fat, Sugar, CreateDate, Uid)
VALUES (43, 1.4, 9.6, 0.5, 4.9, GETDATE(), 'Nut-Blackberry-20230832194215')
INSERT INTO IngredientNutrients (Calories, Protein, Carbohydrates, Fat, Sugar, CreateDate, Uid)
VALUES (69, 0.72, 18.1, 0.16, 15.48, GETDATE(), 'Nut-Blue Grape-20230821194215')
INSERT INTO IngredientNutrients (Calories, Protein, Carbohydrates, Fat, Sugar, CreateDate, Uid)
VALUES (52, 0.3, 14, 0.2, 10, GETDATE(), 'Nut-Green Apple-20230825194215')
INSERT INTO IngredientNutrients (Calories, Protein, Carbohydrates, Fat, Sugar, CreateDate, Uid)
VALUES (61, 1.1, 14.9, 0.5, 9.1, GETDATE(), 'Nut-Kiwi-20230822194215')
INSERT INTO IngredientNutrients (Calories, Protein, Carbohydrates, Fat, Sugar, CreateDate, Uid)
VALUES (43, 1, 8.2, 0.2, 8.2, GETDATE(), 'Nut-Orange-20220822194215')
INSERT INTO IngredientNutrients (Calories, Protein, Carbohydrates, Fat, Sugar, CreateDate, Uid)
VALUES (63, 1.1, 16, 0.3, 12.2, GETDATE(), 'Nut-Cherry-24230822194215')
INSERT INTO IngredientNutrients (Calories, Protein, Carbohydrates, Fat, Sugar, CreateDate, Uid)
VALUES (29, 1.1, 9.3, 0.3, 2.5, GETDATE(), 'Nut-Lemon-20230822194215')
INSERT INTO IngredientNutrients (Calories, Protein, Carbohydrates, Fat, Sugar, CreateDate, Uid)
VALUES (30, 0.7, 10.5, 0.2, 1.7, GETDATE(), 'Nut-Lime-20230822194215')
INSERT INTO IngredientNutrients (Calories, Protein, Carbohydrates, Fat, Sugar, CreateDate, Uid)
VALUES (39, 0.9, 9.5, 0.3, 8.4, GETDATE(), 'Nut-Peach-20230882194215')
INSERT INTO IngredientNutrients (Calories, Protein, Carbohydrates, Fat, Sugar, CreateDate, Uid)
VALUES (57, 0.4, 15.5, 0.2, 9.8, GETDATE(), 'Nut-Pear-20237822194215')
INSERT INTO IngredientNutrients (Calories, Protein, Carbohydrates, Fat, Sugar, CreateDate, Uid)
VALUES (50, 0.5, 13.1, 0.1, 9.9, GETDATE(), 'Nut-Pineapple-20237822194215')
INSERT INTO IngredientNutrients (Calories, Protein, Carbohydrates, Fat, Sugar, CreateDate, Uid)
VALUES (52, 1.5, 11.9, 0.7, 4.4, GETDATE(), 'Nut-Raspberry-20237822194215')
INSERT INTO IngredientNutrients (Calories, Protein, Carbohydrates, Fat, Sugar, CreateDate, Uid)
VALUES (52, 0.3, 14, 0.2, 9, GETDATE(), 'Nut-Red Apple-20237822194215')
INSERT INTO IngredientNutrients (Calories, Protein, Carbohydrates, Fat, Sugar, CreateDate, Uid)
VALUES (32, 0.7, 7.7, 0.3, 4.9, GETDATE(), 'Nut-Strawberries-20237822194215')
INSERT INTO IngredientNutrients (Calories, Protein, Carbohydrates, Fat, Sugar, CreateDate, Uid)
VALUES (41, 0.9, 10, 0.2, 4.7, GETDATE(), 'Nut-Carrot-20237822194215')
INSERT INTO IngredientNutrients (Calories, Protein, Carbohydrates, Fat, Sugar, CreateDate, Uid)
VALUES (25, 1.3, 5.8, 0.1, 3.2, GETDATE(), 'Nut-Cabbage-20237822194215')
INSERT INTO IngredientNutrients (Calories, Protein, Carbohydrates, Fat, Sugar, CreateDate, Uid)
VALUES (20, 2.2, 3.7, 0.2, 1.9, GETDATE(), 'Nut-Asparagus-20237822194215')
INSERT INTO IngredientNutrients (Calories, Protein, Carbohydrates, Fat, Sugar, CreateDate, Uid)
VALUES (115, 0.8, 6.3, 10.7, 0.5, GETDATE(), 'Nut-Black Olive-20237822194215')
INSERT INTO IngredientNutrients (Calories, Protein, Carbohydrates, Fat, Sugar, CreateDate, Uid)
VALUES (34, 2.8, 7.2, 0.4, 1.7, GETDATE(), 'Nut-Broccoli-20237822194215')
INSERT INTO IngredientNutrients (Calories, Protein, Carbohydrates, Fat, Sugar, CreateDate, Uid)
VALUES (42, 1.5, 9.2, 0.3, 1.5, GETDATE(), 'Nut-Celeriac-20237822194215')
INSERT INTO IngredientNutrients (Calories, Protein, Carbohydrates, Fat, Sugar, CreateDate, Uid)
VALUES (149, 6.4, 33.1, 0.5, 1, GETDATE(), 'Nut-Garlic-20237822194215')
INSERT INTO IngredientNutrients (Calories, Protein, Carbohydrates, Fat, Sugar, CreateDate, Uid)
VALUES (87, 1.9, 20.1, 0.1, 0.8, GETDATE(), 'Nut-Potato-20237822194215')
INSERT INTO IngredientNutrients (Calories, Protein, Carbohydrates, Fat, Sugar, CreateDate, Uid)
VALUES (40, 1.1, 9.3, 0.1, 4.7, GETDATE(), 'Nut-Onion-20237822194215')
INSERT INTO IngredientNutrients (Calories, Protein, Carbohydrates, Fat, Sugar, CreateDate, Uid)
VALUES (40, 1.9, 8.8, 0.4, 5.3, GETDATE(), 'Nut-Red Chilli Pepper-20237822194215')
INSERT INTO IngredientNutrients (Calories, Protein, Carbohydrates, Fat, Sugar, CreateDate, Uid)
VALUES (81, 5.4, 14.5, 0.4, 5.7, GETDATE(), 'Nut-Peas-20237822194215')
INSERT INTO IngredientNutrients (Calories, Protein, Carbohydrates, Fat, Sugar, CreateDate, Uid)
VALUES (26, 0.9, 6.5, 0.1, 2.8, GETDATE(), 'Nut-Pumpkin-20237822194215')
INSERT INTO IngredientNutrients (Calories, Protein, Carbohydrates, Fat, Sugar, CreateDate, Uid)
VALUES (23, 3.2, 2.7, 0.6, 0.3, GETDATE(), 'Nut-Basil-20237822194215')
INSERT INTO IngredientNutrients (Calories, Protein, Carbohydrates, Fat, Sugar, CreateDate, Uid)
VALUES (265, 9, 68.9, 4.3, 0, GETDATE(), 'Nut-Oregano-20237822194215')
INSERT INTO IngredientNutrients (Calories, Protein, Carbohydrates, Fat, Sugar, CreateDate, Uid)
VALUES (0, 0, 0, 0, 0, GETDATE(), 'Nut-Salt-20237822194215')
INSERT INTO IngredientNutrients (Calories, Protein, Carbohydrates, Fat, Sugar, CreateDate, Uid)
VALUES (387, 0, 99.98, 0, 99.98, GETDATE(), 'Nut-Sugar-20237822194215')
INSERT INTO IngredientNutrients (Calories, Protein, Carbohydrates, Fat, Sugar, CreateDate, Uid)
VALUES (42, 3.2, 0.1, 3.3, 0, GETDATE(), 'Nut-Bacon-20237822194215')
INSERT INTO IngredientNutrients (Calories, Protein, Carbohydrates, Fat, Sugar, CreateDate, Uid)
VALUES (250, 26.1, 0, 17.9, 0, GETDATE(), 'Nut-Beef Steak-20237822194215')
INSERT INTO IngredientNutrients (Calories, Protein, Carbohydrates, Fat, Sugar, CreateDate, Uid)
VALUES (336, 25.2, 0, 25.9, 0, GETDATE(), 'Nut-Salami-20237822194215')
INSERT INTO IngredientNutrients (Calories, Protein, Carbohydrates, Fat, Sugar, CreateDate, Uid)
VALUES (320, 12.0, 0, 29, 0, GETDATE(), 'Nut-Sausage-20237822194215')
INSERT INTO IngredientNutrients (Calories, Protein, Carbohydrates, Fat, Sugar, CreateDate, Uid)
VALUES (100, 22, 0, 0.9, 0, GETDATE(), 'Nut-Canned Tuna-20237822194215')
INSERT INTO IngredientNutrients (Calories, Protein, Carbohydrates, Fat, Sugar, CreateDate, Uid)
VALUES (206, 25.4, 0, 10.5, 0, GETDATE(), 'Nut-Salmon-20237822194215')
INSERT INTO IngredientNutrients (Calories, Protein, Carbohydrates, Fat, Sugar, CreateDate, Uid)
VALUES (96, 20.1, 0, 1.7, 0, GETDATE(), 'Nut-Tilapia-20237822194215')
INSERT INTO IngredientNutrients (Calories, Protein, Carbohydrates, Fat, Sugar, CreateDate, Uid)
VALUES (61, 3.2, 4.8, 3.3, 4.8, GETDATE(), 'Nut-Milk-20237822194215')
INSERT INTO IngredientNutrients (Calories, Protein, Carbohydrates, Fat, Sugar, CreateDate, Uid)
VALUES (61, 3.5, 4.7, 3.3, 4.7, GETDATE(), 'Nut-Yogurt-20237822194215')
INSERT INTO IngredientNutrients (Calories, Protein, Carbohydrates, Fat, Sugar, CreateDate, Uid)
VALUES (402, 25.4, 0, 33.1, 0, GETDATE(), 'Nut-Cheese-20237822194215')
INSERT INTO IngredientNutrients (Calories, Protein, Carbohydrates, Fat, Sugar, CreateDate, Uid)
VALUES (884, 0, 0, 100, 0, GETDATE(), 'Nut-Olive Oil-20237822194215')
INSERT INTO IngredientNutrients (Calories, Protein, Carbohydrates, Fat, Sugar, CreateDate, Uid)
VALUES (304, 0.3, 82.4, 0, 82.1, GETDATE(), 'Nut-Honey-20237822194215')

GO

INSERT INTO Ingredients (CategoryId, IconPath, CreateDate, Uid, IngredientName, IngredientNutrientId, UnitOfMeasure)
VALUES (2, 'banana', GETDATE(), 'Banana-20230822194215', 'Banana', 1, 1)
INSERT INTO Ingredients (CategoryId, IconPath, CreateDate, Uid, IngredientName, IngredientNutrientId, UnitOfMeasure)
VALUES (2, 'blackberry', GETDATE(), 'Blackberry-20230832194215', 'Blackberry', 2, 1)
INSERT INTO Ingredients (CategoryId, IconPath, CreateDate, Uid, IngredientName, IngredientNutrientId, UnitOfMeasure)
VALUES (2, 'bluegrape', GETDATE(), 'Blue Grape-20230821194215', 'Blue Grape', 3, 1)
INSERT INTO Ingredients (CategoryId, IconPath, CreateDate, Uid, IngredientName, IngredientNutrientId, UnitOfMeasure)
VALUES (2, 'greenapple', GETDATE(), 'Green Apple-20230825194215', 'Green Apple', 4, 1)
INSERT INTO Ingredients (CategoryId, IconPath, CreateDate, Uid, IngredientName, IngredientNutrientId, UnitOfMeasure)
VALUES (2, 'kiwi', GETDATE(), 'Kiwi-20230822194215', 'Kiwi', 5, 1)
INSERT INTO Ingredients (CategoryId, IconPath, CreateDate, Uid, IngredientName, IngredientNutrientId, UnitOfMeasure)
VALUES (2, 'orange', GETDATE(), 'Orange-20220822194215', 'Orange', 6, 1)
INSERT INTO Ingredients (CategoryId, IconPath, CreateDate, Uid, IngredientName, IngredientNutrientId, UnitOfMeasure)
VALUES (2, 'cherry', GETDATE(), 'Cherry-24230822194215', 'Cherry', 7, 1)
INSERT INTO Ingredients (CategoryId, IconPath, CreateDate, Uid, IngredientName, IngredientNutrientId, UnitOfMeasure)
VALUES (2, 'lemon', GETDATE(), 'Lemon-20230822194215', 'Lemon', 8, 1)
INSERT INTO Ingredients (CategoryId, IconPath, CreateDate, Uid, IngredientName, IngredientNutrientId, UnitOfMeasure)
VALUES (2, 'lime', GETDATE(), 'Lime-20230822194215', 'Lime', 9, 1)
INSERT INTO Ingredients (CategoryId, IconPath, CreateDate, Uid, IngredientName, IngredientNutrientId, UnitOfMeasure)
VALUES (2, 'peach', GETDATE(), 'Peach-20230882194215', 'Peach', 10, 1)
INSERT INTO Ingredients (CategoryId, IconPath, CreateDate, Uid, IngredientName, IngredientNutrientId, UnitOfMeasure)
VALUES (2, 'pear', GETDATE(), 'Pear-20237822194215', 'Pear', 11, 1)
INSERT INTO Ingredients (CategoryId, IconPath, CreateDate, Uid, IngredientName, IngredientNutrientId, UnitOfMeasure)
VALUES (2, 'pineapple', GETDATE(), 'Pineapple-20237822194215', 'Pineapple', 12, 1)
INSERT INTO Ingredients (CategoryId, IconPath, CreateDate, Uid, IngredientName, IngredientNutrientId, UnitOfMeasure)
VALUES (2, 'raspberry', GETDATE(), 'Raspberry-20237822194215', 'Raspberry', 13, 1)
INSERT INTO Ingredients (CategoryId, IconPath, CreateDate, Uid, IngredientName, IngredientNutrientId, UnitOfMeasure)
VALUES (2, 'redapple', GETDATE(), 'Red Apple-20237822194215', 'Red Apple', 14, 1)
INSERT INTO Ingredients (CategoryId, IconPath, CreateDate, Uid, IngredientName, IngredientNutrientId, UnitOfMeasure)
VALUES (2, 'strawberries', GETDATE(), 'Strawberries-20237822194215', 'Strawberries', 15, 1)
INSERT INTO Ingredients (CategoryId, IconPath, CreateDate, Uid, IngredientName, IngredientNutrientId, UnitOfMeasure)
VALUES (3, 'carrot', GETDATE(), 'Carrot-20237822194215', 'Carrot', 16, 1)
INSERT INTO Ingredients (CategoryId, IconPath, CreateDate, Uid, IngredientName, IngredientNutrientId, UnitOfMeasure)
VALUES (3, 'cabbage', GETDATE(), 'Cabbage-20237822194215', 'Cabbage', 17, 1)
INSERT INTO Ingredients (CategoryId, IconPath, CreateDate, Uid, IngredientName, IngredientNutrientId, UnitOfMeasure)
VALUES (3, 'asparagus', GETDATE(), 'Asparagus-20237822194215', 'Asparagus', 18, 1)
INSERT INTO Ingredients (CategoryId, IconPath, CreateDate, Uid, IngredientName, IngredientNutrientId, UnitOfMeasure)
VALUES (3, 'blackolive', GETDATE(), 'Black Olive-20237822194215', 'Black Olive', 19, 1)
INSERT INTO Ingredients (CategoryId, IconPath, CreateDate, Uid, IngredientName, IngredientNutrientId, UnitOfMeasure)
VALUES (3, 'broccoli', GETDATE(), 'Broccoli-20237822194215', 'Broccoli', 20, 1)
INSERT INTO Ingredients (CategoryId, IconPath, CreateDate, Uid, IngredientName, IngredientNutrientId, UnitOfMeasure)
VALUES (3, 'celeriac', GETDATE(), 'Celeriac-20237822194215', 'Celeriac', 21, 1)
INSERT INTO Ingredients (CategoryId, IconPath, CreateDate, Uid, IngredientName, IngredientNutrientId, UnitOfMeasure)
VALUES (3, 'garlic', GETDATE(), 'Garlic-20237822194215', 'Garlic', 22, 1)
INSERT INTO Ingredients (CategoryId, IconPath, CreateDate, Uid, IngredientName, IngredientNutrientId, UnitOfMeasure)
VALUES (3, 'potato', GETDATE(), 'Potato-20237822194215', 'Potato', 23, 1)
INSERT INTO Ingredients (CategoryId, IconPath, CreateDate, Uid, IngredientName, IngredientNutrientId, UnitOfMeasure)
VALUES (3, 'onion', GETDATE(), 'Onion-20237822194215', 'Onion', 24, 1)
INSERT INTO Ingredients (CategoryId, IconPath, CreateDate, Uid, IngredientName, IngredientNutrientId, UnitOfMeasure)
VALUES (3, 'redchillipepper', GETDATE(), 'Red Chilli Pepper-20237822194215', 'Red Chilli Pepper', 25, 1)
INSERT INTO Ingredients (CategoryId, IconPath, CreateDate, Uid, IngredientName, IngredientNutrientId, UnitOfMeasure)
VALUES (3, 'peas', GETDATE(), 'Peas-20237822194215', 'Peas', 26, 1)
INSERT INTO Ingredients (CategoryId, IconPath, CreateDate, Uid, IngredientName, IngredientNutrientId, UnitOfMeasure)
VALUES (3, 'pumpkin', GETDATE(), 'Pumpkin-20237822194215', 'Pumpkin', 27, 1)
INSERT INTO Ingredients (CategoryId, IconPath, CreateDate, Uid, IngredientName, IngredientNutrientId, UnitOfMeasure)
VALUES (4, 'basil', GETDATE(), 'Basil-20237822194215', 'Basil', 28, 1)
INSERT INTO Ingredients (CategoryId, IconPath, CreateDate, Uid, IngredientName, IngredientNutrientId, UnitOfMeasure)
VALUES (4, 'oregano', GETDATE(), 'Oregano-20237822194215', 'Oregano', 29, 1)
INSERT INTO Ingredients (CategoryId, IconPath, CreateDate, Uid, IngredientName, IngredientNutrientId, UnitOfMeasure)
VALUES (4, 'salt', GETDATE(), 'Salt-20237822194215', 'Salt', 30, 1)
INSERT INTO Ingredients (CategoryId, IconPath, CreateDate, Uid, IngredientName, IngredientNutrientId, UnitOfMeasure)
VALUES (4, 'sugar', GETDATE(), 'Sugar-20237822194215', 'Sugar', 31, 1)
INSERT INTO Ingredients (CategoryId, IconPath, CreateDate, Uid, IngredientName, IngredientNutrientId, UnitOfMeasure)
VALUES (5, 'bacon', GETDATE(), 'Bacon-20237822194215', 'Bacon', 32, 1)
INSERT INTO Ingredients (CategoryId, IconPath, CreateDate, Uid, IngredientName, IngredientNutrientId, UnitOfMeasure)
VALUES (5, 'beefsteak', GETDATE(), 'Beef Steak-20237822194215', 'Beef Steak', 33, 1)
INSERT INTO Ingredients (CategoryId, IconPath, CreateDate, Uid, IngredientName, IngredientNutrientId, UnitOfMeasure)
VALUES (5, 'salami', GETDATE(), 'Salami-20237822194215', 'Salami', 34, 1)
INSERT INTO Ingredients (CategoryId, IconPath, CreateDate, Uid, IngredientName, IngredientNutrientId, UnitOfMeasure)
VALUES (5, 'sausage', GETDATE(), 'Sausage-20237822194215', 'Sausage', 35, 1)
INSERT INTO Ingredients (CategoryId, IconPath, CreateDate, Uid, IngredientName, IngredientNutrientId, UnitOfMeasure)
VALUES (6, 'cannedtuna', GETDATE(), 'Canned Tuna-20237822194215', 'Canned Tuna', 36, 1)
INSERT INTO Ingredients (CategoryId, IconPath, CreateDate, Uid, IngredientName, IngredientNutrientId, UnitOfMeasure)
VALUES (6, 'salmon', GETDATE(), 'Salmon-20237822194215', 'Salmon', 37, 1)
INSERT INTO Ingredients (CategoryId, IconPath, CreateDate, Uid, IngredientName, IngredientNutrientId, UnitOfMeasure)
VALUES (6, 'tilapia', GETDATE(), 'Tilapia-20237822194215', 'Tilapia', 38, 1)
INSERT INTO Ingredients (CategoryId, IconPath, CreateDate, Uid, IngredientName, IngredientNutrientId, UnitOfMeasure)
VALUES (8, 'milk', GETDATE(), 'Milk-20237822194215', 'Milk', 39, 2)
INSERT INTO Ingredients (CategoryId, IconPath, CreateDate, Uid, IngredientName, IngredientNutrientId, UnitOfMeasure)
VALUES (8, 'yogurt', GETDATE(), 'Yogurt-20237822194215', 'Yogurt', 40, 2)
INSERT INTO Ingredients (CategoryId, IconPath, CreateDate, Uid, IngredientName, IngredientNutrientId, UnitOfMeasure)
VALUES (8, 'cheese', GETDATE(), 'Cheese-20237822194215', 'Cheese', 41, 1)
INSERT INTO Ingredients (CategoryId, IconPath, CreateDate, Uid, IngredientName, IngredientNutrientId, UnitOfMeasure)
VALUES (10, 'oliveoil', GETDATE(), 'Olive Oil-20237822194215', 'Olive Oil', 42, 2)
INSERT INTO Ingredients (CategoryId, IconPath, CreateDate, Uid, IngredientName, IngredientNutrientId, UnitOfMeasure)
VALUES (10, 'honey', GETDATE(), 'Honey-20237822194215', 'Honey', 43, 1)