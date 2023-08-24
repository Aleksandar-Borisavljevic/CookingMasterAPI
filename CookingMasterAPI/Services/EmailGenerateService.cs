using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit;
using MimeKit.Text;
using CookingMasterAPI.Services.ServiceInterfaces;

namespace CookingMasterAPI.Services
{
    public class EmailGenerateService : IEmailGenerateService
    {
        public void SendEmail(string body)
        {
            var email = new MimeMessage();
            email.From.Add(MailboxAddress.Parse("cookingmasterinc@gmail.com"));
            email.To.Add(MailboxAddress.Parse("napstericious@gmail.com"));
            email.Subject = "Test Email Subject";
            email.Body = new TextPart(TextFormat.Html)
            {
                Text = body
            };

            using var smtp = new SmtpClient();
            smtp.Connect("smtp.gmail.com", 587, SecureSocketOptions.StartTls);

            smtp.Authenticate("cookingmasterinc@gmail.com", "ypiqlovkjlnbqrqn");
            smtp.Send(email);
            smtp.Disconnect(true);
        }
        //TODO: Future proof this
        public string CreateRandomToken()
        {
            Random rnd = new Random();
            return rnd.Next(100000, 999999).ToString();
        }
    }
}
