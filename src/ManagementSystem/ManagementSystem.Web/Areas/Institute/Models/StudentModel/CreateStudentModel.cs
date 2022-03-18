using Autofac;
using ManagementSystem.Academy.Services;
using ManagementSystem.Academy.BusinessObjects;
using ManagementSystem.Foundation.Services;
using Microsoft.AspNetCore.Http;
using System;
using System.IO;
using System.Threading.Tasks;

namespace ManagementSystem.Web.Areas.Institute.Models.StudentModel
{
    public class CreateStudentModel
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public int MobileNo { get; set; }
        public string Photo { get; set; }
        public string Gender { get; set; }
        public IFormFile FromFile { get; set; } 


        private IStudentService _studentService;
        private ISystemImageResizer _systemImageResizer;
        private IFileStoreUtility _fileStoreUtility;
        private ILifetimeScope _scope;
        public CreateStudentModel()
        {

        }
        public CreateStudentModel(IStudentService studentService, ISystemImageResizer systemImageResizer, 
            IFileStoreUtility fileStoreUtility)
        {
            _studentService = studentService;
            _systemImageResizer = systemImageResizer;
            _fileStoreUtility = fileStoreUtility; ;
        }

        public void Resolve(ILifetimeScope scope)
        {
            _scope = scope;
            _studentService = _scope.Resolve<IStudentService>();
            _systemImageResizer = _scope.Resolve<ISystemImageResizer>();
            _fileStoreUtility = _scope.Resolve<IFileStoreUtility>();
        }

    }
}
