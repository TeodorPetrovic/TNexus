using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace TNexus.Web.Database
{
    /*19. Nakon napravljene prosirene klase ApplicationUser sada moramo nasem DbContextu da prosledimo da postoji vodjenje evidencije koji korisnici ovde postoje
     kao i njihove privilegije. Takodje posle ovoga moramo da napravimo novu migraciju koje ce modifikovati nasu bazu podataka.*/
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        // ctor and tab for generating contrustor
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Manufacturer>? Manufacturer { get; set; }
        public DbSet<Provider>? Provider { get; set; }
        public DbSet<Subscription>? Subscription { get; set; }
        public DbSet<PhoneNumber>? PhoneNumber { get; set; }
        public DbSet<Telephone>? Telephone { get; set; }
        public DbSet<PhoneBook>? PhoneBook { get; set; }

    }
}
