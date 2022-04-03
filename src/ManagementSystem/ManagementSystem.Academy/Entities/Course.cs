using DevSkill.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagementSystem.Academy.Entities
{
    public class Course : IEntity<Guid>
    {
        public Guid Id { get; set; }
        public Guid TeacherId { get; set; }
        public string Title { get; set; }
        public int Fee { get; set; }
        public DateTime StartDate { get; set; }
        public Teacher Teacher { get; set; }
        public IList<CourseStudents> EnrollStudent { get; set; }
    }
}
