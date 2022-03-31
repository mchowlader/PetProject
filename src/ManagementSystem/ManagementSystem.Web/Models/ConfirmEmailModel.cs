using Autofac;

namespace ManagementSystem.Web.Models
{
    public class ConfirmEmailModel
    {
        public string StatusMessage { get; set; }
        public bool IsSuccess { get; set; }

        private ILifetimeScope _scope;

        public ConfirmEmailModel()
        {

        }

        public void Resolve(ILifetimeScope scope)
        {
            _scope = scope;
        }
    }
}
