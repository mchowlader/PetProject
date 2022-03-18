using ManagementSystem.Academy.BusinessObjects;
using ManagementSystem.Academy.Services;
using ManagementSystem.Academy.UnifOfWorks;
using ManagementSystem.Foundation.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagementSystem.Academy.Services
{
    public class TeacherService : ITeacherService
    {
        private readonly IAcademyUnitOfWork _unitOfWork;
        private readonly IPathService _pathService;

        public TeacherService(IAcademyUnitOfWork unitOfWork, IPathService pathService)
        {
            _unitOfWork = unitOfWork;
            _pathService = pathService;
        }

        public async Task CreateTeacherAsync(Teacher teacher)
        {
            await _unitOfWork.TeacherRepository.AddAsync(
                new Academy.Entities.Teacher()
                {
                    Name = teacher.Name,
                    Address = teacher.Address,
                    MobileNo =teacher.MobileNo,
                    Photo =teacher.Photo,
                    Gender = teacher.Gender
                });

            await _unitOfWork.SaveAsync();
        }

        public async Task DeleteTeacherAsync(int id)
        {
            await _unitOfWork.TeacherRepository.RemoveAsync(id);
            await _unitOfWork.SaveAsync();
        }

        public async Task<(IList<Teacher> records, int total, int totalDispaly)> GetTeacherDataAsyns(int pageIndex, int pageSize, 
            string searchText, string sortText)
        {
            var teacherList = await _unitOfWork.TeacherRepository.GetDynamicAsync(
               string.IsNullOrWhiteSpace(searchText) ? null : x => x.Name.Contains(searchText),
               sortText, null, pageIndex, pageSize, false);

            var result = (from user in teacherList.data
                          select new Teacher()
                          {
                              Name = user.Name,
                              Address = user.Address,
                              Gender = user.Gender,
                              MobileNo = user.MobileNo,
                              Photo = user.Photo,
                              Id = user.Id
                          }).ToList();

            for (var i = 0; i < result.Count; i++)
            {
                if (result[i].Photo == null)
                {
                    var defaultProfileImage = _pathService.DefaultProfileImage;
                    result[i].Photo = _pathService.AttachPathWithDefaultProfileImage(defaultProfileImage);
                }
                else
                {
                    result[i].Photo = _pathService.AttachPathWithFile(result[i].Photo);
                }
            }

            return (result, teacherList.total, teacherList.totalDisplay);
        }

        public async Task<Teacher> LoadTeacherDataAsync(int id)
        {
            var teacher = await _unitOfWork.TeacherRepository.GetByIdAsync(id);
            return new Teacher()
            {
                Id = teacher.Id,
                Name = teacher.Name,
                Address = teacher.Address,
                MobileNo = teacher.MobileNo,
                Gender = teacher.Gender,
                Photo = teacher.Photo,
            };
        }

        public async Task UpdateUserAsync(Teacher teacher)
        {
            var userEntity = await _unitOfWork.TeacherRepository.GetByIdAsync(teacher.Id);

            if (userEntity != null)
            {
                userEntity.Id = teacher.Id;
                userEntity.Name = teacher.Name;
                userEntity.Address = teacher.Address;
                userEntity.Gender = teacher.Gender;
                userEntity.MobileNo = teacher.MobileNo;
                userEntity.Photo = teacher.Photo;

                await _unitOfWork.SaveAsync();
            }
        }
    }
}
