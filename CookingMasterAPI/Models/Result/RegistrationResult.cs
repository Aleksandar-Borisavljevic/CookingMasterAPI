using CookingMasterAPI.Enums;

namespace CookingMasterAPI.Models.Result
{
    public class RegistrationResult : BaseResult<StatusRegisterEnum>
    {
        public RegistrationResult(StatusRegisterEnum registerEnum, string description)
        : base(registerEnum, description)
        {            
        }
    }
}
