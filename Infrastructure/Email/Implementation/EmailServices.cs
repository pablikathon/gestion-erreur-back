using FluentEmail.Core;

public class EmailService : IEmailService
{
    private readonly IFluentEmail _email;
    private readonly IEmailTemplateRenderer _renderer;
    private readonly IRateLimiter _rateLimiter;

    public EmailService(
        IFluentEmail email,
        IEmailTemplateRenderer renderer,
        IRateLimiter rateLimiter)
    {
        _email = email;
        _renderer = renderer;
        _rateLimiter = rateLimiter;
    }

    public async Task SendOtpAsync(string email, string code)
    {
        // ⛔ Rate limiting
        var allowed = _rateLimiter.Allow(email, limit: 3, windowMinutes: 5);

        if (!allowed)
            throw new Exception("Trop de demandes de code OTP");

        var html = await _renderer.RenderAsync(
            "OtpEmail.cshtml",
            new OtpEmailModel
            {
                Email = email,
                Code = code
            });

        await _email
            .To(email)
            .Subject("Code d'authentification")
            .Body(html, true)
            .SendAsync();
    }
}