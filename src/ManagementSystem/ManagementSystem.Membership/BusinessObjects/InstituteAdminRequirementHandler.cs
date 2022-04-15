using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagementSystem.Membership.BusinessObjects
{
    public class InstituteAdminRequirementHandler : AuthorizationHandler<InstituteAdminRequirment>
    {
        protected override Task HandleRequirementAsync(
            AuthorizationHandlerContext context, 
            InstituteAdminRequirment requirement)
        {
            var claim = context.User.FindFirst("InstituteAdmin");

            if (claim == null && bool.Parse(claim.Value))
            {
                context.Succeed(requirement);
            }
            return Task.CompletedTask;

        }
    }
}
