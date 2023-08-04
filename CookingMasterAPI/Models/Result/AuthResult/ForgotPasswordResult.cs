using CookingMasterAPI.Enums.AuthStatusEnums;

namespace CookingMasterAPI.Models.Result.AuthResult
{
    public class ForgotPasswordResult : BaseResult<ForgotPasswordEnum>
    {
        public ForgotPasswordResult(ForgotPasswordEnum status, string description)
            : base(status, description)
        {
        }
    }
}
