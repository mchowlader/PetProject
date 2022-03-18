using Autofac;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace ManagementSystem.Web.Models
{
    public class LoginModel
    {
        public string ReturnUrl { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Remember me?")]
        public bool RememberMe { get; set; }

        [TempData]
        public string ErrorMessage { get; set; }

        private ILifetimeScope _scope;
        public LoginModel()
        {

        }

        public void Resolve(ILifetimeScope scope)
        {
            _scope = scope;
        }
    }
}
