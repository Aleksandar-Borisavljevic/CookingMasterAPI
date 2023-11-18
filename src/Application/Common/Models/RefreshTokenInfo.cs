
namespace CookingMasterApi.Application.Common.Models;
public class RefreshTokenInfo
{
    public string Token { get; set; }
    public DateTime ExpiryDate { get; set; }
}
