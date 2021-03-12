using Microsoft.EntityFrameworkCore.Migrations;

namespace SeturAssessment.ReportService.Migrations
{
    public partial class ReportServiceReportStatusFix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reports_ReportStatuses_ReportStatusId",
                table: "Reports");

            migrationBuilder.DropColumn(
                name: "StatusId",
                table: "Reports");

            migrationBuilder.AlterColumn<int>(
                name: "ReportStatusId",
                table: "Reports",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Reports_ReportStatuses_ReportStatusId",
                table: "Reports",
                column: "ReportStatusId",
                principalTable: "ReportStatuses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reports_ReportStatuses_ReportStatusId",
                table: "Reports");

            migrationBuilder.AlterColumn<int>(
                name: "ReportStatusId",
                table: "Reports",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "StatusId",
                table: "Reports",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Reports_ReportStatuses_ReportStatusId",
                table: "Reports",
                column: "ReportStatusId",
                principalTable: "ReportStatuses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
