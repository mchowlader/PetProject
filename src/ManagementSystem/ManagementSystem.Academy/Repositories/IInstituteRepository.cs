using DevSkill.Data;
using ManagementSystem.Academy.Contexts;
using ManagementSystem.Academy.Entities;
using System;

namespace ManagementSystem.Academy.Repositories
{
    public interface IInstituteRepository : IRepository<Institutes, Guid, AcademyDbContext>
    {
    }
}