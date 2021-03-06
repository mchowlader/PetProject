using DevSkill.Data;
using ManagementSystem.Membership.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagementSystem.Academy.Entities
{
    public class Teacher : IEntity<Guid>
    {
        public Guid Id { get; set; }
        public Guid InstitutesId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public int MobileNo{ get; set; }
        public string Photo { get; set; }
        public string Gender { get; set; }
        public string Designation { get; set; }
        public Institutes Institutes { get; set; }
        public IList<Course> Courses { get; set; }


    }
}
