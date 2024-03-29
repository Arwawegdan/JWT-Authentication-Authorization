namespace JWTAuthenticationAuthorization;

public class MailKitService(EmailConfigurations _emailConfigurations) : IMailKitService
{

    public async Task SendEmail(Message message)
    {
        var createdMessag = CreateEmailMessage(message);
        Send(createdMessag);
    }

    private MimeMessage CreateEmailMessage(Message message)
    {
        var email = new MimeMessage();
        email.From.Add(new MailboxAddress("email", _emailConfigurations.From));
        email.To.AddRange(message.To);
        email.Subject = message.Subject;
        email.Body = new TextPart(TextFormat.Text) { Text = message.Content };

        return email;
    }

    private async Task Send(MimeMessage message)
    {
        using var client = new SmtpClient();
        try
        {
            client.Connect(_emailConfigurations.SmtpServer, _emailConfigurations.Port, true);

            client.AuthenticationMechanisms.Remove("X0AUTH2");
            client.Authenticate(_emailConfigurations.From, _emailConfigurations.Password);
            await client.SendAsync(message);
        }
        catch (Exception)
        {

            throw;
        }

        finally 
        {
            client.Disconnect(true); 
            client.Dispose();
        }
    }

}
