using Autofac;
using DevSkill.Core.Utilities;
using ManagementSystem.Academy.BusinessObjects;
using ManagementSystem.Academy.Services;
using System;
using System.Threading.Tasks;

namespace ManagementSystem.Web.Areas.Institute.Models.InstituteModel
{
    public class CreateInstituteModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid AdminUserId { get; set; }
        public DateTime CreateDate { get; set; }

        private ILifetimeScope _scope;
        private IServerTime _serverTime;
        private IInstituteService _instituteService;

        public CreateInstituteModel(ILifetimeScope scope, IServerTime serverTime, 
            IInstituteService instituteService)
        {
            _scope = scope;
            _serverTime = serverTime;
            _instituteService = instituteService;
        }

        public void Resolve(ILifetimeScope scope)
        {
            _scope = scope;
            _serverTime = _scope.Resolve<IServerTime>();
            _instituteService = _scope.Resolve<IInstituteService>();

        }

        public async Task CreateInstituteAsync()
        {
            var institute = new Institutes()
            {
                Name = Name,
                AdminUserId = AdminUserId,
                CreateDate = _serverTime.GetCurrentServerTime()
            };

            await _instituteService.CreateInstitutesAsync(institute);
        }
    }
}
