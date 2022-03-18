using DevSkill.Data;
using ManagementSystem.Academy.Contexts;
using ManagementSystem.Academy.Entities;

namespace ManagementSystem.Academy.Repositories
{
    public interface IStudentRepository : IRepository<Student, int, AcademyDbContext>
    {
    }
}