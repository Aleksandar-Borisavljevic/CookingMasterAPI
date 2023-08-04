using CookingMasterAPI.Enums.AuthStatusEnums;

namespace CookingMasterAPI.Models.Result.AuthResult
{
    public class ResetPasswordResult : BaseResult<ResetPasswordEnum>
    {
        public ResetPasswordResult(ResetPasswordEnum status, string description)
            : base(status, description)
        {
        }
    }
}
