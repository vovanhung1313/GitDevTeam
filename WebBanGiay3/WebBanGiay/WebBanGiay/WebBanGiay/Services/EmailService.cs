using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

public class EmailService
{
    private readonly string _smtpServer;
    private readonly int _smtpPort;
    private readonly string _smtpUser;
    private readonly string _smtpPass;

    public EmailService(IConfiguration configuration)
    {
        _smtpServer = configuration["Smtp:Server"];
        _smtpPort = int.Parse(configuration["Smtp:Port"]);
        _smtpUser = configuration["Smtp:Username"];
        _smtpPass = configuration["Smtp:Password"];
    }

    public async Task SendEmailAsync(string toEmail, string subject, string body)
    {
        var client = new SmtpClient(_smtpServer, _smtpPort)
        {
            Credentials = new NetworkCredential(_smtpUser, _smtpPass),
            EnableSsl = true,
        };

        var mailMessage = new MailMessage
        {
            From = new MailAddress(_smtpUser),
            Subject = subject,
            Body = body,
            IsBodyHtml = true,
        };
        mailMessage.To.Add(toEmail);

        await client.SendMailAsync(mailMessage);
    }
}
