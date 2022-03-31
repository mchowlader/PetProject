using Autofac;
using ManagementSystem.Web.Areas.Institute.Models.InstituteModel;
using ManagementSystem.Web.Areas.Institute.Models.StudentModel;
using ManagementSystem.Web.Areas.Institute.Models.TeacherModel;
using ManagementSystem.Web.Models;

namespace ManagementSystem.Web
{
    public class WebModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<RegisterModel>().AsSelf();
            builder.RegisterType<LoginModel>().AsSelf();
            builder.RegisterType<ConfirmEmailModel>().AsSelf();

            //Teacher
            builder.RegisterType<CreateTeacherModel>().AsSelf();
            builder.RegisterType<DataTeacherModel>().AsSelf();
            builder.RegisterType<EditTeacherModel>().AsSelf();

            //Student
            builder.RegisterType<StudentInvitationModel>().AsSelf();
            builder.RegisterType<CreateStudentModel>().AsSelf();
            builder.RegisterType<EditStudentModel>().AsSelf();
            builder.RegisterType<DataStudentModel>().AsSelf();

            //Instute
            builder.RegisterType<CreateInstituteModel>().AsSelf();

            base.Load(builder);
        }
    }
}
