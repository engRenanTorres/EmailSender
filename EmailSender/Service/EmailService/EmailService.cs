using MailKit.Security;
using MimeKit.Text;
using MimeKit;
using MailKit.Net.Smtp;

namespace EmailSender.Service.EmailService
{
    public class EmailService : IEmailService
    {
        public void SendEmail(EmailDTO request)
        {
            var email = new MimeMessage();
            email.From.Add(MailboxAddress.Parse("jonathan.kreiger1@ethereal.email"));
            email.To.Add(MailboxAddress.Parse(request.To));
            email.Subject = request.Subject;
            email.Body = new TextPart(TextFormat.Html) { Text = request.Body };

            using var smtp = new SmtpClient();
            //"smtp - mail.outlook.com",
            smtp.Connect(
                "smtp.ethereal.email",
                587,
                SecureSocketOptions.StartTls);
            //smtp.Authenticate("engrtorres@outlook.com","nxx");
            smtp.Authenticate("jonathan.kreiger1@ethereal.email", "pASk2PV5BFmjzR6d42");
            smtp.Send(email);
            smtp.Disconnect(true);
        }
    }
}
