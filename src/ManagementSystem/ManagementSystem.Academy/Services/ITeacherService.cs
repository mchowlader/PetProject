using ManagementSystem.Academy.BusinessObjects;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ManagementSystem.Academy.Services
{
    public interface ITeacherService
    {
        Task CreateTeacherAsync(Teacher teacher);
        Task<(IList<Teacher> records, int total, int totalDispaly)> GetTeacherDataAsyns(int pageIndex, int pageSize, 
            string searchText, string sortText);
        Task DeleteTeacherAsync(Guid id);
        Task<Teacher> LoadTeacherDataAsync(Guid id);
        Task UpdateUserAsync(Teacher teacher);
        Task<Teacher> GetTeacherByUserNameAsync();
    }
}