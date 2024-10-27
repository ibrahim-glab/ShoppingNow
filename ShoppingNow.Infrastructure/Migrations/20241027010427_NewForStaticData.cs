using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ShoppingNow.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class NewForStaticData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "81f416be-9cb9-4c02-9f5e-cd8cd6b21ff0", null, "Admin", null },
                    { "cd5152fd-86fa-4249-83e0-618a420a32b6", null, "Customer", null }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Createdat", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "c7d15af3-1f1a-4959-981b-bfe08ccd38b9", 0, "57a71f60-5edc-4817-8ac9-eb3e90bf15d6", new DateOnly(2024, 10, 27), "Admin", false, "Ahmed", "Saied", false, null, null, null, "Admin123", null, false, "c7eb83f8-6056-4156-a7e9-82e69848d87c", false, null });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "81f416be-9cb9-4c02-9f5e-cd8cd6b21ff0");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cd5152fd-86fa-4249-83e0-618a420a32b6");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "c7d15af3-1f1a-4959-981b-bfe08ccd38b9");
        }
    }
}
