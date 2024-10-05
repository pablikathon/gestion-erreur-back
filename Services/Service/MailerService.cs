using System.Net;
using System.Net.Mail;
using Microsoft.Extensions.Configuration;

namespace Services
{
    public sealed class Mailer : IMailer
    {
        public required IConfiguration Configuration { get; set; }
        public Mailer(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public Task SendEmailAsync(string to, string subject, string message)
        {
            var email = Configuration["Mailer:Email"];
            var port = Configuration["Mailer:Port"];
            var smtpAddress = Configuration["Mailer:SmtpAddress"];
            var password = Configuration["Mailer:Password"];
            if (!string.IsNullOrWhiteSpace(smtpAddress) && !string.IsNullOrWhiteSpace(port)
                && !string.IsNullOrWhiteSpace(password) && !string.IsNullOrWhiteSpace(email)
            )
            {
                var client = new SmtpClient(Configuration["Mailer:SmtpAddress"], int.Parse(Configuration["Mailer:Port"]!))
                {
                    EnableSsl = true,
                    Credentials = new NetworkCredential(Configuration["Mailer:Email"], Configuration["Mailer:Password"])
                };
                return client.SendMailAsync(
                    new MailMessage(
                            from : email,
                            to : to,
                            subject,
                            message
                    )
                );
            }
            throw new Exception("smtpadress or number not found");
        }
    }
}