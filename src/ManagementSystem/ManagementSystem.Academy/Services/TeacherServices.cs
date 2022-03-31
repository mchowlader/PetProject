using ManagementSystem.Academy.BusinessObjects;
using ManagementSystem.Academy.Services;
using ManagementSystem.Academy.UnifOfWorks;
using ManagementSystem.Foundation.Exceptions;
using ManagementSystem.Foundation.Services;
using ManagementSystem.Membership.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
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
        private UserManager<ApplicationUser> _userManager;
        private static IHttpContextAccessor _httpContextAccessor;

        public TeacherService(IAcademyUnitOfWork unitOfWork, IPathService pathService, 
            UserManager<ApplicationUser> userManager, IHttpContextAccessor httpContextAccessor)
        {
            _unitOfWork = unitOfWork;
            _pathService = pathService;
            _userManager = userManager;
            _httpContextAccessor = httpContextAccessor;
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
                    Gender = teacher.Gender,
                });

            await _unitOfWork.SaveAsync();
        }

        public async Task DeleteTeacherAsync(Guid id)
        {
            await _unitOfWork.TeacherRepository.RemoveAsync(id);
            await _unitOfWork.SaveAsync();
        }

        public async Task<Teacher> GetTeacherByUserNameAsync()
        {
            var name = _httpContextAccessor.HttpContext.User.Identity.Name;
            var user = await _userManager.FindByNameAsync(name);

            if (user == null)
                throw new InvalidParameterException("User must be provided to get a Teacher.");

            var teacherEntity = (await _unitOfWork.TeacherRepository.GetAsync(x => 
                x.Id == user.Id, null)).FirstOrDefault();

            if (teacherEntity == null)
                return null;

            var teacher = new Teacher()
            {
                Id = teacherEntity.Id,
                Name = teacherEntity.Name,
                Address = teacherEntity.Address,
                Gender = teacherEntity.Gender,
                MobileNo =teacherEntity.MobileNo,
                Photo = teacherEntity.Photo
            };

            return teacher;
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

        public async Task<Teacher> LoadTeacherDataAsync(Guid id)
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
