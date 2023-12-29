using System.ComponentModel.DataAnnotations;

namespace eTeskra.Data.ViewModels
{
    public class LoginVM
    {
        [Display(Name = "Email Adress")]
        [Required(ErrorMessage = "Email Adress is Required !")]
        public string EmailAdress { get; set; }

        
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
