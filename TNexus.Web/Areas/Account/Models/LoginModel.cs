using System.ComponentModel.DataAnnotations;

namespace TNexus.Web.Areas.Account.Models
{
	public class LoginModel
	{
        [Required]
        [StringLength(25, MinimumLength = 5, ErrorMessage = "Must be between 5 and 30 characters long.")]
        [Display(Name = "User Name", Prompt = "User Name")]
        public string? UserName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password", Prompt = "Password")]
        public string? Password { get; set; }

        [Display(Name = "Remember me?")]
        public bool RememberMe { get; set; }
    }
}
