using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace TNexus.Web.Database
{
	/* 18. Pravimo klasu koja nasledjuje dve parametre iz defaultne klase za kreiranje korisnika.
	i dodajemo i nase parametre*/
	[Index(nameof(ApplicationUser.UserName), IsUnique = true)]
	public class ApplicationUser : IdentityUser
	{
		public string? FirstName { get; set; }

		public string? LastName { get; set; }
	}
}
