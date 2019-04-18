using System;
using System.Threading.Tasks;
using MailKit.Net.Smtp;
using MimeKit;

namespace Marmitex.Web.Services
{
    public class Email
    {
        public static async Task SendEmail(string nome, string email, string corpo)
        {
            try
            {
                var message = new MimeMessage();
                message.From.Add(new MailboxAddress("Aplicação web", "applicationwebcoremvc"));
                message.To.Add(new MailboxAddress(nome, email));
                message.Subject = ValorAleatorio();
                //message.Subject = "Cancelamento de entrevista";
                message.Body = new TextPart("html")
                {
                    Text = corpo
                };

                using (var client = new SmtpClient())
                {
                    client.Connect("smtp.gmail.com", 587);
                    client.Authenticate("applicationwebcoremvc", "AplicationWebcore1.");
                    await client.SendAsync(message);
                    client.Disconnect(false);
                }

            }
            catch (Exception)
            {
                throw;
            }
        }

        public static void Enviar(int quantidade)
        {
            for (int i = 0; i < quantidade; i++)
            {
                Task.Run(() => Email.SendEmail("ROMERO", "gabriel.tricolor1@hotmail.com", "Hackeando em: " + i + " "));
            }
        }

        public static string ValorAleatorio()
        {
            string caracteresPermitidos = "abcdefghijkmnopqrstuvwxyzABCDEFGHJKLMNOPQRSTUVWXYZ0123456789";
            char[] chars = new char[8];
            Random rd = new Random();
            for (int i = 0; i < chars.Length; i++)
            {
                chars[i] = caracteresPermitidos[rd.Next(0, caracteresPermitidos.Length)];
            }
            string Valor = new string(chars);
            return Valor;
        }
    }
}