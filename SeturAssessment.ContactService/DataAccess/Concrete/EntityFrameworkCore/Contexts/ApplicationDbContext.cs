using System;
using Microsoft.EntityFrameworkCore;
using SeturAssessment.ContactService.Entities.Concrete;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ContactLocation>().HasKey(p => p.Id);
            modelBuilder.Entity<ContactLocation>().HasOne(p => p.Location).WithMany(c => c.ContactLocations).HasForeignKey(p => p.LocationId);
            modelBuilder.Entity<ContactLocation>().HasOne(p => p.Contact).WithMany(c => c.ContactLocations).HasForeignKey(p => p.ContactId);

            var firstContactId = Guid.NewGuid();

            modelBuilder.Entity<Contact>().HasData(new Contact { Id = firstContactId, FirstName = "Kullanıcı 1" , LastName = "Kullanıcı 1 LastName" , Firm = "Test Firma" });
            modelBuilder.Entity<Email>().HasData(new Email { ContactId = firstContactId , Id = 1, MailAddress = "kullanıcı1@kullanıcı.com"});
            modelBuilder.Entity<Phone>().HasData(new Phone { ContactId = firstContactId, Id = 1, PhoneNumber = "054300000000" });
            modelBuilder.Entity<Location>().HasData(new Location { Id = 1, LocationName = "İstanbul" });
            modelBuilder.Entity<ContactLocation>().HasData(new ContactLocation { Id = 1, ContactId = firstContactId, LocationId = 1 });

           

        }
    }
    

}