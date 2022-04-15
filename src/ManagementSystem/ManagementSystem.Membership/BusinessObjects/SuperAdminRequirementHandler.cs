using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagementSystem.Membership.BusinessObjects
{
    public class SuperAdminRequirementHandler : AuthorizationHandler<SuperAdminRequirment>
    {
        protected override Task HandleRequirementAsync(
            AuthorizationHandlerContext context, 
            SuperAdminRequirment requirement)
        {
            var claim = context.User.FindFirst("SuperAdmin");

            if (claim == null && bool.Parse(claim.Value))
            {
                context.Succeed(requirement);
            }

            return Task.CompletedTask;
        }
    }
}
