using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TNexus.Web.Database
{
    public class Telephone : Base
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity), Key]
        public int TelephoneId { get; set; }

        [Required]
        [MaxLength(256)]
        public string? Name { get; set; }

        [Required]
        public int ManufacturerId { get; set; }

        [Required]
        [RegularExpression("^(Android|IOS)$", ErrorMessage = "Only Android or IOS!!!!!")]
        [MaxLength(256)]
        public string? Software { get; set; }

        [Required]
        [MaxLength(10)]
        public int Ram { get; set; }

        [Required]
        [MaxLength(10)]
        public int InternalMemory { get; set; }

        [Required]
        [MaxLength(10)]
        public int Battery { get; set; }

        [Required]
        [MaxLength(10)]
        public int Display { get; set; }

        [Required]
        [RegularExpression("^(1280 × 720|1920 × 1080|3840 × 2160)$", ErrorMessage = "Wrong resolution!")]
        [MaxLength(256)]
        public string? Resolution { get; set; }

        [Required]
        [RegularExpression("^[A-Z]{3}\\-[0-9]{3}\\-[0-9]{3}\\-[0-9]{3}\\-[A-Z]{3}$", ErrorMessage = "Wrong serial number!")]
        [MaxLength(256)]
        public string? SerialNumber { get; set; }

        /*6. U klasi za Bazu Manufacturer.cs smo definisali da postoji veza ka telefonima koja je jedan naprema vise. Ovde takodje
         moramo definisati da postoji veza vise naprema jedan (fakticki suprotno od drugog entiteta, jer tak je uvek)*/
        public Manufacturer? Manufacturer { get; set; }

        public PhoneBook? PhoneBook { get; set; }

    }
}
