using Microsoft.EntityFrameworkCore;
using SeturAssessment.ReportService.Entities.Concrete;

namespace SeturAssessment.ReportService.DataAccess.Concrete.EntityFrameworkCore.Contexts
{
    public class ApplicationDbContext : DbContext
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<ReportStatus> ReportStatuses { get; set; }
        public DbSet<Reports> Reports { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ReportStatus>().HasData(
                new ReportStatus {Id = 1, StatusName = "Hazırlanıyor"},
                new ReportStatus {Id = 2, StatusName = "Tamamlandı"});
        }
    }

}