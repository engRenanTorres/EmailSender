using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using MimeKit.Text;

namespace EmailSender.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmailController : ControllerBase
    {
        [HttpPost]
        public IActionResult SendEmail(string body)
        {
            var email = new MimeMessage();
            email.From.Add(MailboxAddress.Parse("jonathan.kreiger1@ethereal.email"));
            email.To.Add(MailboxAddress.Parse("jonathan.kreiger1@ethereal.email"));
            email.Subject = "Test Email Subject";
            email.Body = new TextPart(TextFormat.Html) { Text = body };

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

            return Ok();
        }
    }
}
