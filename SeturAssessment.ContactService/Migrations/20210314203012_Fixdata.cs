using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SeturAssessment.ContactService.Migrations
{
    public partial class Fixdata : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Contacts",
                keyColumn: "Id",
                keyValue: new Guid("24b92062-3421-45d9-8c18-99cb0e9a87b4"));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Contacts",
                columns: new[] { "Id", "Firm", "FirstName", "LastName" },
                values: new object[] { new Guid("24b92062-3421-45d9-8c18-99cb0e9a87b4"), "Test Firma", "Kullanıcı 1", "Kullanıcı 1 LastName" });
        }
    }
}
