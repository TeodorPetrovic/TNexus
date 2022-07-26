using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TNexus.Web.Database
{
    public class PhoneBook
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity), Key()]
        public int PhoneBookId { get; set; }

        [Required]
        public int PhoneNumberId { get; set; }

        [Required]
        public int TelephoneId { get; set; }

        [Required]
        public int SubscriptionId { get; set; }

        public PhoneNumber? PhoneNumber { get; set; }

        public Subscription? Subscription { get; set; }

        public Telephone? Telephone;

    }
}
