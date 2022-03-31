using ManagementSystem.Membership.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagementSystem.Academy.BusinessObjects
{
    public class Institutes
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid AdminUserId { get; set; }
        public ApplicationUser AdminUser { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public string LogoPath { get; set; }
        public IList<Teacher> Teachers { get; set; }
        public IList<Student> Students { get; set; }
        public DateTime CreateDate { get; set; }
    }
}
