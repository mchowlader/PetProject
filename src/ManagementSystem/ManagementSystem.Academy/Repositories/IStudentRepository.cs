using DevSkill.Data;
using ManagementSystem.Academy.Contexts;
using ManagementSystem.Academy.Entities;
using System;

namespace ManagementSystem.Academy.Repositories
{
    public interface IStudentRepository : IRepository<Student, Guid, AcademyDbContext>
    {
    }
}