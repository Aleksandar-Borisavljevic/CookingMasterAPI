using CookingMasterAPI.Enums.AuthStatusEnums;

namespace CookingMasterAPI.Models.Result.AuthResult
{
    public class RegistrationResult : BaseResult<RegisterEnum>
    {
        public RegistrationResult(RegisterEnum registerEnum, string description)
        : base(registerEnum, description)
        {
        }
    }
}
