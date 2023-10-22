using EmailSender.Model;

namespace EmailSender.Service.EmailService
{
    public interface IEmailService
    {
        void SendEmail(EmailDTO email);
    }
}
