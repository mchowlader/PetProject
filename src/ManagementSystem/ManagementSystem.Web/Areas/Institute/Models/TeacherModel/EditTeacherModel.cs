using Autofac;
using ManagementSystem.Academy.BusinessObjects;
using ManagementSystem.Academy.Services;
using ManagementSystem.Foundation.Services;
using Microsoft.AspNetCore.Http;
using System;
using System.IO;
using System.Threading.Tasks;

namespace ManagementSystem.Web.Areas.Institute.Models.TeacherModel
{
    public class EditTeacherModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public int MobileNo { get; set; }
        public string Photo { get; set; }
        public string Gender { get; set; }
        public IFormFile FormFile { get; set; }

        private ITeacherService _teacherService;
        private IPathService _pathService;
        private IFileStoreUtility _fileStoreUtility;
        private ISystemImageResizer _systemImageResizer;
        private ILifetimeScope _scope;
        public EditTeacherModel()
        {

        }
        public EditTeacherModel(ITeacherService teacherService, IPathService pathService, ISystemImageResizer systemImageResizer,
           IFileStoreUtility fileStoreUtility )
        {
            _pathService = pathService;
            _teacherService = teacherService;
            _fileStoreUtility = fileStoreUtility;
            _systemImageResizer = systemImageResizer;
        }

        public void Resolve(ILifetimeScope scope)
        {
            _scope = scope;
            _teacherService = _scope.Resolve<ITeacherService>();
            _fileStoreUtility = _scope.Resolve<IFileStoreUtility>();
            _systemImageResizer = _scope.Resolve<ISystemImageResizer>();
        }

        public async Task LoadTeacherDataAsync(int id)
        {
            var data = await _teacherService.LoadTeacherDataAsync(id);

            if (data != null)
            {
                if (data.Photo == null)
                {
                    var defaultProfileImage = _pathService.DefaultProfileImage;
                    Photo = _pathService.AttachPathWithDefaultProfileImage(defaultProfileImage);
                }
                else
                {
                    Photo = _pathService.AttachPathWithFile(data.Photo);
                }

                Name = data.Name;
                Address = data.Address;
                MobileNo = data.MobileNo;
                Gender = data.Gender;
            }
        }


        internal async Task UpadteTeacherAsync()
        {
            if (FormFile != null)
            {
                var temporaryImage = new FileInfo(_fileStoreUtility.StoreFile(FormFile).filePath);
                var resizeImage = await _systemImageResizer.ProfileImageResizeAsync(temporaryImage);
                Photo = resizeImage.Name;
            }
            else
            {
                Photo = Photo.Remove(0, 7);
            }

            var teacher = new Teacher()
            {
                Id = Id,
                Name = Name,
                Address = Address,
                MobileNo = MobileNo,
                Gender = Gender,
                Photo = Photo
            };

            await _teacherService.UpdateUserAsync(teacher);
        }
    }
}
