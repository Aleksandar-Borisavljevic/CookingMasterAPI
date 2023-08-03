USE CookingMaster_DB

GO

UPDATE dbo.IngredientCategories 
SET CategoryName = 'Spices and Herbs', IconPath = 'spices and herbs'
WHERE CategoryId = 5;