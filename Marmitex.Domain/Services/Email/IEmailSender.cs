using System.Threading.Tasks;

namespace Marmitex.Domain.Services.Email
{
    public interface IEmailSender
    {
        Task SendEmailAsync(string email, string subject, string message);
    }
}