using CookingMasterAPI.Enums;

namespace CookingMasterAPI.Models.Result
{
    public class VerifyResult : BaseResult<StatusVerifyEnum>
    {
        public VerifyResult(StatusVerifyEnum status, string description) 
            : base(status, description)
        {
        }
    }
}
