using System.ComponentModel.DataAnnotations;

namespace HouseHoldApp.MVC.Models
{
    public class RegisterUserModel
    {
        [Required]
        public string EmailAddress { get; set; }
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        [Required]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm Password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
    }
}