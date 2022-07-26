using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TNexus.Web.Database
{
    public class PhoneNumber
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity), Key()]
        public int PhoneNumberId { get; set; }

        [Required]
        [MaxLength(256)]
        public string? UserId { get; set; }

        [Required]
        [RegularExpression("^[0-9]{3}\\-[0-9]{3}\\-[0-9]{4}$", ErrorMessage = "Phone number not valid ( Valid: 111-222-3333)!")]
        [MaxLength(256)]
        public string? Number { get; set; }

        public ICollection<PhoneBook>? PhoneBooks { get; set; }

    }
}
