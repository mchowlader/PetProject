using DevSkill.Data;
using ManagementSystem.Academy.Repositories;

namespace ManagementSystem.Academy.UnifOfWorks
{
    public interface IAcademyUnitOfWork : IUnitOfWork
    {
        ITeacherRepository TeacherRepository { get; }
        IStudentRepository StudentRepository { get; }
        IInstituteRepository InstituteRepository { get; }
    }
}