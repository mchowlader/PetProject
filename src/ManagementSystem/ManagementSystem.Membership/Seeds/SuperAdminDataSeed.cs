using ManagementSystem.Membership.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ManagementSystem.Membership.Seeds
{
    public class SuperAdminDataSeed
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public SuperAdminDataSeed(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task SeedUserAsync()
        {
            var superAdminUser = new ApplicationUser()
            {
                UserName = "mithun.howlader222@gmail.com",
                Email = "mithun.howlader222@gmail.com",
                EmailConfirmed = true
            };

            IdentityResult result = null;
            var password = "mithun.howlader222@gmail.com";
            
            if(await _userManager.FindByEmailAsync(superAdminUser.Email) == null)
            {
                result = await _userManager.CreateAsync(superAdminUser, password);
                
                if(result.Succeeded)
                {
                    await _userManager.AddToRoleAsync(superAdminUser, "SuperAdmin");
                    await _userManager.AddClaimAsync(superAdminUser, new Claim("SuperAdmin", "true"));
                }
            }
        }
    }
}
