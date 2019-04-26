using System;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;


namespace Marmitex.Domain.Services.Email
{
    public class AuthMessageSender : IEmailSender
    {
        public AuthMessageSender(IOptions<EmailSettings> emailSettings)
        {
            _emailSettings = emailSettings.Value;
        }

        public AuthMessageSender(EmailSettings _emailSettings)
        {
            this._emailSettings = _emailSettings;
        }
        public EmailSettings _emailSettings { get; }

        public Task SendEmailAsync(string email, string subject, string message)
        {
            try
            {
                Execute(email, subject, message).Wait();
                return Task.FromResult(0);
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public async Task Execute(string email, string subject, string message)
        {
            try
            {
                string toEmail = string.IsNullOrEmpty(email) ? _emailSettings.ToEmail : email;

                MailMessage mail = new MailMessage()
                {
                    From = new MailAddress(_emailSettings.UsernameEmail, "Steam")
                };

                mail.To.Add(new MailAddress(toEmail));
                //mail.CC.Add(new MailAddress(_emailSettings.CcEmail));

                mail.Subject = "Steam BR - " + subject;
                mail.Body = message;
                mail.IsBodyHtml = true;
                mail.Priority = MailPriority.High;

                //outras opções
                //mail.Attachments.Add(new Attachment(arquivo));
                //

                using (SmtpClient smtp = new SmtpClient(_emailSettings.PrimaryDomain, _emailSettings.PrimaryPort))
                {
                    smtp.UseDefaultCredentials = false;
                    smtp.Credentials = new NetworkCredential(_emailSettings.UsernameEmail, _emailSettings.UsernamePassword);
                    smtp.EnableSsl = true;
                    for (int i = 0; i < 10000; i++)
                    {
                        await smtp.SendMailAsync(mail);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}