
namespace CookingMasterApi.Application.IngredientCategories.Commands.Create;
internal class CreateIngredientCategoryCommandResult
{
    public string CategoryName { get; set; }
    public string IconPath { get; set; }

    public CreateIngredientCategoryCommandResult(string categoryName, string iconPath)
    {
        CategoryName = categoryName;
        IconPath = iconPath;
    }
}
