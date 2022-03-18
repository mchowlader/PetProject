using Autofac;
using ManagementSystem.Academy.Contexts;
using ManagementSystem.Academy.Repositories;
using ManagementSystem.Academy.Services;
using ManagementSystem.Academy.UnifOfWorks;
using System;

namespace ManagementSystem.Academy
{
    public class AcademyModule : Module
    {
        private readonly string _connectionString;
        private readonly string _migrationAssemblyName;

        public AcademyModule(string connectionString, string migrationAssemblyName)
        {
            _connectionString = connectionString;
            _migrationAssemblyName = migrationAssemblyName;
        }
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<AcademyDbContext>().AsSelf()
                .WithParameter("connectionString", _connectionString)
                .WithParameter("migrationAssemblyName", _migrationAssemblyName)
                .InstancePerLifetimeScope();

            builder.RegisterType<AcademyDbContext>().As<IAcademyDbContext>()
                .WithParameter("connectionString", _connectionString)
                .WithParameter("migrationAssemblyName", _migrationAssemblyName)
                .InstancePerLifetimeScope();

            builder.RegisterType<AcademyUnitOfWork>().As<IAcademyUnitOfWork>()
                .InstancePerLifetimeScope();
            builder.RegisterType<TeacherRepository>().As<ITeacherRepository>()
                .InstancePerLifetimeScope();
            builder.RegisterType<TeacherService>().As<ITeacherService>()
                .InstancePerLifetimeScope();
            
            builder.RegisterType<StudentRepository>().As<IStudentRepository>()
                .InstancePerLifetimeScope();
            builder.RegisterType<StudentService>().As<IStudentService>()
                .InstancePerLifetimeScope();

            base.Load(builder);
        }
    }
}
