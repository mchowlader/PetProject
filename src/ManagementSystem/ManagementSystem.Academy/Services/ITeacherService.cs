using ManagementSystem.Academy.BusinessObjects;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ManagementSystem.Academy.Services
{
    public interface ITeacherService
    {
        Task CreateTeacherAsync(Teacher teacher);
        Task<(IList<Teacher> records, int total, int totalDispaly)> GetTeacherDataAsyns(int pageIndex, int pageSize, 
            string searchText, string sortText);
        Task DeleteTeacherAsync(int id);
        Task<Teacher> LoadTeacherDataAsync(int id);
        Task UpdateUserAsync(Teacher teacher);
    }
}