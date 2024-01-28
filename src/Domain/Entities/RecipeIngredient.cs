
namespace CookingMasterApi.Domain.Entities;
public class RecipeIngredient : BaseAuditableEntity
{
    public int Id { get; set; }
    public int CulinaryRecipeId { get; set; }
    public CulinaryRecipe CulinaryRecipe { get; set; }
    public int IngredientId { get; set; }
    public Ingredient Ingredient { get; set; }
    public short Amount { get; set; }
}
