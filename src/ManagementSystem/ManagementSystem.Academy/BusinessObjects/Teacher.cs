using ManagementSystem.Membership.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagementSystem.Academy.BusinessObjects
{
    public class Teacher
    {
        public Guid Id { get; set; }
        public Guid AdminUserId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public int MobileNo { get; set; }
        public string Photo { get; set; }
        public string Gender { get; set; }
        public List<Student> Students { get; set; }

    }
}
