using CookingMasterAPI.Enums;
using CookingMasterAPI.Models.DTOs;

namespace CookingMasterAPI.Models.Result
{
    public class LoginResult : BaseResult<StatusLoginEnum>
    {
        public LoginResult(StatusLoginEnum status, string description, UserDto? user = null)
            : base(status, description)
        {
            User = user;
        }
        public UserDto? User { get; set; }
    }
}
