using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ManagementSystem.Web.Data.Migrations
{
    public partial class dataseeds : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("7008368c-e9f9-4ac7-86ff-0714d32ec0de"), "9a68cbef-5c02-4c56-83a5-be3e3a7b68a4", "SuperAdmin", "SUPERADMIN" },
                    { new Guid("d0e0bd13-5f71-4427-b1fc-d90a5a888ad4"), "749c4cf4-bb91-4cd1-ba2d-75563c9e0c9e", "InstituteAdmin", "INSTITUTEADMIN" },
                    { new Guid("855cdf3a-0a64-4d04-b045-eeda6bc75416"), "f0f1c16a-fa9b-43c6-a2ad-d00bf1445cd6", "Student", "STUDENT" },
                    { new Guid("e231b99e-437f-4f4c-8207-8163d50ddf4f"), "51c0d467-8b48-4420-b1df-d04d3240e319", "Teacher", "TEACHER" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("7008368c-e9f9-4ac7-86ff-0714d32ec0de"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("855cdf3a-0a64-4d04-b045-eeda6bc75416"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("d0e0bd13-5f71-4427-b1fc-d90a5a888ad4"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("e231b99e-437f-4f4c-8207-8163d50ddf4f"));
        }
    }
}
