using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagementSystem.Academy.Entities
{
    public class CourseStudents
    {
        public Guid CourseId { get; set; }
        public Course Course { get; set; }
        public Guid StudentId { get; set; }
        public Student Student { get; set; }
    }
}
