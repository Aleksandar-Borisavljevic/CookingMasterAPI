
namespace CookingMasterApi.Domain.Entities;
public class CuisineType: BaseAuditableEntity
{
    public int Id { get; set; }
    public Guid Uid { get; set; } = Guid.NewGuid();
    public required string CuisineName { get; set; }
}
