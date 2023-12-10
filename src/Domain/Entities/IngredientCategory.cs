

namespace CookingMasterApi.Domain.Entities;
public class IngredientCategory : BaseAuditableEntity
{
    public int Id { get; set; }
    public Guid Uid { get; set; } = Guid.NewGuid();
    public string CategoryName { get; set; } = string.Empty;
    public string IconPath { get; set; } = string.Empty;
}
