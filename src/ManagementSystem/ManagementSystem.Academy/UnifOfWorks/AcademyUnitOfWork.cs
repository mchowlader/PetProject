using DevSkill.Data;
using ManagementSystem.Academy.Contexts;
using ManagementSystem.Academy.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagementSystem.Academy.UnifOfWorks
{
    public class AcademyUnitOfWork : UnitOfWork, IAcademyUnitOfWork
    {
        public ITeacherRepository TeacherRepository { get; private set; }

        public IStudentRepository StudentRepository { get; private set; }

        public AcademyUnitOfWork(IAcademyDbContext context, ITeacherRepository teacherRepository, 
            IStudentRepository studentRepository) 
            : base((AcademyDbContext)context)
        {
            TeacherRepository = teacherRepository;
            StudentRepository = studentRepository;
        }

    }
}
