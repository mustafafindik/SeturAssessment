using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SeturAssessment.ContactService.Migrations
{
    public partial class ContactSeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Contacts",
                columns: new[] { "Id", "Firm", "FirstName", "LastName" },
                values: new object[] { new Guid("4319436c-5f58-4bf4-a089-f247f2a46780"), "Test Firma", "Kullanıcı 1", "Kullanıcı 1 LastName" });

            migrationBuilder.InsertData(
                table: "Locations",
                columns: new[] { "Id", "LocationName" },
                values: new object[] { 1, "İstanbul" });

            migrationBuilder.InsertData(
                table: "ContactLocation",
                columns: new[] { "ContactId", "LocationId" },
                values: new object[] { new Guid("4319436c-5f58-4bf4-a089-f247f2a46780"), 1 });

            migrationBuilder.InsertData(
                table: "Emails",
                columns: new[] { "Id", "ContactId", "MailAddress" },
                values: new object[] { 1, new Guid("4319436c-5f58-4bf4-a089-f247f2a46780"), "kullanıcı1@kullanıcı.com" });

            migrationBuilder.InsertData(
                table: "PhoneNumbers",
                columns: new[] { "Id", "ContactId", "PhoneNumber" },
                values: new object[] { 1, new Guid("4319436c-5f58-4bf4-a089-f247f2a46780"), "054300000000" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ContactLocation",
                keyColumns: new[] { "ContactId", "LocationId" },
                keyValues: new object[] { new Guid("4319436c-5f58-4bf4-a089-f247f2a46780"), 1 });

            migrationBuilder.DeleteData(
                table: "Emails",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "PhoneNumbers",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Contacts",
                keyColumn: "Id",
                keyValue: new Guid("4319436c-5f58-4bf4-a089-f247f2a46780"));

            migrationBuilder.DeleteData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
