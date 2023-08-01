using CookingMasterAPI.Enums;

namespace CookingMasterAPI.Models.Result
{
    public class ResetPasswordResult : BaseResult<StatusResetPasswordEnum>
    {
        public ResetPasswordResult(StatusResetPasswordEnum status, string description)
            : base(status, description)
        {
        }
    }
}
