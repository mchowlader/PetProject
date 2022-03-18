using DevSkill.Data;
using ManagementSystem.Academy.Contexts;
using ManagementSystem.Academy.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagementSystem.Academy.Repositories
{
    public class StudentRepository : Repository<Student, int, AcademyDbContext>, IStudentRepository
    {
        public StudentRepository(IAcademyDbContext context)
            : base((AcademyDbContext)context)
        {
        }
    }
}
