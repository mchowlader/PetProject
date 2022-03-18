using Microsoft.AspNetCore.Identity;
using System;

namespace ManagementSystem.Membership.Entities
{
    public class ApplicationUser : IdentityUser<Guid>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Photo { get; set; }
        public string Department { get; set; }
    }
}
