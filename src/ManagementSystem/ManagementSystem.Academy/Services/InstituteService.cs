using ManagementSystem.Academy.BusinessObjects;
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
    public class InstituteService : IInstituteService
    {
        private readonly IAcademyUnitOfWork _unitOfWork;
        private readonly IPathService _pathService;
        private UserManager<ApplicationUser> _userManager;
        private static IHttpContextAccessor _httpContextAccessor;

        public InstituteService(IAcademyUnitOfWork unitOfWork, IPathService pathService,
            UserManager<ApplicationUser> userManager, IHttpContextAccessor httpContextAccessor)
        {
            _unitOfWork = unitOfWork;
            _pathService = pathService;
            _userManager = userManager;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task CreateInstitutesAsync(Institutes institute)
        {
            if (institute == null)
                throw new InvalidParameterException("Institute name must be provided to create company!");

            await _unitOfWork.InstituteRepository.AddAsync(
                new Entities.Institutes()
                {
                    Name = institute.Name,
                    AdminUserId = institute.AdminUserId,
                    CreateDate = institute.CreateDate
                });

            await _unitOfWork.SaveAsync();
        }
    }
}
