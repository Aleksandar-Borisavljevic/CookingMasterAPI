
namespace CookingMasterApi.Application.Common.Models;
public class EmailData
{
    public string EmailTo { get; set; }
    public string EmailSubject { get; set; }
    public string EmailHtmlBody { get; set; }

    public EmailData(string emailTo, string emailSubject, string emailHtmlBody)
    {
        EmailTo = emailTo;
        EmailSubject = emailSubject;
        EmailHtmlBody = emailHtmlBody;
    }
}
