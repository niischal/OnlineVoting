using System.ComponentModel.DataAnnotations;

namespace OnlineVoting.Data.ViewModel
{
    public class LogInVM
    {
        [Required(ErrorMessage="Email Address is required")]
        [Display(Name="Email")]
        [DataType(DataType.EmailAddress)]
        public string EmailAddress { get; set; }


        [Required]
        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
