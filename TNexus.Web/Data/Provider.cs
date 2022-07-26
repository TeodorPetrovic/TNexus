using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TNexus.Web.Database
{
    public class Provider
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity), Key()]
        public int ProviderId { get; set; }

        [Required]
        [MaxLength(256)]
        public string? Name { get; set; }

        [EmailAddress]
        [MaxLength(256)]
        public string? Email { get; set; }

        [RegularExpression("^[0-9]{3}\\-[0-9]{3}\\-[0-9]{4}$", ErrorMessage = "Phone number not valid ( Valid: 111-222-3333)!")]
        [MaxLength(256)]
        public string? PhoneNumber { get; set; }


        public ICollection<Subscription>? Subscriptions { get; set; }
    }
}
