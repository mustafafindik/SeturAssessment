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
     


    }

}