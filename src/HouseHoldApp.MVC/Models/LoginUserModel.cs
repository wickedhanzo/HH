using System.ComponentModel.DataAnnotations;

namespace HouseHoldApp.MVC.Models
{
    public class LoginUserModel
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
    }
}