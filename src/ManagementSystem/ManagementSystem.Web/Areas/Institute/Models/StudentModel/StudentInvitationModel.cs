using Autofac;
using ManagementSystem.Academy.Services;
using ManagementSystem.Foundation.Exceptions;
using ManagementSystem.Foundation.Services;
using System;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace ManagementSystem.Web.Areas.Institute.Models.StudentModel
{
    public class StudentInvitationModel
    {
        [Required]
        [MaxLength(100, ErrorMessage ="name should be less than 100 charecter")]
        public string FullName { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        [RegularExpression(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$|^\+?\d{0,2}\-?\d{4,5}\-?\d{5,6}")]
        public string Email { get; set; }
        public string Status { get; set; }
        public string InvitationCode { get; set; }
        public Guid TeacherId { get; set; }

        private IStudentService _studentService;
        private ITeacherService _teacherService;
        private IInvitationCodeGeneratorService _invitationCodeGenerator;
        private ILifetimeScope _scope;
       
        public StudentInvitationModel(IStudentService studentService, 
            IInvitationCodeGeneratorService invitationCodeGenerator, ITeacherService teacherService)
        {
            _studentService = studentService;
            _teacherService = teacherService;
            _invitationCodeGenerator = invitationCodeGenerator;
        }

        public StudentInvitationModel()
        {

        }
        public void Resolve(ILifetimeScope scope)
        {
            _scope = scope;
            _studentService = _scope.Resolve<IStudentService>();
            _teacherService = _scope.Resolve<ITeacherService>();
            _invitationCodeGenerator = _scope.Resolve<IInvitationCodeGeneratorService>();
        }

        public async Task LoadModelDataAsync()
        {
            var teacher = await _teacherService.GetTeacherByUserNameAsync();

            if (teacher == null)
                throw new InvalidParameterException("Teacher not found while loading profile model.");

            TeacherId = teacher.Id;
        }
    }
}
