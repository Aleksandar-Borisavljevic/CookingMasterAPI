using CookingMasterAPI.Enums.AuthStatusEnums;
using CookingMasterAPI.Models.Entity;
using CookingMasterAPI.Models.Response;

namespace CookingMasterAPI.Models.Result.AuthResult
{
    public class LoginResult : BaseResult<LoginEnum>
    {
        public LoginResult(LoginEnum status, string description, UserResponse? user = null)
            : base(status, description)
        {
            User = user;
        }
        public UserResponse? User { get; set; }        
    }
}
