namespace JWTAuthenticationAuthorization;

public interface IMailKitService
{
    Task SendEmail(Message message);
}
