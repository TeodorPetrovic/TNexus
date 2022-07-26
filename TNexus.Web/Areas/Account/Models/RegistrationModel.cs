using System.ComponentModel.DataAnnotations;

namespace TNexus.Web.Areas.Account.Models
{
    public class RegistrationModel
    {
        [Required]
        [StringLength(25, MinimumLength = 5, ErrorMessage = "Must be between 5 and 30 characters long.")]
        [Display(Name = "UserName", Prompt = "User Name")]
        public string? UserName { get; set; }

        [Required]
        [StringLength(25, MinimumLength = 5, ErrorMessage = "Must be between 5 and 30 characters long.")]
        [Display(Name = "FirstName", Prompt = "First Name")]
        public string? FirstName { get; set; }

        [Required]
        [StringLength(25, MinimumLength = 5, ErrorMessage = "Must be between 5 and 30 characters long.")]
        [Display(Name = "LastName", Prompt = "Last Name")]
        public string? LastName { get; set; }

        [Required]
        [EmailAddress(ErrorMessage = "Email like: smith@gmail.com")]
        [Display(Name = "Email", Prompt = "Your Email")]
        public string? Email { get; set; }

        [Required]
        [RegularExpression("^\\+[0-9]{1,3}\\ [0-9]{9,10}$", ErrorMessage = "Phone number not valid! Must be like: +XXX 1112223334")]
        [Display(Name = "Telephone", Prompt = "+XXX 1112223334")]
        public string? Telephone { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password", Prompt = "Password")]
        //[RegularExpression("^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$%^&*-]).{12,}$", ErrorMessage = "Password mush be: min 8 characters, one uppercase, one lowercase, one numeber and one symbol.")]
        public string? Password { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Confirm password", Prompt = "Confirm Password")]
        [Compare("Password", ErrorMessage = "The passwords do not match.")]
        public string? ConfirmPassword { get; set; }

        [Required(ErrorMessage = "Need to check!")]
        public bool AcceptPrivacyPolicy { get; set; }

    }
}
