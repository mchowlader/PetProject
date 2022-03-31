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
    public class InstituteRepository : Repository<Institutes, Guid, AcademyDbContext>, IInstituteRepository
    {
        public InstituteRepository(IAcademyDbContext context) 
            : base((AcademyDbContext)context)
        {
        }
    }
}
