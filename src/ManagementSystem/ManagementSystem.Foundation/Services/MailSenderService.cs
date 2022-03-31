using Autofac;
using DevSkill.Http.Emails.Services;
using ManagementSystem.Membership.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;

namespace ManagementSystem.Foundation.Services
{
    public class MailSenderService : IMailSenderService
    {
        private readonly IUrlService _urlService;
        private readonly IEmailService _emailService;
        private readonly IQueuedEmailService _queuedEmailService;
        private const string confirmationEmailSubject = "Confirmation Email";


        public MailSenderService(IUrlService urlService, IEmailService emailService,
            IQueuedEmailService queuedEmailService)
        {
            _urlService = urlService;
            _emailService = emailService;
            _queuedEmailService = queuedEmailService;
        }

        public async Task SendEmailConfirmationMailAsync(ApplicationUser user, string verificationCode)
        {
            var verificationLink = _urlService.GenerateAbsoluteUrl("Account", "ConfirmEmail",
                new { username = user.UserName, code = verificationCode, area = "" });

            var body = $"Please login your account by using <a href='{HtmlEncoder.Default.Encode(verificationLink)}'> Clicking Here</a>.";

            await _queuedEmailService.SendSingleEmailAsync(user.UserName, user.Email, confirmationEmailSubject, body);
        }
    }
}
