using ManagementSystem.Academy.UnifOfWorks;
using ManagementSystem.Foundation.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagementSystem.Academy.Services
{
    public class StudentService : IStudentService
    {
        private readonly IAcademyUnitOfWork _unitOfWork;
        private readonly IPathService _pathService;

        public StudentService(IAcademyUnitOfWork unitOfWork, IPathService pathService)
        {
            _unitOfWork = unitOfWork;
            _pathService = pathService;
        }
    }
}
