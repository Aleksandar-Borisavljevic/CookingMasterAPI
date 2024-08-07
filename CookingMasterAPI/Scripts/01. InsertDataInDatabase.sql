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
DBCC CHECKIDENT ('dbo.UserIngredients', RESEED, 0);
DBCC CHECKIDENT ('dbo.IngredientNutrients', RESEED, 0);
DBCC CHECKIDENT ('dbo.CuisineTypes', RESEED, 0);
DBCC CHECKIDENT ('dbo.RecipeIngredients', RESEED, 0);
DBCC CHECKIDENT ('dbo.CulinaryRecipes', RESEED, 0);
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

Preheat your oven to its highest temperature (usually around 500�F or 260�C). If you have a pizza stone, place it in the oven while it preheats.

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
1/2 cup diced cooked chicken, beef, or saut�ed vegetables (optional)
2 tablespoons vegetable oil or butter
Salsa, sour cream, and guacamole for serving (optional)
Instructions:

Prepare the Filling (if using):

If you are adding onions, bell peppers, or any other fillings, saut� them in a little oil over medium heat until they are tender. If you are using pre-cooked meat or vegetables, make sure they are diced or shredded and set them aside.
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
Add the chopped onion and garlic and saut� for a few minutes until they become soft and translucent.
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
Add cumin seeds and coriander seeds, and saut� for a minute or until they start to splutter.
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
Add the ginger-garlic paste and green chilies to the remaining fried onions. Saut� for a few minutes.
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
INSERT INTO CulinaryRecipes (CuisineTypeId, UserId, RecipeName, RecipeDescription, CreateDate, Uid)
VALUES (5, 1, 'Ratatouille','Ingredients:

1 large eggplant
2 medium zucchini
2 red bell peppers
2 yellow bell peppers
3 ripe tomatoes
1 onion
4 cloves garlic
1/4 cup olive oil
1 teaspoon dried thyme
1 teaspoon dried oregano
Salt and black pepper to taste
Fresh basil leaves for garnish (optional)
Instructions:

Begin by preparing the vegetables. Wash them and then cut the eggplant, zucchini, and bell peppers into small cubes. Dice the tomatoes and finely chop the onion and garlic.

In a large, heavy-bottomed pot or Dutch oven, heat the olive oil over medium heat. Add the chopped onion and garlic and saut� for a few minutes until they become translucent.

Add the eggplant to the pot and cook for about 5 minutes, stirring occasionally until it starts to soften.

Next, add the zucchini, bell peppers, and tomatoes to the pot. Stir everything together.

Season the mixture with dried thyme, dried oregano, salt, and black pepper. Mix well to distribute the seasonings evenly.

Reduce the heat to low, cover the pot, and let the vegetables simmer for about 30-40 minutes. Stir occasionally, and be careful not to overcook the vegetables; you want them to remain somewhat firm, not mushy.

Taste and adjust the seasonings if necessary. If you like, you can add more olive oil for extra richness.

Once the Ratatouille is cooked to your liking, remove it from heat. You can serve it warm, at room temperature, or even chilled. It is delicious on its own or as a side dish.

If desired, garnish with fresh basil leaves before serving.

Ratatouille is a versatile dish that can be served with crusty bread, over pasta, or alongside a protein of your choice. Enjoy your homemade French Ratatouille!', GETDATE(), 'French-1909772648542')
INSERT INTO CulinaryRecipes (CuisineTypeId, UserId, RecipeName, RecipeDescription, CreateDate, Uid)
VALUES (5, 1, 'Boeuf Bourguignon','Ingredients:

2 pounds (about 1 kg) of stewing beef (such as chuck), cut into 2-inch (5 cm) cubes
4 slices of bacon, chopped
2 tablespoons olive oil
2 onions, chopped
2 carrots, chopped
2 cloves of garlic, minced
1 bottle (750 ml) of red wine (Burgundy, if possible)
2 cups beef broth
2 tablespoons tomato paste
1 teaspoon dried thyme
2 bay leaves
Salt and black pepper to taste
1 pound (about 450 g) of small white mushrooms, cleaned and quartered
20-24 small pearl onions, peeled (blanching them first can make peeling easier)
2 tablespoons butter
Chopped fresh parsley for garnish (optional)
Instructions:

In a large, heavy-bottomed pot or Dutch oven, cook the chopped bacon over medium heat until it becomes crisp. Remove the bacon with a slotted spoon and set it aside.

In the same pot, brown the beef cubes in batches in the bacon fat and olive oil. Make sure not to overcrowd the pot, as the beef should brown, not steam. Remove the browned beef and set it aside with the bacon.

In the same pot, add the chopped onions and carrots. Saut� for a few minutes until they begin to soften.

Add the minced garlic and saut� for another minute.

Return the beef and bacon to the pot. Stir in the tomato paste, thyme, and bay leaves. Season with salt and black pepper.

Pour in the red wine and beef broth, making sure the meat is mostly covered by the liquid. Bring it to a boil, then reduce the heat to low. Cover and let it simmer for about 2-3 hours, or until the beef is tender.

While the stew is simmering, melt the butter in a separate pan. Add the pearl onions and cook them until they become browned and caramelized. Set them aside.

In the same pan, add the quartered mushrooms and saut� them until they release their liquid and brown slightly. Set them aside.

Once the beef is tender, remove and discard the bay leaves. Add the caramelized onions and saut�ed mushrooms to the stew. Simmer for an additional 15-20 minutes.

Taste the stew and adjust the seasonings if needed.

Serve the Beef Bourguignon hot, garnished with chopped fresh parsley if desired. It is typically served with crusty bread, mashed potatoes, or egg noodles.

Enjoy your homemade Beef Bourguignon, a delightful and classic French dish!', GETDATE(), 'French-1909772648542')
INSERT INTO CulinaryRecipes (CuisineTypeId, UserId, RecipeName, RecipeDescription, CreateDate, Uid)
VALUES (4, 1, 'Kung Pao Chicken','Ingredients:

For the Marinade:

1 pound (450g) boneless, skinless chicken breast or thigh, cut into bite-sized cubes
1 tablespoon soy sauce
1 tablespoon rice wine or dry sherry
1 teaspoon cornstarch
For the Sauce:

3 tablespoons soy sauce
1 tablespoon hoisin sauce
1 tablespoon rice vinegar
1 tablespoon sugar
1/4 cup chicken broth or water
For the Stir-Fry:

2 tablespoons peanut or vegetable oil
1/2 cup unsalted peanuts
2-3 dried red chili peppers (adjust to your preferred level of spiciness)
3-4 cloves garlic, minced
1-inch piece of fresh ginger, minced
2 green onions, chopped
1 red bell pepper, cut into bite-sized pieces
1 green bell pepper, cut into bite-sized pieces
Instructions:

In a bowl, combine the marinade ingredients: soy sauce, rice wine (or sherry), and cornstarch. Add the cubed chicken and marinate for 15-20 minutes.

In a separate bowl, mix the sauce ingredients: soy sauce, hoisin sauce, rice vinegar, sugar, and chicken broth (or water). Stir well and set aside.

Heat the oil in a wok or a large skillet over high heat. Add the dried red chili peppers and stir-fry for about 30 seconds to infuse the oil with their flavor. Be careful not to burn them.

Add the marinated chicken to the wok and stir-fry until it is no longer pink, about 3-4 minutes. Remove the chicken from the wok and set it aside.

In the same wok, add a bit more oil if needed and stir-fry the minced garlic and ginger until fragrant, about 30 seconds.

Add the chopped bell peppers and stir-fry for 2-3 minutes, or until they start to soften.

Return the cooked chicken to the wok, along with the sauce mixture. Stir everything together and cook for an additional 2-3 minutes until the sauce thickens and coats the chicken and vegetables.

Add the chopped green onions and unsalted peanuts, then stir-fry for another minute or two.

Taste the dish and adjust the seasoning if needed. If you prefer it spicier, you can add more chili peppers or a dash of chili sauce.

Serve your Kung Pao Chicken hot over steamed rice. Enjoy!

This dish is known for its delicious balance of flavors, and you can adjust the spice level to suit your taste by adding more or fewer chili peppers.', GETDATE(), 'Chinese-1909772648542')
INSERT INTO CulinaryRecipes (CuisineTypeId, UserId, RecipeName, RecipeDescription, CreateDate, Uid)
VALUES (4, 1, 'Chinese Hot Pot','Ingredients:

For the Broth (you can choose one or both of the following options):

Chicken or vegetable broth
Spicy Sichuan-style broth (recipe below)
For the Spicy Sichuan-Style Broth (optional but adds a great kick):

4 cups chicken or vegetable broth
2-4 tablespoons Sichuan peppercorns (adjust to your desired level of spiciness)
2-4 dried red chili peppers (adjust to your desired level of spiciness)
2-3 slices of ginger
2-3 cloves garlic, minced
2 tablespoons vegetable oil
For the Ingredients (feel free to customize with your favorite items):

Thinly sliced meats (beef, lamb, pork, chicken)
Seafood (shrimp, scallops, fish)
Tofu (soft and firm varieties)
Dumplings or wontons
A variety of mushrooms (shiitake, enoki, oyster, etc.)
Leafy greens (bok choy, napa cabbage, spinach)
Noodles (glass noodles, udon, or your choice)
Eggs (for dipping)
Dipping Sauces (prepare a variety of sauces for dipping cooked ingredients):

Soy sauce
Hoisin sauce
Sesame sauce
Chili sauce
Chopped garlic
Chopped scallions
Peanut sauce (optional)
Instructions:

Prepare the Broth:

If you are making a spicy Sichuan-style broth, heat the vegetable oil in a pot, add the ginger, garlic, Sichuan peppercorns, and dried chili peppers. Stir-fry for a couple of minutes until fragrant.
Pour in the chicken or vegetable broth and bring it to a boil. Reduce the heat and simmer for about 20 minutes to infuse the flavors. Strain to remove the solids.
Set Up the Hot Pot Table:

Place a portable burner or electric hot pot at the center of the table.
Pour the broth(s) into the pot and set it to simmer.
Prepare the Ingredients:

Arrange all the sliced meats, seafood, tofu, vegetables, dumplings, and noodles on platters around the table.
Cooking Process:

Use chopsticks or a small strainer to cook ingredients in the simmering broth. Cooking times will vary (e.g., thinly sliced meat cooks quickly, while dumplings may take a few minutes).
Dip the cooked ingredients in your choice of dipping sauce and enjoy!
Continue to cook and eat, adding more ingredients as you go, until you are satisfied.

Chinese Hot Pot is a customizable and interactive dining experience, so feel free to adapt it to your preferences. It is perfect for gatherings with family and friends. Enjoy your hot pot meal!', GETDATE(), 'Chinese-1909772648542')
INSERT INTO CulinaryRecipes (CuisineTypeId, UserId, RecipeName, RecipeDescription, CreateDate, Uid)
VALUES (6, 1, 'Pad Thai','Ingredients:

For the Pad Thai Sauce:

3 tablespoons tamarind paste
2 tablespoons fish sauce (for a vegetarian version, use soy sauce)
2 tablespoons sugar
1/2 teaspoon paprika or chili powder (adjust to your preferred level of spiciness)
For the Noodles:

8 oz (about 225g) of rice noodles
2 tablespoons vegetable oil
2 cloves garlic, minced
1/2 cup diced tofu (extra firm)
1 egg (optional)
1/2 cup shrimp, chicken, or your choice of protein (optional)
1 cup bean sprouts
2 green onions, sliced
Crushed peanuts (for garnish)
Lime wedges (for garnish)
Instructions:

Prepare the Noodles:

Soak the rice noodles in warm water for about 30 minutes or until they become pliable but not too soft. Drain and set aside.
Make the Pad Thai Sauce:

In a small bowl, mix the tamarind paste, fish sauce (or soy sauce), sugar, and paprika (or chili powder) until well combined. Taste and adjust the ingredients to achieve your preferred balance of sweet, sour, and savory flavors.
Stir-Fry:

Heat the vegetable oil in a wok or large skillet over medium-high heat.
Add the minced garlic and stir-fry for about 30 seconds or until fragrant.
If using protein (shrimp, chicken, tofu, etc.), add it to the wok and stir-fry until it is cooked through. If using shrimp, they should turn pink and opaque.

Push the ingredients in the wok to one side and crack the egg into the empty space. Scramble the egg with a spatula until it is mostly cooked, and then mix it with the other ingredients.

Add the soaked and drained rice noodles to the wok, followed by the Pad Thai sauce. Toss everything together over medium heat.

Add the bean sprouts and green onions, and continue stir-frying for a few more minutes until the noodles are heated through and the sauce is well distributed.

Taste the Pad Thai and adjust the flavors if needed by adding more tamarind paste, fish sauce (or soy sauce), or sugar.

Serve your Pad Thai hot, garnished with crushed peanuts and lime wedges.

Pad Thai is often enjoyed with additional toppings like extra crushed peanuts, chili flakes, or cilantro. Customize it to your taste and enjoy your homemade Pad Thai!', GETDATE(), 'Thai-1909772648542')
INSERT INTO CulinaryRecipes (CuisineTypeId, UserId, RecipeName, RecipeDescription, CreateDate, Uid)
VALUES (6, 1, 'Tom Yum Goong','Ingredients:

4 cups (1 liter) chicken or shrimp stock
200g (about 7 oz) large shrimp, peeled and deveined
200g (about 7 oz) mushrooms (straw mushrooms or other varieties), sliced
2-3 stalks lemongrass, cut into 2-inch pieces and smashed
3-4 slices of galangal or ginger (about 1-2 inches long)
3-4 kaffir lime leaves, torn into pieces
3-4 slices of fresh red chili (adjust to your preferred level of spiciness)
2-3 tablespoons fish sauce (adjust to taste)
1-2 tablespoons lime juice (adjust to taste)
1 teaspoon sugar
2-3 small tomatoes, cut into quarters
Fresh cilantro leaves for garnish
Fresh Thai birds eye chilies (optional, for extra heat)
Instructions:

In a pot, bring the chicken or shrimp stock to a boil over medium heat.

Add the lemongrass, galangal or ginger, kaffir lime leaves, and fresh red chili slices to the boiling stock. Let it simmer for about 5-10 minutes to infuse the flavors.

Add the mushrooms and shrimp to the pot. Cook until the shrimp turn pink and opaque, which usually takes about 2-3 minutes.

Season the soup with fish sauce, lime juice, and sugar. Start with the recommended amounts, then adjust according to your taste. You should achieve a balance of hot, sour, salty, and sweet flavors.

Add the tomatoes and cook for an additional 2-3 minutes.

Taste the soup and adjust the seasoning if needed, adding more fish sauce, lime juice, or sugar as desired.

If you prefer a spicier soup, you can add fresh Thai birds eye chilies.

Remove the soup from the heat and discard the lemongrass, galangal, and kaffir lime leaves.

Serve your Tom Yum Goong hot, garnished with fresh cilantro leaves.

Tom Yum Goong is a fantastic and aromatic soup, and you can adjust the ingredients and seasonings to suit your preferences for spiciness and sourness. Enjoy!', GETDATE(), 'Thai-1909772648542')




INSERT INTO IngredientCategories (CategoryName, IconPath, CreateDate, Uid)
 VALUES ('All Ingredients', 'allingredients', GETDATE(), 'All Ingredients-20230822194117')
INSERT INTO IngredientCategories (CategoryName, IconPath, CreateDate, Uid)
 VALUES ('Fruit', 'fruit', GETDATE(), 'Fruit-20230822194117')
 INSERT INTO IngredientCategories (CategoryName, IconPath, CreateDate, Uid)
 VALUES ('Vegetables', 'vegetables', GETDATE(), 'Vegetables-20230822194136')
 INSERT INTO IngredientCategories (CategoryName, IconPath, CreateDate, Uid)
 VALUES ('Spices and Herbs', 'spicesandherbs', GETDATE(), 'Spicesandherbs-20230822194144')
 INSERT INTO IngredientCategories (CategoryName, IconPath, CreateDate, Uid)
 VALUES ('Meat', 'meat', GETDATE(), 'Meat-20230822194155')
 INSERT INTO IngredientCategories (CategoryName, IconPath, CreateDate, Uid)
 VALUES ('Seafood', 'seafood', GETDATE(), 'Seafood-20230822194204')
 INSERT INTO IngredientCategories (CategoryName, IconPath, CreateDate, Uid)
 VALUES ('Grain', 'grain', GETDATE(), 'Grain-20230822194215')
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
INSERT INTO IngredientNutrients (Calories, Protein, Carbohydrates, Fat, Sugar, CreateDate, Uid)
VALUES (40, 2.0, 8.0, 1, 6.0, GETDATE(), 'Nut-Tomato Sauce-20237822194215')
INSERT INTO IngredientNutrients (Calories, Protein, Carbohydrates, Fat, Sugar, CreateDate, Uid)
VALUES (110, 1.0, 30, 1, 25.0, GETDATE(), 'Nut-Ketchup-20237822194215')
INSERT INTO IngredientNutrients (Calories, Protein, Carbohydrates, Fat, Sugar, CreateDate, Uid)
VALUES (131, 4.9, 25, 1.1, 0.6, GETDATE(), 'Nut-Pasta-20237822194215')
INSERT INTO IngredientNutrients (Calories, Protein, Carbohydrates, Fat, Sugar, CreateDate, Uid)
VALUES (299, 9.7, 58.9, 1.9, 1.1, GETDATE(), 'Nut-Dough-20237822194215')
INSERT INTO IngredientNutrients (Calories, Protein, Carbohydrates, Fat, Sugar, CreateDate, Uid)
VALUES (143, 12.6, 1.1, 9.7, 1.1, GETDATE(), 'Nut-Eggs-20237822194215')
INSERT INTO IngredientNutrients (Calories, Protein, Carbohydrates, Fat, Sugar, CreateDate, Uid)
VALUES (255, 10.39, 64.81, 3.26, 0.64, GETDATE(), 'Nut-Black Pepper-20237822194215')
INSERT INTO IngredientNutrients (Calories, Protein, Carbohydrates, Fat, Sugar, CreateDate, Uid)
VALUES (36, 2.97, 6.33, 0.79, 0.85, GETDATE(), 'Nut-Parsley-20237822194215')
INSERT INTO IngredientNutrients (Calories, Protein, Carbohydrates, Fat, Sugar, CreateDate, Uid)
VALUES (290, 8.5, 52, 5, 2, GETDATE(), 'Nut-Tortilla-20237822194215')
INSERT INTO IngredientNutrients (Calories, Protein, Carbohydrates, Fat, Sugar, CreateDate, Uid)
VALUES (20, 0.86, 4.64, 0.17, 2.4, GETDATE(), 'Nut-Bell Pepper-20237822194215')
INSERT INTO IngredientNutrients (Calories, Protein, Carbohydrates, Fat, Sugar, CreateDate, Uid)
VALUES (165, 31, 0, 3.6, 0, GETDATE(), 'Nut-Chicken-20237822194215')
INSERT INTO IngredientNutrients (Calories, Protein, Carbohydrates, Fat, Sugar, CreateDate, Uid)
VALUES (30, 1.5, 7, 0.5, 3, GETDATE(), 'Nut-Salsa-20237822194215')
INSERT INTO IngredientNutrients (Calories, Protein, Carbohydrates, Fat, Sugar, CreateDate, Uid)
VALUES (6, 0.6, 0.6, 0.3, 0.2, GETDATE(), 'Nut-Broth-20237822194215')
INSERT INTO IngredientNutrients (Calories, Protein, Carbohydrates, Fat, Sugar, CreateDate, Uid)
VALUES (500, 9, 75, 28, 2, GETDATE(), 'Nut-Tortilla Chips-20237822194215')
INSERT INTO IngredientNutrients (Calories, Protein, Carbohydrates, Fat, Sugar, CreateDate, Uid)
VALUES (23, 2.13, 3.67, 0.52, 0.87, GETDATE(), 'Nut-Cilantro-20237822194215')
INSERT INTO IngredientNutrients (Calories, Protein, Carbohydrates, Fat, Sugar, CreateDate, Uid)
VALUES (40, 1.1, 9.34, 0.1, 4.2, GETDATE(), 'Nut-Red Onion-20237822194215')
INSERT INTO IngredientNutrients (Calories, Protein, Carbohydrates, Fat, Sugar, CreateDate, Uid)
VALUES (198, 2.1, 3.7, 20, 2.2, GETDATE(), 'Nut-Sour Cream-20237822194215')
INSERT INTO IngredientNutrients (Calories, Protein, Carbohydrates, Fat, Sugar, CreateDate, Uid)
VALUES (364, 10.3, 76.3, 1.2, 0.4, GETDATE(), 'Nut-Wheat Flour-20237822194215')
INSERT INTO IngredientNutrients (Calories, Protein, Carbohydrates, Fat, Sugar, CreateDate, Uid)
VALUES (884, 0, 0, 100, 0, GETDATE(), 'Nut-Vegetable Oil-20237822194215')
INSERT INTO IngredientNutrients (Calories, Protein, Carbohydrates, Fat, Sugar, CreateDate, Uid)
VALUES (0, 0, 0, 0, 0, GETDATE(), 'Nut-Water-20237822194215')
INSERT INTO IngredientNutrients (Calories, Protein, Carbohydrates, Fat, Sugar, CreateDate, Uid)
VALUES (81, 5.4, 14.5, 0.4, 5.7, GETDATE(), 'Nut-Green Peas-20237822194215')
INSERT INTO IngredientNutrients (Calories, Protein, Carbohydrates, Fat, Sugar, CreateDate, Uid)
VALUES (40, 2, 9, 0.4, 5.3, GETDATE(), 'Nut-Green Chilli-20237822194215')
INSERT INTO IngredientNutrients (Calories, Protein, Carbohydrates, Fat, Sugar, CreateDate, Uid)
VALUES (80, 1.8, 17.8, 0.6, 1.7, GETDATE(), 'Nut-Ginger-20237822194215')
INSERT INTO IngredientNutrients (Calories, Protein, Carbohydrates, Fat, Sugar, CreateDate, Uid)
VALUES (375, 17.8, 44.2, 22.3, 2.3, GETDATE(), 'Nut-Cumin Seeds-20237822194215')
INSERT INTO IngredientNutrients (Calories, Protein, Carbohydrates, Fat, Sugar, CreateDate, Uid)
VALUES (298, 12.4, 55, 17.8, 1.7, GETDATE(), 'Nut-Coriander Seeds-20237822194215')
INSERT INTO IngredientNutrients (Calories, Protein, Carbohydrates, Fat, Sugar, CreateDate, Uid)
VALUES (371, 11, 62, 10, 4, GETDATE(), 'Nut-Garam Masala-20237822194215')
INSERT INTO IngredientNutrients (Calories, Protein, Carbohydrates, Fat, Sugar, CreateDate, Uid)
VALUES (312, 9.7, 67.1, 3.3, 3.2, GETDATE(), 'Nut-Turmeric Powder-20237822194215')
INSERT INTO IngredientNutrients (Calories, Protein, Carbohydrates, Fat, Sugar, CreateDate, Uid)
VALUES (25, 1, 6, 0.2, 0, GETDATE(), 'Nut-Eggplant-20237822194215')
INSERT INTO IngredientNutrients (Calories, Protein, Carbohydrates, Fat, Sugar, CreateDate, Uid)
VALUES (121, 2.36, 25.22, 0.19, 0, GETDATE(), 'Nut-Basmati Rice-20237822194215')
INSERT INTO IngredientNutrients (Calories, Protein, Carbohydrates, Fat, Sugar, CreateDate, Uid)
VALUES (80, 2, 18, 0.8, 1.7, GETDATE(), 'Nut-Ginger Garlic Paste-20237822194215')
INSERT INTO IngredientNutrients (Calories, Protein, Carbohydrates, Fat, Sugar, CreateDate, Uid)
VALUES (314, 12, 56.6, 16.5, 9.58, GETDATE(), 'Nut-Red Chilli Powder-20237822194215')
INSERT INTO IngredientNutrients (Calories, Protein, Carbohydrates, Fat, Sugar, CreateDate, Uid)
VALUES (311, 10, 68, 7, 0, GETDATE(), 'Nut-Green Cardamom Pods-20237822194215')
INSERT INTO IngredientNutrients (Calories, Protein, Carbohydrates, Fat, Sugar, CreateDate, Uid)
VALUES (274, 6, 65, 13, 2, GETDATE(), 'Nut-Clove-20237822194215')
INSERT INTO IngredientNutrients (Calories, Protein, Carbohydrates, Fat, Sugar, CreateDate, Uid)
VALUES (313, 7.61, 74.97, 8.36, 0, GETDATE(), 'Nut-Bay Leaf-20237822194215')
INSERT INTO IngredientNutrients (Calories, Protein, Carbohydrates, Fat, Sugar, CreateDate, Uid)
VALUES (247, 4, 80.6, 1.2, 2.2, GETDATE(), 'Nut-Cinnamon-20237822194215')
INSERT INTO IngredientNutrients (Calories, Protein, Carbohydrates, Fat, Sugar, CreateDate, Uid)
VALUES (25, 1, 6, 0.2, 3.5, GETDATE(), 'Nut-Eggplant-20237822194215')
INSERT INTO IngredientNutrients (Calories, Protein, Carbohydrates, Fat, Sugar, CreateDate, Uid)
VALUES (17, 1.2, 3.1, 0.3, 2.5, GETDATE(), 'Nut-Zucchini-20237822194215')
INSERT INTO IngredientNutrients (Calories, Protein, Carbohydrates, Fat, Sugar, CreateDate, Uid)
VALUES (18, 0.9, 3.9, 0.2, 2.6, GETDATE(), 'Nut-Tomato-20237822194215')
INSERT INTO IngredientNutrients (Calories, Protein, Carbohydrates, Fat, Sugar, CreateDate, Uid)
VALUES (276, 9.1, 63.9, 7.4, 1.7, GETDATE(), 'Nut-Dried Thyme-20237822194215')
INSERT INTO IngredientNutrients (Calories, Protein, Carbohydrates, Fat, Sugar, CreateDate, Uid)
VALUES (250, 26, 0, 17, 0, GETDATE(), 'Nut-Beef Chuck-20237822194215')
INSERT INTO IngredientNutrients (Calories, Protein, Carbohydrates, Fat, Sugar, CreateDate, Uid)
VALUES (85, 0.1, 2.6, 0, 0.6, GETDATE(), 'Nut-Red Wine-20237822194215')
INSERT INTO IngredientNutrients (Calories, Protein, Carbohydrates, Fat, Sugar, CreateDate, Uid)
VALUES (82, 4, 18, 0.5, 10, GETDATE(), 'Nut-Tomato Paste-20237822194215')
INSERT INTO IngredientNutrients (Calories, Protein, Carbohydrates, Fat, Sugar, CreateDate, Uid)
VALUES (22, 3.1, 3.3, 0.3, 2.1, GETDATE(), 'Nut-Champignons-20237822194215')
INSERT INTO IngredientNutrients (Calories, Protein, Carbohydrates, Fat, Sugar, CreateDate, Uid)
VALUES (32, 1.4, 7.6, 0.1, 4.7, GETDATE(), 'Nut-Pearl Onions-20237822194215')
INSERT INTO IngredientNutrients (Calories, Protein, Carbohydrates, Fat, Sugar, CreateDate, Uid)
VALUES (717, 0.9, 0.1, 81, 0.1, GETDATE(), 'Nut-Butter-20237822194215')
INSERT INTO IngredientNutrients (Calories, Protein, Carbohydrates, Fat, Sugar, CreateDate, Uid)
VALUES (53, 8.9, 9.9, 0.6, 1.5, GETDATE(), 'Nut-Soy Sauce-20237822194215')
INSERT INTO IngredientNutrients (Calories, Protein, Carbohydrates, Fat, Sugar, CreateDate, Uid)
VALUES (132, 1.6, 8.7, 0, 3.2, GETDATE(), 'Nut-Rice Wine-20237822194215')
INSERT INTO IngredientNutrients (Calories, Protein, Carbohydrates, Fat, Sugar, CreateDate, Uid)
VALUES (381, 0.3, 91, 0.1, 0.3, GETDATE(), 'Nut-Corn Starch-20237822194215')
INSERT INTO IngredientNutrients (Calories, Protein, Carbohydrates, Fat, Sugar, CreateDate, Uid)
VALUES (190, 4, 44, 1, 30, GETDATE(), 'Nut-Hoisin Sauce-20237822194215')
INSERT INTO IngredientNutrients (Calories, Protein, Carbohydrates, Fat, Sugar, CreateDate, Uid)
VALUES (18, 0, 0.9, 0, 0, GETDATE(), 'Nut-Rice Vinegar-20237822194215')
INSERT INTO IngredientNutrients (Calories, Protein, Carbohydrates, Fat, Sugar, CreateDate, Uid)
VALUES (567, 25.8, 16.1, 49.2, 4.7, GETDATE(), 'Nut-Peanuts-20237822194215')
INSERT INTO IngredientNutrients (Calories, Protein, Carbohydrates, Fat, Sugar, CreateDate, Uid)
VALUES (32, 1.8, 7.3, 0.2, 2.9, GETDATE(), 'Nut-Green Onions-20237822194215')
INSERT INTO IngredientNutrients (Calories, Protein, Carbohydrates, Fat, Sugar, CreateDate, Uid)
VALUES (239, 2.8, 62.5, 5.1, 57.4, GETDATE(), 'Nut-Tamarind Paste-20237822194215')
INSERT INTO IngredientNutrients (Calories, Protein, Carbohydrates, Fat, Sugar, CreateDate, Uid)
VALUES (282, 14.1, 53.9, 12.9, 10.6, GETDATE(), 'Nut-Paprika Powder-20237822194215')
INSERT INTO IngredientNutrients (Calories, Protein, Carbohydrates, Fat, Sugar, CreateDate, Uid)
VALUES (96, 1.7, 21.5, 0.3, 0.4, GETDATE(), 'Nut-Rice Noodles-20237822194215')
INSERT INTO IngredientNutrients (Calories, Protein, Carbohydrates, Fat, Sugar, CreateDate, Uid)
VALUES (144, 15.8, 1.9, 8.5, 0.3, GETDATE(), 'Nut-Tofu-20237822194215')
INSERT INTO IngredientNutrients (Calories, Protein, Carbohydrates, Fat, Sugar, CreateDate, Uid)
VALUES (85, 18, 0, 1.7, 0, GETDATE(), 'Nut-Shrimp-20237822194215')
INSERT INTO IngredientNutrients (Calories, Protein, Carbohydrates, Fat, Sugar, CreateDate, Uid)
VALUES (31, 3.3, 5.9, 0.5, 3.3, GETDATE(), 'Nut-Bean Sprouts-20237822194215')


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
VALUES (10, 'honey', GETDATE(), 'Honey-20237822194215', 'Honey', 43, 2)
INSERT INTO Ingredients (CategoryId, IconPath, CreateDate, Uid, IngredientName, IngredientNutrientId, UnitOfMeasure)
VALUES (10, 'ketchup', GETDATE(), 'Ketchup-20237822194215', 'Ketchup', 44, 2)
INSERT INTO Ingredients (CategoryId, IconPath, CreateDate, Uid, IngredientName, IngredientNutrientId, UnitOfMeasure)
VALUES (10, 'tomatosauce', GETDATE(), 'Tomato Sauce-20237822194215', 'Tomato Sauce', 45, 2)
INSERT INTO Ingredients (CategoryId, IconPath, CreateDate, Uid, IngredientName, IngredientNutrientId, UnitOfMeasure)
VALUES (7, 'pasta', GETDATE(), 'Pasta-20237822194215', 'Pasta', 46, 1)
INSERT INTO Ingredients (CategoryId, IconPath, CreateDate, Uid, IngredientName, IngredientNutrientId, UnitOfMeasure)
VALUES (7, 'dough', GETDATE(), 'Dough-20237822194215', 'Dough', 47, 1)
INSERT INTO Ingredients (CategoryId, IconPath, CreateDate, Uid, IngredientName, IngredientNutrientId, UnitOfMeasure)
VALUES (10, 'eggs', GETDATE(), 'Eggs-20237822194215', 'Eggs', 48, 1)
INSERT INTO Ingredients (CategoryId, IconPath, CreateDate, Uid, IngredientName, IngredientNutrientId, UnitOfMeasure)
VALUES (4, 'blackpepper', GETDATE(), 'Black Pepper-20237822194215', 'Black Pepper', 49, 1)
INSERT INTO Ingredients (CategoryId, IconPath, CreateDate, Uid, IngredientName, IngredientNutrientId, UnitOfMeasure)
VALUES (4, 'parsley', GETDATE(), 'Parsley-20237822194215', 'Parsley', 50, 1)
INSERT INTO Ingredients (CategoryId, IconPath, CreateDate, Uid, IngredientName, IngredientNutrientId, UnitOfMeasure)
VALUES (7, 'tortilla', GETDATE(), 'Tortilla-20237822194215', 'Tortilla', 51, 1)
INSERT INTO Ingredients (CategoryId, IconPath, CreateDate, Uid, IngredientName, IngredientNutrientId, UnitOfMeasure)
VALUES (3, 'bellpepper', GETDATE(), 'Bell Pepper-20237822194215', 'Bell Pepper', 52, 1)
INSERT INTO Ingredients (CategoryId, IconPath, CreateDate, Uid, IngredientName, IngredientNutrientId, UnitOfMeasure)
VALUES (5, 'chicken', GETDATE(), 'Chicken-20237822194215', 'Chicken', 53, 1)
INSERT INTO Ingredients (CategoryId, IconPath, CreateDate, Uid, IngredientName, IngredientNutrientId, UnitOfMeasure)
VALUES (10, 'salsa', GETDATE(), 'Salsa-20237822194215', 'Salsa', 54, 2)
INSERT INTO Ingredients (CategoryId, IconPath, CreateDate, Uid, IngredientName, IngredientNutrientId, UnitOfMeasure)
VALUES (10, 'broth', GETDATE(), 'Broth-20237822194215', 'Broth', 55, 2)
INSERT INTO Ingredients (CategoryId, IconPath, CreateDate, Uid, IngredientName, IngredientNutrientId, UnitOfMeasure)
VALUES (7, 'tortillachips', GETDATE(), 'Tortilla Chips-20237822194215', 'Tortilla Chips', 56, 1)
INSERT INTO Ingredients (CategoryId, IconPath, CreateDate, Uid, IngredientName, IngredientNutrientId, UnitOfMeasure)
VALUES (4, 'cilantro', GETDATE(), 'Cilantro-20237822194215', 'Cilantro', 57, 1)
INSERT INTO Ingredients (CategoryId, IconPath, CreateDate, Uid, IngredientName, IngredientNutrientId, UnitOfMeasure)
VALUES (3, 'redonion', GETDATE(), 'Red Onion-20237822194215', 'Red Onion', 58, 1)
INSERT INTO Ingredients (CategoryId, IconPath, CreateDate, Uid, IngredientName, IngredientNutrientId, UnitOfMeasure)
VALUES (8, 'sourcream', GETDATE(), 'Sour Cream-20237822194215', 'Sour Cream', 59, 2)
INSERT INTO Ingredients (CategoryId, IconPath, CreateDate, Uid, IngredientName, IngredientNutrientId, UnitOfMeasure)
VALUES (7, 'wheatflour', GETDATE(), 'Wheat Flour-20237822194215', 'Wheat Flour', 60, 1)
INSERT INTO Ingredients (CategoryId, IconPath, CreateDate, Uid, IngredientName, IngredientNutrientId, UnitOfMeasure)
VALUES (10, 'vegetableoil', GETDATE(), 'Vegetable Oil-20237822194215', 'Vegetable Oil', 61, 2)
INSERT INTO Ingredients (CategoryId, IconPath, CreateDate, Uid, IngredientName, IngredientNutrientId, UnitOfMeasure)
VALUES (10, 'water', GETDATE(), 'Water-20237822194215', 'Water', 62, 2)
INSERT INTO Ingredients (CategoryId, IconPath, CreateDate, Uid, IngredientName, IngredientNutrientId, UnitOfMeasure)
VALUES (3, 'greenpeas', GETDATE(), 'Green Peas-20237822194215', 'Green Peas', 63, 1)
INSERT INTO Ingredients (CategoryId, IconPath, CreateDate, Uid, IngredientName, IngredientNutrientId, UnitOfMeasure)
VALUES (3, 'greenchilli', GETDATE(), 'Green Chilli-20237822194215', 'Green Chilli', 64, 1)
INSERT INTO Ingredients (CategoryId, IconPath, CreateDate, Uid, IngredientName, IngredientNutrientId, UnitOfMeasure)
VALUES (4, 'ginger', GETDATE(), 'Ginger-20237822194215', 'Ginger', 65, 1)
INSERT INTO Ingredients (CategoryId, IconPath, CreateDate, Uid, IngredientName, IngredientNutrientId, UnitOfMeasure)
VALUES (4, 'cuminseeds', GETDATE(), 'Cumin Seeds-20237822194215', 'Cumin Seeds', 66, 1)
INSERT INTO Ingredients (CategoryId, IconPath, CreateDate, Uid, IngredientName, IngredientNutrientId, UnitOfMeasure)
VALUES (4, 'corianderseeds', GETDATE(), 'Coriander Seeds-20237822194215', 'Coriander Seeds', 67, 1)
INSERT INTO Ingredients (CategoryId, IconPath, CreateDate, Uid, IngredientName, IngredientNutrientId, UnitOfMeasure)
VALUES (4, 'garammasala', GETDATE(), 'Garam Masala-20237822194215', 'Garam Masala', 68, 1)
INSERT INTO Ingredients (CategoryId, IconPath, CreateDate, Uid, IngredientName, IngredientNutrientId, UnitOfMeasure)
VALUES (4, 'turmericpowder', GETDATE(), 'Turmeric Powder-20237822194215', 'Turmeric Powder', 69, 1)
INSERT INTO Ingredients (CategoryId, IconPath, CreateDate, Uid, IngredientName, IngredientNutrientId, UnitOfMeasure)
VALUES (2, 'eggplant', GETDATE(), 'Eggplant-20237822194215', 'Eggplant', 70, 1)
INSERT INTO Ingredients (CategoryId, IconPath, CreateDate, Uid, IngredientName, IngredientNutrientId, UnitOfMeasure)
VALUES (7, 'basmatirice', GETDATE(), 'Basmati Rice-20237822194215', 'Basmati Rice', 71, 1)
INSERT INTO Ingredients (CategoryId, IconPath, CreateDate, Uid, IngredientName, IngredientNutrientId, UnitOfMeasure)
VALUES (10, 'gingergarlicpaste', GETDATE(), 'Ginger Garlic Paste-20237822194215', 'Ginger Garlic Paste', 72, 1)
INSERT INTO Ingredients (CategoryId, IconPath, CreateDate, Uid, IngredientName, IngredientNutrientId, UnitOfMeasure)
VALUES (4, 'redchillipowder', GETDATE(), 'Red Chilli Powder-20237822194215', 'Red Chilli Powder', 73, 1)
INSERT INTO Ingredients (CategoryId, IconPath, CreateDate, Uid, IngredientName, IngredientNutrientId, UnitOfMeasure)
VALUES (4, 'greencardamompods', GETDATE(), 'Green Cardamom Pods-20237822194215', 'Green Cardamom Pods', 74, 1)
INSERT INTO Ingredients (CategoryId, IconPath, CreateDate, Uid, IngredientName, IngredientNutrientId, UnitOfMeasure)
VALUES (4, 'clove', GETDATE(), 'Clove-20237822194215', 'Clove', 75, 1)
INSERT INTO Ingredients (CategoryId, IconPath, CreateDate, Uid, IngredientName, IngredientNutrientId, UnitOfMeasure)
VALUES (4, 'bayleaf', GETDATE(), 'Bay Leaf-20237822194215', 'Bay Leaf', 76, 1)
INSERT INTO Ingredients (CategoryId, IconPath, CreateDate, Uid, IngredientName, IngredientNutrientId, UnitOfMeasure)
VALUES (4, 'cinnamon', GETDATE(), 'Cinnamon-20237822194215', 'Cinnamon', 77, 1)
INSERT INTO Ingredients (CategoryId, IconPath, CreateDate, Uid, IngredientName, IngredientNutrientId, UnitOfMeasure)
VALUES (2, 'eggplant', GETDATE(), 'Eggplant-20237822194215', 'Eggplant', 78, 1)
INSERT INTO Ingredients (CategoryId, IconPath, CreateDate, Uid, IngredientName, IngredientNutrientId, UnitOfMeasure)
VALUES (2, 'zucchini', GETDATE(), 'Zucchini-20237822194215', 'Zucchini', 79, 1)
INSERT INTO Ingredients (CategoryId, IconPath, CreateDate, Uid, IngredientName, IngredientNutrientId, UnitOfMeasure)
VALUES (2, 'tomato', GETDATE(), 'Tomato-20237822194215', 'Tomato', 80, 1)
INSERT INTO Ingredients (CategoryId, IconPath, CreateDate, Uid, IngredientName, IngredientNutrientId, UnitOfMeasure)
VALUES (4, 'driedthyme', GETDATE(), 'Dried Thyme-20237822194215', 'Dried Thyme', 81, 1)
INSERT INTO Ingredients (CategoryId, IconPath, CreateDate, Uid, IngredientName, IngredientNutrientId, UnitOfMeasure)
VALUES (5, 'beefchuck', GETDATE(), 'Beef Chuck-20237822194215', 'Beef Chuck', 82, 1)
INSERT INTO Ingredients (CategoryId, IconPath, CreateDate, Uid, IngredientName, IngredientNutrientId, UnitOfMeasure)
VALUES (10, 'redwine', GETDATE(), 'Red Wine-20237822194215', 'Red Wine', 83, 2)
INSERT INTO Ingredients (CategoryId, IconPath, CreateDate, Uid, IngredientName, IngredientNutrientId, UnitOfMeasure)
VALUES (10, 'tomatopaste', GETDATE(), 'Tomato Paste-20237822194215', 'Tomato Paste', 84, 2)
INSERT INTO Ingredients (CategoryId, IconPath, CreateDate, Uid, IngredientName, IngredientNutrientId, UnitOfMeasure)
VALUES (10, 'champignons', GETDATE(), 'Champignons-20237822194215', 'Champignons', 85, 1)
INSERT INTO Ingredients (CategoryId, IconPath, CreateDate, Uid, IngredientName, IngredientNutrientId, UnitOfMeasure)
VALUES (3, 'pearlonions', GETDATE(), 'Pearl Onions-20237822194215', 'Pearl Onions', 86, 1)
INSERT INTO Ingredients (CategoryId, IconPath, CreateDate, Uid, IngredientName, IngredientNutrientId, UnitOfMeasure)
VALUES (8, 'butter', GETDATE(), 'Butter-20237822194215', 'Butter', 87, 1)
INSERT INTO Ingredients (CategoryId, IconPath, CreateDate, Uid, IngredientName, IngredientNutrientId, UnitOfMeasure)
VALUES (10, 'soysauce', GETDATE(), 'Soy Sauce-20237822194215', 'Soy Sauce', 88, 2)
INSERT INTO Ingredients (CategoryId, IconPath, CreateDate, Uid, IngredientName, IngredientNutrientId, UnitOfMeasure)
VALUES (10, 'ricewine', GETDATE(), 'Rice Wine-20237822194215', 'Rice Wine', 89, 2)
INSERT INTO Ingredients (CategoryId, IconPath, CreateDate, Uid, IngredientName, IngredientNutrientId, UnitOfMeasure)
VALUES (7, 'cornstarch', GETDATE(), 'Corn Starch-20237822194215', 'Corn Starch', 90, 1)
INSERT INTO Ingredients (CategoryId, IconPath, CreateDate, Uid, IngredientName, IngredientNutrientId, UnitOfMeasure)
VALUES (10, 'hoisinsauce', GETDATE(), 'Hoisin Sauce-20237822194215', 'Hoisin Sauce', 91, 2)
INSERT INTO Ingredients (CategoryId, IconPath, CreateDate, Uid, IngredientName, IngredientNutrientId, UnitOfMeasure)
VALUES (10, 'ricevinegar', GETDATE(), 'Rice Vinegar-20237822194215', 'Rice Vinegar', 92, 2)
INSERT INTO Ingredients (CategoryId, IconPath, CreateDate, Uid, IngredientName, IngredientNutrientId, UnitOfMeasure)
VALUES (9, 'peanuts', GETDATE(), 'Peanuts-20237822194215', 'Peanuts', 93, 1)
INSERT INTO Ingredients (CategoryId, IconPath, CreateDate, Uid, IngredientName, IngredientNutrientId, UnitOfMeasure)
VALUES (3, 'greenonions', GETDATE(), 'Green Onions-20237822194215', 'Green Onions', 94, 1)
INSERT INTO Ingredients (CategoryId, IconPath, CreateDate, Uid, IngredientName, IngredientNutrientId, UnitOfMeasure)
VALUES (4, 'tamarindpaste', GETDATE(), 'Tamarind Paste-20237822194215', 'Tamarind Paste', 95, 1)
INSERT INTO Ingredients (CategoryId, IconPath, CreateDate, Uid, IngredientName, IngredientNutrientId, UnitOfMeasure)
VALUES (4, 'paprikapowder', GETDATE(), 'Paprika Powder-20237822194215', 'Paprika Powder', 96, 1)
INSERT INTO Ingredients (CategoryId, IconPath, CreateDate, Uid, IngredientName, IngredientNutrientId, UnitOfMeasure)
VALUES (7, 'ricenoodles', GETDATE(), 'Rice Noodles-20237822194215', 'Rice Noodles', 97, 1)
INSERT INTO Ingredients (CategoryId, IconPath, CreateDate, Uid, IngredientName, IngredientNutrientId, UnitOfMeasure)
VALUES (10, 'tofu', GETDATE(), 'Tofu-20237822194215', 'Tofu', 98, 1)
INSERT INTO Ingredients (CategoryId, IconPath, CreateDate, Uid, IngredientName, IngredientNutrientId, UnitOfMeasure)
VALUES (6, 'shrimp', GETDATE(), 'Shrimp-20237822194215', 'Shrimp', 99, 1)
INSERT INTO Ingredients (CategoryId, IconPath, CreateDate, Uid, IngredientName, IngredientNutrientId, UnitOfMeasure)
VALUES (3, 'beansprouts', GETDATE(), 'Bean Sprouts-20237822194215', 'Bean Sprouts', 100, 1)


INSERT INTO RecipeIngredients (CulinaryRecipeId, IngredientId, Amount)
VALUES (1, 47, 400)
INSERT INTO RecipeIngredients (CulinaryRecipeId, IngredientId, Amount)
VALUES (1, 45, 200)
INSERT INTO RecipeIngredients (CulinaryRecipeId, IngredientId, Amount)
VALUES (1, 41, 300)
INSERT INTO RecipeIngredients (CulinaryRecipeId, IngredientId, Amount)
VALUES (1, 42, 20)
INSERT INTO RecipeIngredients (CulinaryRecipeId, IngredientId, Amount)
VALUES (1, 30, 10)
INSERT INTO RecipeIngredients (CulinaryRecipeId, IngredientId, Amount)
VALUES (1, 28, 10)


INSERT INTO RecipeIngredients (CulinaryRecipeId, IngredientId, Amount)
VALUES (2, 46, 340)
INSERT INTO RecipeIngredients (CulinaryRecipeId, IngredientId, Amount)
VALUES (2, 48, 110)
INSERT INTO RecipeIngredients (CulinaryRecipeId, IngredientId, Amount)
VALUES (2, 41, 100)
INSERT INTO RecipeIngredients (CulinaryRecipeId, IngredientId, Amount)
VALUES (2, 22, 10)
INSERT INTO RecipeIngredients (CulinaryRecipeId, IngredientId, Amount)
VALUES (2, 30, 5)
INSERT INTO RecipeIngredients (CulinaryRecipeId, IngredientId, Amount)
VALUES (2, 49, 5)
INSERT INTO RecipeIngredients (CulinaryRecipeId, IngredientId, Amount)
VALUES (2, 50, 5)

INSERT INTO RecipeIngredients (CulinaryRecipeId, IngredientId, Amount)
VALUES (3, 51, 120)
INSERT INTO RecipeIngredients (CulinaryRecipeId, IngredientId, Amount)
VALUES (3, 41, 300)
INSERT INTO RecipeIngredients (CulinaryRecipeId, IngredientId, Amount)
VALUES (3, 24, 150)
INSERT INTO RecipeIngredients (CulinaryRecipeId, IngredientId, Amount)
VALUES (3, 52, 200)
INSERT INTO RecipeIngredients (CulinaryRecipeId, IngredientId, Amount)
VALUES (3, 53, 150)
INSERT INTO RecipeIngredients (CulinaryRecipeId, IngredientId, Amount)
VALUES (3, 42, 20)
INSERT INTO RecipeIngredients (CulinaryRecipeId, IngredientId, Amount)
VALUES (3, 59, 40)

INSERT INTO RecipeIngredients (CulinaryRecipeId, IngredientId, Amount)
VALUES (4, 54, 400)
INSERT INTO RecipeIngredients (CulinaryRecipeId, IngredientId, Amount)
VALUES (4, 56, 210)
INSERT INTO RecipeIngredients (CulinaryRecipeId, IngredientId, Amount)
VALUES (4, 41, 150)
INSERT INTO RecipeIngredients (CulinaryRecipeId, IngredientId, Amount)
VALUES (4, 48, 180)
INSERT INTO RecipeIngredients (CulinaryRecipeId, IngredientId, Amount)
VALUES (4, 57, 10)
INSERT INTO RecipeIngredients (CulinaryRecipeId, IngredientId, Amount)
VALUES (4, 58, 40)
INSERT INTO RecipeIngredients (CulinaryRecipeId, IngredientId, Amount)
VALUES (4, 59, 200)

INSERT INTO RecipeIngredients (CulinaryRecipeId, IngredientId, Amount)
VALUES (5, 60, 400)
INSERT INTO RecipeIngredients (CulinaryRecipeId, IngredientId, Amount)
VALUES (5, 61, 56)
INSERT INTO RecipeIngredients (CulinaryRecipeId, IngredientId, Amount)
VALUES (5, 30, 2)
INSERT INTO RecipeIngredients (CulinaryRecipeId, IngredientId, Amount)
VALUES (5, 62, 50)
INSERT INTO RecipeIngredients (CulinaryRecipeId, IngredientId, Amount)
VALUES (5, 23, 400)
INSERT INTO RecipeIngredients (CulinaryRecipeId, IngredientId, Amount)
VALUES (5, 26, 200)
INSERT INTO RecipeIngredients (CulinaryRecipeId, IngredientId, Amount)
VALUES (5, 16, 100)
INSERT INTO RecipeIngredients (CulinaryRecipeId, IngredientId, Amount)
VALUES (5, 63, 100)
INSERT INTO RecipeIngredients (CulinaryRecipeId, IngredientId, Amount)
VALUES (5, 24, 100)
INSERT INTO RecipeIngredients (CulinaryRecipeId, IngredientId, Amount)
VALUES (5, 64, 50)
INSERT INTO RecipeIngredients (CulinaryRecipeId, IngredientId, Amount)
VALUES (5, 65, 8)
INSERT INTO RecipeIngredients (CulinaryRecipeId, IngredientId, Amount)
VALUES (5, 22, 10)
INSERT INTO RecipeIngredients (CulinaryRecipeId, IngredientId, Amount)
VALUES (5, 66, 5)
INSERT INTO RecipeIngredients (CulinaryRecipeId, IngredientId, Amount)
VALUES (5, 67, 5)
INSERT INTO RecipeIngredients (CulinaryRecipeId, IngredientId, Amount)
VALUES (5, 68, 5)
INSERT INTO RecipeIngredients (CulinaryRecipeId, IngredientId, Amount)
VALUES (5, 30, 3)
INSERT INTO RecipeIngredients (CulinaryRecipeId, IngredientId, Amount)
VALUES (5, 61, 20)

INSERT INTO RecipeIngredients (CulinaryRecipeId, IngredientId, Amount)
VALUES (6, 53, 1000)
INSERT INTO RecipeIngredients (CulinaryRecipeId, IngredientId, Amount)
VALUES (6, 40, 200)
INSERT INTO RecipeIngredients (CulinaryRecipeId, IngredientId, Amount)
VALUES (6, 72, 15)
INSERT INTO RecipeIngredients (CulinaryRecipeId, IngredientId, Amount)
VALUES (6, 73, 10)
INSERT INTO RecipeIngredients (CulinaryRecipeId, IngredientId, Amount)
VALUES (6, 69, 10)
INSERT INTO RecipeIngredients (CulinaryRecipeId, IngredientId, Amount)
VALUES (6, 30, 3)
INSERT INTO RecipeIngredients (CulinaryRecipeId, IngredientId, Amount)
VALUES (6, 61, 30)
INSERT INTO RecipeIngredients (CulinaryRecipeId, IngredientId, Amount)
VALUES (6, 71, 400)
INSERT INTO RecipeIngredients (CulinaryRecipeId, IngredientId, Amount)
VALUES (6, 62, 1000)
INSERT INTO RecipeIngredients (CulinaryRecipeId, IngredientId, Amount)
VALUES (6, 74, 3)
INSERT INTO RecipeIngredients (CulinaryRecipeId, IngredientId, Amount)
VALUES (6, 75, 3)
INSERT INTO RecipeIngredients (CulinaryRecipeId, IngredientId, Amount)
VALUES (6, 76, 3)


INSERT INTO RecipeIngredients (CulinaryRecipeId, IngredientId, Amount)
VALUES (7, 78, 450)
INSERT INTO RecipeIngredients (CulinaryRecipeId, IngredientId, Amount)
VALUES (7, 79, 400)
INSERT INTO RecipeIngredients (CulinaryRecipeId, IngredientId, Amount)
VALUES (7, 52, 480)
INSERT INTO RecipeIngredients (CulinaryRecipeId, IngredientId, Amount)
VALUES (7, 80, 360)
INSERT INTO RecipeIngredients (CulinaryRecipeId, IngredientId, Amount)
VALUES (7, 24, 120)
INSERT INTO RecipeIngredients (CulinaryRecipeId, IngredientId, Amount)
VALUES (7, 22, 30)
INSERT INTO RecipeIngredients (CulinaryRecipeId, IngredientId, Amount)
VALUES (7, 42, 55)
INSERT INTO RecipeIngredients (CulinaryRecipeId, IngredientId, Amount)
VALUES (7, 81, 5)
INSERT INTO RecipeIngredients (CulinaryRecipeId, IngredientId, Amount)
VALUES (7, 29, 5)
INSERT INTO RecipeIngredients (CulinaryRecipeId, IngredientId, Amount)
VALUES (7, 30, 5)
INSERT INTO RecipeIngredients (CulinaryRecipeId, IngredientId, Amount)
VALUES (7, 49, 5)
INSERT INTO RecipeIngredients (CulinaryRecipeId, IngredientId, Amount)
VALUES (7, 28, 5)



INSERT INTO RecipeIngredients (CulinaryRecipeId, IngredientId, Amount)
VALUES (8, 82, 1000)
INSERT INTO RecipeIngredients (CulinaryRecipeId, IngredientId, Amount)
VALUES (8, 32, 260)
INSERT INTO RecipeIngredients (CulinaryRecipeId, IngredientId, Amount)
VALUES (8, 42, 10)
INSERT INTO RecipeIngredients (CulinaryRecipeId, IngredientId, Amount)
VALUES (8, 24, 260)
INSERT INTO RecipeIngredients (CulinaryRecipeId, IngredientId, Amount)
VALUES (8, 16, 120)
INSERT INTO RecipeIngredients (CulinaryRecipeId, IngredientId, Amount)
VALUES (8, 22, 10)
INSERT INTO RecipeIngredients (CulinaryRecipeId, IngredientId, Amount)
VALUES (8, 83, 750)
INSERT INTO RecipeIngredients (CulinaryRecipeId, IngredientId, Amount)
VALUES (8, 55, 400)
INSERT INTO RecipeIngredients (CulinaryRecipeId, IngredientId, Amount)
VALUES (8, 84, 30)
INSERT INTO RecipeIngredients (CulinaryRecipeId, IngredientId, Amount)
VALUES (8, 81, 5)
INSERT INTO RecipeIngredients (CulinaryRecipeId, IngredientId, Amount)
VALUES (8, 76, 5)
INSERT INTO RecipeIngredients (CulinaryRecipeId, IngredientId, Amount)
VALUES (8, 30, 3)
INSERT INTO RecipeIngredients (CulinaryRecipeId, IngredientId, Amount)
VALUES (8, 49, 3)
INSERT INTO RecipeIngredients (CulinaryRecipeId, IngredientId, Amount)
VALUES (8, 85, 450)
INSERT INTO RecipeIngredients (CulinaryRecipeId, IngredientId, Amount)
VALUES (8, 86, 300)
INSERT INTO RecipeIngredients (CulinaryRecipeId, IngredientId, Amount)
VALUES (8, 87, 30)
INSERT INTO RecipeIngredients (CulinaryRecipeId, IngredientId, Amount)
VALUES (8, 50, 10)


INSERT INTO RecipeIngredients (CulinaryRecipeId, IngredientId, Amount)
VALUES (9, 53, 450)
INSERT INTO RecipeIngredients (CulinaryRecipeId, IngredientId, Amount)
VALUES (9, 88, 60)
INSERT INTO RecipeIngredients (CulinaryRecipeId, IngredientId, Amount)
VALUES (9, 89, 15)
INSERT INTO RecipeIngredients (CulinaryRecipeId, IngredientId, Amount)
VALUES (9, 90, 5)
INSERT INTO RecipeIngredients (CulinaryRecipeId, IngredientId, Amount)
VALUES (9, 91, 15)
INSERT INTO RecipeIngredients (CulinaryRecipeId, IngredientId, Amount)
VALUES (9, 92, 15)
INSERT INTO RecipeIngredients (CulinaryRecipeId, IngredientId, Amount)
VALUES (9, 31, 15)
INSERT INTO RecipeIngredients (CulinaryRecipeId, IngredientId, Amount)
VALUES (9, 55, 50)
INSERT INTO RecipeIngredients (CulinaryRecipeId, IngredientId, Amount)
VALUES (9, 61, 30)
INSERT INTO RecipeIngredients (CulinaryRecipeId, IngredientId, Amount)
VALUES (9, 93, 100)
INSERT INTO RecipeIngredients (CulinaryRecipeId, IngredientId, Amount)
VALUES (9, 25, 50)
INSERT INTO RecipeIngredients (CulinaryRecipeId, IngredientId, Amount)
VALUES (9, 22, 20)
INSERT INTO RecipeIngredients (CulinaryRecipeId, IngredientId, Amount)
VALUES (9, 65, 8)
INSERT INTO RecipeIngredients (CulinaryRecipeId, IngredientId, Amount)
VALUES (9, 94, 30)
INSERT INTO RecipeIngredients (CulinaryRecipeId, IngredientId, Amount)
VALUES (9, 52, 240)


INSERT INTO RecipeIngredients (CulinaryRecipeId, IngredientId, Amount)
VALUES (11, 95, 45)
INSERT INTO RecipeIngredients (CulinaryRecipeId, IngredientId, Amount)
VALUES (11, 88, 30)
INSERT INTO RecipeIngredients (CulinaryRecipeId, IngredientId, Amount)
VALUES (11, 31, 30)
INSERT INTO RecipeIngredients (CulinaryRecipeId, IngredientId, Amount)
VALUES (11, 96, 2)
INSERT INTO RecipeIngredients (CulinaryRecipeId, IngredientId, Amount)
VALUES (11, 97, 225)
INSERT INTO RecipeIngredients (CulinaryRecipeId, IngredientId, Amount)
VALUES (11, 61, 30)
INSERT INTO RecipeIngredients (CulinaryRecipeId, IngredientId, Amount)
VALUES (11, 22, 10)
INSERT INTO RecipeIngredients (CulinaryRecipeId, IngredientId, Amount)
VALUES (11, 98, 120)
INSERT INTO RecipeIngredients (CulinaryRecipeId, IngredientId, Amount)
VALUES (11, 48, 60)
INSERT INTO RecipeIngredients (CulinaryRecipeId, IngredientId, Amount)
VALUES (11, 99, 120)
INSERT INTO RecipeIngredients (CulinaryRecipeId, IngredientId, Amount)
VALUES (11, 100, 240)
INSERT INTO RecipeIngredients (CulinaryRecipeId, IngredientId, Amount)
VALUES (11, 94, 30)
INSERT INTO RecipeIngredients (CulinaryRecipeId, IngredientId, Amount)
VALUES (11, 93, 15)
INSERT INTO RecipeIngredients (CulinaryRecipeId, IngredientId, Amount)
VALUES (11, 9, 50)