
using Microsoft.Extensions.Configuration;
using Resend;

namespace PersonalSavingsManage.Infrastructure.Notifications;

public class EmailService : IEmailService
{
    private readonly IResend _resend;
    private readonly string _fromEmail;
    private readonly string _fromName;

    public EmailService(IResend resend, IConfiguration configuration)
    {
        _resend = resend;
        _fromEmail = configuration.GetValue<string>("Resend:FromEmail") ?? "";
    }

    public async Task SendAsync(string email, string subject, string message)
    {

        var resendMessage = new EmailMessage
        {
            From = _fromEmail,
            Subject = subject,
            HtmlBody = $"<div><strong>{message}</div>",
            To = email,
        };

        await _resend.EmailSendAsync(resendMessage);
    }
}
