using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SeturAssessment.ContactService.Migrations
{
    public partial class ContactLocationIdadded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ContactLocation",
                table: "ContactLocation");

            migrationBuilder.DeleteData(
                table: "ContactLocation",
                keyColumns: new[] { "ContactId", "LocationId" },
                keyValues: new object[] { new Guid("4319436c-5f58-4bf4-a089-f247f2a46780"), 1 });

            migrationBuilder.DeleteData(
                table: "Contacts",
                keyColumn: "Id",
                keyValue: new Guid("4319436c-5f58-4bf4-a089-f247f2a46780"));

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "ContactLocation",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ContactLocation",
                table: "ContactLocation",
                column: "Id");

            migrationBuilder.InsertData(
                table: "Contacts",
                columns: new[] { "Id", "Firm", "FirstName", "LastName" },
                values: new object[] { new Guid("703ab5e7-c689-4ff8-b7d5-aa60787626fd"), "Test Firma", "Kullanıcı 1", "Kullanıcı 1 LastName" });

            migrationBuilder.InsertData(
                table: "ContactLocation",
                columns: new[] { "Id", "ContactId", "LocationId" },
                values: new object[] { 1, new Guid("703ab5e7-c689-4ff8-b7d5-aa60787626fd"), 1 });

            migrationBuilder.UpdateData(
                table: "Emails",
                keyColumn: "Id",
                keyValue: 1,
                column: "ContactId",
                value: new Guid("703ab5e7-c689-4ff8-b7d5-aa60787626fd"));

            migrationBuilder.UpdateData(
                table: "PhoneNumbers",
                keyColumn: "Id",
                keyValue: 1,
                column: "ContactId",
                value: new Guid("703ab5e7-c689-4ff8-b7d5-aa60787626fd"));

            migrationBuilder.CreateIndex(
                name: "IX_ContactLocation_LocationId",
                table: "ContactLocation",
                column: "LocationId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ContactLocation",
                table: "ContactLocation");

            migrationBuilder.DropIndex(
                name: "IX_ContactLocation_LocationId",
                table: "ContactLocation");

            migrationBuilder.DeleteData(
                table: "ContactLocation",
                keyColumn: "Id",
                keyColumnType: "int",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Contacts",
                keyColumn: "Id",
                keyValue: new Guid("703ab5e7-c689-4ff8-b7d5-aa60787626fd"));

            migrationBuilder.DropColumn(
                name: "Id",
                table: "ContactLocation");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ContactLocation",
                table: "ContactLocation",
                columns: new[] { "LocationId", "ContactId" });

            migrationBuilder.InsertData(
                table: "Contacts",
                columns: new[] { "Id", "Firm", "FirstName", "LastName" },
                values: new object[] { new Guid("4319436c-5f58-4bf4-a089-f247f2a46780"), "Test Firma", "Kullanıcı 1", "Kullanıcı 1 LastName" });

            migrationBuilder.InsertData(
                table: "ContactLocation",
                columns: new[] { "ContactId", "LocationId" },
                values: new object[] { new Guid("4319436c-5f58-4bf4-a089-f247f2a46780"), 1 });

            migrationBuilder.UpdateData(
                table: "Emails",
                keyColumn: "Id",
                keyValue: 1,
                column: "ContactId",
                value: new Guid("4319436c-5f58-4bf4-a089-f247f2a46780"));

            migrationBuilder.UpdateData(
                table: "PhoneNumbers",
                keyColumn: "Id",
                keyValue: 1,
                column: "ContactId",
                value: new Guid("4319436c-5f58-4bf4-a089-f247f2a46780"));
        }
    }
}
