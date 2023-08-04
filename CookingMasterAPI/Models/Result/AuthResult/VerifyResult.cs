using CookingMasterAPI.Enums.AuthStatusEnums;

namespace CookingMasterAPI.Models.Result.AuthResult
{
    public class VerifyResult : BaseResult<VerifyEnum>
    {
        public VerifyResult(VerifyEnum status, string description)
            : base(status, description)
        {
        }
    }
}
