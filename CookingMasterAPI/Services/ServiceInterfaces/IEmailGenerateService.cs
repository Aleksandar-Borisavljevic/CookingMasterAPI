namespace CookingMasterAPI.Services.ServiceInterfaces
{
    public interface IEmailGenerateService
    {
        void SendEmail(string body);
        string CreateRandomToken();
    }
}
