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
        public DbSet<ContactDetail> ContactDetails { get; set; }
    }
    

}