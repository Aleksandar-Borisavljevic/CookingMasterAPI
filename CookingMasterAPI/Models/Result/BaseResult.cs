using CookingMasterAPI.Enums;

namespace CookingMasterAPI.Models.Result
{
    public abstract class BaseResult<T>
    {
        public BaseResult(T status, string description)
        {

            Status = status;
            Description = description;
        }
        public T? Status { get; set; }
        public string Description { get; set; } = string.Empty;
    }
}
