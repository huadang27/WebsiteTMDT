using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.Configuration;
using MailKit.Net.Smtp;
using MimeKit;
using System.Threading.Tasks;
namespace example.Utility
{
    public class EmailSender : IEmailSender
    {
        // sử dụng gmail
        public string Email { get; set; }
        public string Password { get; set; }

        public EmailSender(IConfiguration _config)
        {
            Email = _config.GetValue<string>("GmailSMTP:Email");
            Password = _config.GetValue<string>("GmailSMTP:Password");
        }

        public async Task SendEmailAsync(string toEmail, string subject, string htmlMessage)
        {
            var emailMessage = new MimeMessage();

            emailMessage.From.Add(new MailboxAddress("BookShop",Email));
            emailMessage.To.Add(new MailboxAddress("BookShop", toEmail));
            emailMessage.Subject = subject;
            emailMessage.Body = new TextPart("html") { Text = htmlMessage };

            using (var client = new SmtpClient())
            {
                await client.ConnectAsync("smtp.gmail.com", 587, MailKit.Security.SecureSocketOptions.StartTls);
                await client.AuthenticateAsync(Email, Password);
                await client.SendAsync(emailMessage);

                await client.DisconnectAsync(true);
            }
        }
        // sử dụng sendGrild

        //public string SendGridSecret { get; set; }

        //public EmailSender(IConfiguration _config)
        //{
        //    SendGridSecret = _config.GetValue<string>("SendGrid:SecretKey");
        //}

        //public Task SendEmailAsync(string email, string subject, string htmlMessage)
        //{
        //    var client = new SendGridClient(SendGridSecret);

        //    var from = new EmailAddress("accnichface03@gmail.com", "Bulk Book");
        //    var to = new EmailAddress(email);
        //    var message = MailHelper.CreateSingleEmail(from, to, subject, "", htmlMessage);

        //    return client.SendEmailAsync(message);
        //}
    }
}
