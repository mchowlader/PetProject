using ManagementSystem.Academy.BusinessObjects;
using System.Threading.Tasks;

namespace ManagementSystem.Academy.Services
{
    public interface IInstituteService
    {
        Task CreateInstitutesAsync(Institutes institute);
    }
}