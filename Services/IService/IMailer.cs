namespace Services
{
    public interface IMailer
    {
        Task SendEmailAsync(string to, string subject, string message);
    }
}