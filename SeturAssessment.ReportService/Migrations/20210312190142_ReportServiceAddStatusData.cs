using Microsoft.EntityFrameworkCore.Migrations;

namespace SeturAssessment.ReportService.Migrations
{
    public partial class ReportServiceAddStatusData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "ReportStatuses",
                columns: new[] { "Id", "StatusName" },
                values: new object[] { 1, "Hazırlanıyor" });

            migrationBuilder.InsertData(
                table: "ReportStatuses",
                columns: new[] { "Id", "StatusName" },
                values: new object[] { 2, "Tamamlandı" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ReportStatuses",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ReportStatuses",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
