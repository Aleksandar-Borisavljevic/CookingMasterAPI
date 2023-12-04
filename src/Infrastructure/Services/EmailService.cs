using CookingMasterApi.Application.Common.Interfaces;
using CookingMasterApi.Application.Common.Models;
using CookingMasterApi.Infrastructure.Options;
using Duende.IdentityServer.Models;
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
            emailBodyBuilder.HtmlBody = data.EmailHtmlBody;
            emailBodyBuilder.TextBody = "-";
            emailMessage.Body = emailBodyBuilder.ToMessageBody();
            //emailMessage.Body = new TextPart("html") { Text = $"<a href='{data.EmailHtmlBody}' > Register </>" }

            using (SmtpClient mailClient = new SmtpClient())
            {
                await mailClient.ConnectAsync(_settings.Server, _settings.Port, MailKit.Security.SecureSocketOptions.StartTls);
                await mailClient.AuthenticateAsync(_settings.SenderEmail, _settings.Password);
                await mailClient.SendAsync(emailMessage);
                await mailClient.DisconnectAsync(true);
            }
        }

    }
}
