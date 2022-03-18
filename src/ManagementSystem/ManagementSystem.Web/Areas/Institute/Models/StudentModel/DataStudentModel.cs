using Autofac;
using ManagementSystem.Academy.Services;
using ManagementSystem.Foundation.Utilities;
using System.Linq;
using System.Threading.Tasks;

namespace ManagementSystem.Web.Areas.Institute.Models.StudentModel
{
    public class DataStudentModel
    {
        private IStudentService _studentService;
        private ILifetimeScope _scope;
        public DataStudentModel()
        {

        }
        public DataStudentModel(IStudentService studentService)
        {
            _studentService = studentService;
        }

        public void Resolve(ILifetimeScope scope)
        {
            _scope = scope;
            _studentService = _scope.Resolve<IStudentService>();
        }
    }
}
