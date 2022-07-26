using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TNexus.Web.Database
{
    public class Manufacturer : Base
    {
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity), Key]
        public int ManufacturerId { get; set; }

        [Required]
        [MaxLength(256)]
        public string? Name { get; set; }

        /*5. Moramo da stavimo ovaj ICollection da bismo nagovestili nas program prilikom kreniranja baze ka postoji veza ka drugoj tabeli.
         U ovom slucaju ta veza je jedan na vise. Jedan manufacture se nalazi vise puta u tabeli telefon.*/
        public ICollection<Telephone>? Telephones { get; set; }

    }
}
