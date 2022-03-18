using DevSkill.Data;
using ManagementSystem.Academy.Contexts;
using ManagementSystem.Academy.Entities;

namespace ManagementSystem.Academy.Repositories
{
    public interface ITeacherRepository : IRepository<Teacher,int, AcademyDbContext>
    {
    }
}