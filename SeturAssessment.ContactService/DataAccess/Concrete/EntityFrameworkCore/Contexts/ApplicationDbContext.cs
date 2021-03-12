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
            modelBuilder.Entity<ContactLocation>().HasKey(p => new { p.LocationId,p.ContactId});
            modelBuilder.Entity<ContactLocation>().HasOne(p => p.Location).WithMany(c => c.ContactLocations).HasForeignKey(p => p.LocationId);
            modelBuilder.Entity<ContactLocation>().HasOne(p => p.Contact).WithMany(c => c.ContactLocations).HasForeignKey(p => p.ContactId);
        }
    }
    

}