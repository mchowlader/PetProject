using Autofac;
using ManagementSystem.Academy.Services;
using ManagementSystem.Foundation.Services;
using Microsoft.AspNetCore.Http;

namespace ManagementSystem.Web.Areas.Institute.Models.StudentModel
{
    public class EditStudentModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public int MobileNo { get; set; }
        public string Photo { get; set; }
        public string Gender { get; set; }
        public IFormFile FormFile { get; set; }

        private IStudentService _studentService;
        private IPathService _pathService;
        private IFileStoreUtility _fileStoreUtility;
        private ISystemImageResizer _systemImageResizer;
        private ILifetimeScope _scope;
        public EditStudentModel()
        {

        }
        public EditStudentModel(IStudentService studentService, IPathService pathService, ISystemImageResizer systemImageResizer,
           IFileStoreUtility fileStoreUtility )
        {
            _pathService = pathService;
            _studentService = studentService;
            _fileStoreUtility = fileStoreUtility;
            _systemImageResizer = systemImageResizer;
        }

        public void Resolve(ILifetimeScope scope)
        {
            _scope = scope;
            _studentService = _scope.Resolve<IStudentService>();
            _fileStoreUtility = _scope.Resolve<IFileStoreUtility>();
            _systemImageResizer = _scope.Resolve<ISystemImageResizer>();
        }
    }
}
