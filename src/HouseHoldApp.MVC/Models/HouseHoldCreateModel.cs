using System.ComponentModel.DataAnnotations;

namespace HouseHoldApp.MVC.Models
{
    public class HouseHoldCreateModel
    {
        [Required]
        public string Name { get; set; }
    }
}