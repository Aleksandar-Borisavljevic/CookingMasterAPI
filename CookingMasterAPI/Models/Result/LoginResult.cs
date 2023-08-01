using CookingMasterAPI.Enums;
using CookingMasterAPI.Models.Response;

namespace CookingMasterAPI.Models.Result
{
    public class LoginResult : BaseResult<StatusLoginEnum>
    {
        public LoginResult(StatusLoginEnum status, string description, UserResponse? user = null)
            : base(status, description)
        {
            User = user;
        }
        public UserResponse? User { get; set; }
    }
}
