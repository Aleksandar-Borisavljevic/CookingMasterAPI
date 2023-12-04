using CookingMasterApi.Application.Common.Interfaces;
using CookingMasterApi.Application.Common.Models;
using CookingMasterApi.Infrastructure.Options;
using MailKit.Net.Smtp;
using MimeKit;

namespace CookingMasterApi.Infrastructure.Services;
public class EmailService : IEmailService
{
    private readonly EmailSettings _settings;

    public EmailService(EmailSettings settings)
    {
        _settings = settings;
    }

    public async Task Send(EmailData data)
    {
        using (MimeMessage emailMessage = new MimeMessage())
        {
            MailboxAddress emailFrom = new MailboxAddress(_settings.SenderName, _settings.SenderEmail);
            emailMessage.From.Add(emailFrom);
            MailboxAddress emailTo = new MailboxAddress("Inbox", data.EmailTo);
            emailMessage.To.Add(emailTo);
            emailMessage.Subject = data.EmailSubject;
            BodyBuilder emailBodyBuilder = new BodyBuilder();
            emailBodyBuilder.HtmlBody = string.Format("<a href={0} > Register </>", data.EmailHtmlBody);
            emailMessage.Body = emailBodyBuilder.ToMessageBody();

            using (SmtpClient mailClient = new SmtpClient())
            {
                await mailClient.ConnectAsync(_settings.Server, _settings.Port, MailKit.Security.SecureSocketOptions.StartTls);
                await mailClient.AuthenticateAsync(_settings.UserName, _settings.Password);
                await mailClient.SendAsync(emailMessage);
                await mailClient.DisconnectAsync(true);
            }
        }

    }
}
