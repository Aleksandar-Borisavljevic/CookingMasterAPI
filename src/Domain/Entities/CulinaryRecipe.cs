
namespace CookingMasterApi.Domain.Entities;
public class CulinaryRecipe
{
    public int Id { get; set; }
    public Guid Uid { get; set; } = Guid.NewGuid();
    public required string RecipeName { get; set; }
    public string RecipeDescription { get; set; }
    public DateTime CreateDate { get; set; } = DateTime.UtcNow;
    public DateTime? DeleteDate { get; set; }
    public Guid? UserUid { get; set; }
    public int CuisineTypeId { get; set; }
    public CuisineType CuisineType { get; set; }


}
