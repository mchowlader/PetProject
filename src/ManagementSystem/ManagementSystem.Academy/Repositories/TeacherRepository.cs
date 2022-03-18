using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevSkill.Data;
using ManagementSystem.Academy.Contexts;
using ManagementSystem.Academy.Entities;

namespace ManagementSystem.Academy.Repositories
{
    public class TeacherRepository : Repository<Teacher, int, AcademyDbContext>, ITeacherRepository
    {
        public TeacherRepository(IAcademyDbContext context) 
            : base((AcademyDbContext)context)
        {
        }
    }
}
