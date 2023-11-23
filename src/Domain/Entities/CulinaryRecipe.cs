
namespace CookingMasterApi.Domain.Entities;
public class CulinaryRecipe : BaseAuditableEntity
{
    public int Id { get; set; }
    public Guid Uid { get; set; } = Guid.NewGuid();
    public required string RecipeName { get; set; }
    public string RecipeDescription { get; set; }
    public Guid? UserId { get; set; }
    public int CuisineTypeId { get; set; }
    public CuisineType CuisineType { get; set; }


}
