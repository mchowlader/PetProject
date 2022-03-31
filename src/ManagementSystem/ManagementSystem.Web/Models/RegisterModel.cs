using Autofac;
using Microsoft.AspNetCore.Authentication;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ManagementSystem.Web.Models
{
    public class RegisterModel
    {
        [Required]
        [Display(Name = "Institute Name")]
        public string Name { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "Admin Email")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
        public string ReturnUrl { get; set; }
        public IList<AuthenticationScheme> ExternalLogins { get; set; }
        private ILifetimeScope _scope;

        public RegisterModel()
        {

        }

        public void Resolve(ILifetimeScope scope)
        {
            _scope = scope;
        }
    }
}
