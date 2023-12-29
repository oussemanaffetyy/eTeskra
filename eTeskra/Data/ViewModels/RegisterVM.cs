using System.ComponentModel.DataAnnotations;

namespace eTeskra.Data.ViewModels
{
    public class RegisterVM
    {
        [Display(Name = "Full Name")]
        [Required(ErrorMessage = "Full Name is Required !")]
        public string FullName { get; set; }


        [Display(Name = "Email Adress")]
        [Required(ErrorMessage = "Email Adress is Required !")]
        public string EmailAdress { get; set; }

        
        [Required(ErrorMessage = "confirm Password is Required !")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Confirm Password")]
        [Required]
        [DataType(DataType.Password)]
        [Compare("Password",ErrorMessage ="Password do not match")]
        public string confirmPassword { get; set; }
    }
}
