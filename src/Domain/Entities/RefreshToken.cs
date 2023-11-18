
namespace CookingMasterApi.Domain.Entities;
public class RefreshToken
{
    public int Id { get; set; }
    public required Guid UserId { get; set; }
    public required string Token { get; set; }
    public required bool IsRevoked { get; set; }
    public required DateTime ExpiryDate { get; set; }
}
