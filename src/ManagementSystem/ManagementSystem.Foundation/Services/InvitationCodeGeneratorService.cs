using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagementSystem.Foundation.Services
{
    public class InvitationCodeGeneratorService : IInvitationCodeGeneratorService
    {
        public string GetInvitationCode()
        {
            var code = Guid.NewGuid().ToString();
            var invitationCode = code.Replace("-", "");

            return invitationCode;
        }
    }
}
