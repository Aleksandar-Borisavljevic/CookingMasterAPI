USE CookingMasterDB

GO

DELETE FROM [CookingMasterDB].[dbo].[Ingredients];

GO

DELETE FROM [CookingMasterDB].[dbo].[IngredientCategories];

GO

DELETE FROM [CookingMasterDB].[dbo].[IngredientNutrients]

GO

DELETE FROM [CookingMasterDB].[dbo].[RecipeIngredients]

GO

DELETE FROM [CookingMasterDB].[dbo].[UserIngredients]

GO

DELETE FROM [CookingMasterDB].[dbo].[CuisineTypes]

GO

DBCC CHECKIDENT ('dbo.Ingredients', RESEED, 0);
DBCC CHECKIDENT ('dbo.IngredientCategories', RESEED, 0);
DBCC CHECKIDENT ('dbo.RecipeIngredients', RESEED, 0);
DBCC CHECKIDENT ('dbo.UserIngredients', RESEED, 0);
DBCC CHECKIDENT ('dbo.IngredientNutrients', RESEED, 0);
DBCC CHECKIDENT ('dbo.CuisineTypes', RESEED, 0);

GO

INSERT INTO CuisineTypes (CuisineName, Uid)
VALUES('Italian', 'Italian-1909772648542')
INSERT INTO CuisineTypes (CuisineName, Uid)
VALUES('Indian', 'Indian-1909772648542')
INSERT INTO CuisineTypes (CuisineName, Uid)
VALUES('Mexican', 'Mexican-1909772648542')

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