using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TNexus.Web.Database
{
    public class Base
    {
        [Required]
        public DateTime DataCreated { get; set; }

        [Required]
        public DateTime DataUpdated { get; set; }

        [Required]
        [MaxLength(256)]
        public string? UserCreated { get; set; }

        [Required]
        [MaxLength(256)]
        public string? UserUpdated { get; set; }


    }
}
