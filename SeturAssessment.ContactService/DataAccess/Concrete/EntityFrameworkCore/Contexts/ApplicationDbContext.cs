using Microsoft.EntityFrameworkCore;
using SeturAssessment.ContactService.Entities.Concrete;

namespace SeturAssessment.ContactService.DataAccess.Concrete.EntityFrameworkCore.Contexts
{
    public class ApplicationDbContext : DbContext
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Email> Emails { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<Phone> PhoneNumbers { get; set; }
        public DbSet<ContactLocation> ContactLocation { get; set; }


    }

}