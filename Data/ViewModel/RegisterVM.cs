using System.ComponentModel.DataAnnotations;

namespace OnlineVoting.Data.ViewModel
{
    public class RegisterVM
    {
        [Required(ErrorMessage = "First Name is Required")]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last Name is required")]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }


        [Required(ErrorMessage="Email Address is required")]
        [Display(Name="Email")]
        [DataType(DataType.EmailAddress)]
        public string EmailAddress { get; set; }


        [Required]
        [Display(Name = "Password")]
        [DataType(DataType.Password,ErrorMessage = "Not Valid Password")]
        public string Password { get; set; }

        [Required]
        [Display(Name = "Confirm Password")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage ="Password Mismatch")]
        public string ConfirmPassword { get; set; }
    }
}
