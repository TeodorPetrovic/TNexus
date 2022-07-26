using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TNexus.Web.Database
{
    public class Subscription
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity), Key()]
        public int SubscriptionId { get; set; }

        [Required]
        [MaxLength(256)]
        public string? Name { get; set; }

        [Required]
        public int ProviderId { get; set; }

        [Required]
        [MaxLength(10)]
        public int Internet { get; set; }

        [Required]
        [MaxLength(10)]
        public int Sms { get; set; }

        [Required]
        [MaxLength(10)]
        public int Minutes { get; set; }

        [Required]
        [MaxLength(10)]
        public int DurationYears { get; set; }

        [Required]
        [RegularExpression("^[0-9]+\\.[0-9]{2}\\ RSD$", ErrorMessage = "Price not valid!")]
        [MaxLength(256)]
        public string? Price { get; set; }

        public Provider? Provider { get; set; }

        public ICollection<PhoneBook>? PhoneBooks { get; set; }

    }
}
