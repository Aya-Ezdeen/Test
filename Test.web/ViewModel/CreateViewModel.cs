using System.ComponentModel.DataAnnotations;

namespace Test.web.ViewModel
{
    public class CreateViewModel
    {

        [Required]
       
        [Display(Name = "User Name")]
        public string UserName { get; set; } 

        [Required]
        [EmailAddress]
        [Display(Name = "User Email")]
        public string Email { get; set; }
        [Required]
        [Phone]
        [Display(Name = "User Phone Number")]
        public string Phone { get; set; }

        [DataType(DataType.Password)]
        [Required]
        [Display(Name = "User Password ")]
        public string Password { get; set; }

    }
}
