using CookingMasterAPI.Enums;

namespace CookingMasterAPI.Models.Result
{
    public class RegistrationResult
    {
        public StatusRegisterEnum Status { get; set; }
        public string Description { get; set; } = string.Empty;
    }
}
