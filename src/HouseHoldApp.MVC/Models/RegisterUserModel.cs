using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web;

namespace HouseHoldApp.MVC.Models
{
    public class RegisterUserModel
    {
        private string _password;
        [Required]
        public string UserName { get; set; }
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        public string Password
        {
            get
            {
                return _password ?? string.Empty;
            }
            set
            {
                _password = (value == null || value.Trim().Length == 0) ? null : value.Trim();
            }
        }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm Password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        public IEnumerable<GenderModel> GenderModels { get; set; }
        public int SelectedGender { set; get; }
    }
}