

using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CookingMasterApi.Domain.Entities;
public class IngredientCategory : BaseAuditableEntity
{
    public int CategoryId { get; set; }

    public string CategoryName { get; set; } = string.Empty;

    public string IconPath { get; set; } = string.Empty;

    public string Uid { get; set; } = string.Empty;
}
