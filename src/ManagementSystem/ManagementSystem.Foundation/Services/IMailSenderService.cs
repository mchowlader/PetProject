using ManagementSystem.Membership.Entities;
using System.Threading.Tasks;

namespace ManagementSystem.Foundation.Services
{
    public interface IMailSenderService
    {
        Task SendEmailConfirmationMailAsync(ApplicationUser user, string verificationCode);
    }
}