using CookingMasterAPI.Enums;

namespace CookingMasterAPI.Models.Result
{
    public class ForgotPasswordResult : BaseResult<StatusForgotPasswordEnum>
    {
        public ForgotPasswordResult(StatusForgotPasswordEnum status, string description)
            : base(status, description)
        {
        }
    }
}
