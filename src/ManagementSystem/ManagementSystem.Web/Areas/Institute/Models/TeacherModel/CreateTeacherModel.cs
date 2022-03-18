using Autofac;
using ManagementSystem.Academy.Services;
using ManagementSystem.Academy.BusinessObjects;
using ManagementSystem.Foundation.Services;
using Microsoft.AspNetCore.Http;
using System;
using System.IO;
using System.Threading.Tasks;

namespace ManagementSystem.Web.Areas.Institute.Models.TeacherModel
{
    public class CreateTeacherModel
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public int MobileNo { get; set; }
        public string Photo { get; set; }
        public string Gender { get; set; }
        public IFormFile FromFile { get; set; } 


        private ITeacherService _teacherService;
        private ISystemImageResizer _systemImageResizer;
        private IFileStoreUtility _fileStoreUtility;
        private ILifetimeScope _scope;
        public CreateTeacherModel()
        {

        }
        public CreateTeacherModel(ITeacherService teacherService, ISystemImageResizer systemImageResizer, 
            IFileStoreUtility fileStoreUtility)
        {
            _teacherService = teacherService;
            _systemImageResizer = systemImageResizer;
            _fileStoreUtility = fileStoreUtility; ;
        }

        public void Resolve(ILifetimeScope scope)
        {
            _scope = scope;
            _teacherService = _scope.Resolve<ITeacherService>();
            _systemImageResizer = _scope.Resolve<ISystemImageResizer>();
            _fileStoreUtility = _scope.Resolve<IFileStoreUtility>();
        }

        public async Task CreateTeacherAsync()
        {
            if (FromFile != null)
            {
                var tempImage = new FileInfo(_fileStoreUtility.StoreFile(FromFile).filePath);
                var resizeImage = await _systemImageResizer.ProfileImageResizeAsync(tempImage);
                Photo = resizeImage.Name;
            }
            else
            {
                Photo = "DefaultImage.jpg";
            }

            var teacher = new Teacher()
            {
                Name = Name,
                Address = Address,
                MobileNo = MobileNo,
                Photo = Photo,
                Gender = Gender
                
            };


            await _teacherService.CreateTeacherAsync(teacher);
        }
    }
}
