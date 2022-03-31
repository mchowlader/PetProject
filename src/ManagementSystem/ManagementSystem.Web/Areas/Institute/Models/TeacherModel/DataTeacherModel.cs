using Autofac;
using ManagementSystem.Academy.Services;
using ManagementSystem.Foundation.Utilities;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace ManagementSystem.Web.Areas.Institute.Models.TeacherModel
{
    public class DataTeacherModel
    {
        private ITeacherService _teacherService;
        private ILifetimeScope _scope;
        public DataTeacherModel()
        {

        }
        public DataTeacherModel(ITeacherService teacherService)
        {
            _teacherService = teacherService;
        }

        public void Resolve(ILifetimeScope scope)
        {
            _scope = scope;
            _teacherService = _scope.Resolve<ITeacherService>();
        }

        public async Task<object> GetTeacherDataAsyns(DataTablesAjaxRequestModel dataTableModel)
        {
            var data = await _teacherService.GetTeacherDataAsyns(
                dataTableModel.PageIndex,
                dataTableModel.PageSize,
                dataTableModel.SearchText,
                dataTableModel.GetSortText(new string[] { "Photo", "Name", "Address", "Gender", "MobileNo"}));

            return new
            {
                recordsTotal = data.total,
                recordsFiltered = data.totalDispaly,
                data = (from record in data.records
                        select new string[]
                        {
                                record.Photo,
                                record.Name,
                                record.Address,
                                record.Gender,
                                record.MobileNo.ToString(),
                                record.Id.ToString()
                        }
                       ).ToArray()
            };
        }

        public async Task DeleteTeacherAsync(Guid id)
        {
            await _teacherService.DeleteTeacherAsync(id);
        }
    }
}
