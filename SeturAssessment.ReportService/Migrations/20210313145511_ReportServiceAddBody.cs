using Microsoft.EntityFrameworkCore.Migrations;

namespace SeturAssessment.ReportService.Migrations
{
    public partial class ReportServiceAddBody : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ReportBody",
                table: "Reports",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ReportBody",
                table: "Reports");
        }
    }
}
