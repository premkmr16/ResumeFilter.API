using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ResumeFilter.API.Migrations
{
    /// <inheritdoc />
    public partial class updated : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Candidates_Vendors_VendorId",
                table: "Candidates");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UploadedDate",
                table: "Candidates",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 9, 29, 9, 47, 27, 373, DateTimeKind.Utc).AddTicks(8609),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 9, 29, 6, 42, 7, 507, DateTimeKind.Utc).AddTicks(8909));

            migrationBuilder.CreateTable(
                name: "TechStacks",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "newsequentialid()"),
                    Name = table.Column<string>(type: "varchar(60)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TechStacks", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "TechStacks",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("4afd9bbf-ed1f-44cc-9bfc-0af4f4cd3294"), "React, java, Azure" },
                    { new Guid("76e1a134-81d5-4a0d-9b82-7efb826e04ca"), "React, dotnet, Azure" },
                    { new Guid("cbc23e6a-d503-44f9-83d1-86a1ceadf862"), "Angular, dotnet, Azure" }
                });

            migrationBuilder.InsertData(
                table: "Vendors",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("1607973a-a0ea-422c-ad5d-e7b0b301f33c"), "prem" },
                    { new Guid("1ad1f980-5198-442d-9eab-7b4cf548a9da"), "Abi" },
                    { new Guid("472cbfc2-35a9-4285-9f1f-b2189d73cde6"), "Hema" },
                    { new Guid("7a297872-665a-4ff8-863b-c158fc45cb32"), "Vaishnavi" },
                    { new Guid("a92cffec-1524-417c-a671-1dce8b3ac538"), "Sudha" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Candidates_Vendors_VendorId",
                table: "Candidates",
                column: "VendorId",
                principalTable: "Vendors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Candidates_Vendors_VendorId",
                table: "Candidates");

            migrationBuilder.DropTable(
                name: "TechStacks");

            migrationBuilder.DeleteData(
                table: "Vendors",
                keyColumn: "Id",
                keyValue: new Guid("1607973a-a0ea-422c-ad5d-e7b0b301f33c"));

            migrationBuilder.DeleteData(
                table: "Vendors",
                keyColumn: "Id",
                keyValue: new Guid("1ad1f980-5198-442d-9eab-7b4cf548a9da"));

            migrationBuilder.DeleteData(
                table: "Vendors",
                keyColumn: "Id",
                keyValue: new Guid("472cbfc2-35a9-4285-9f1f-b2189d73cde6"));

            migrationBuilder.DeleteData(
                table: "Vendors",
                keyColumn: "Id",
                keyValue: new Guid("7a297872-665a-4ff8-863b-c158fc45cb32"));

            migrationBuilder.DeleteData(
                table: "Vendors",
                keyColumn: "Id",
                keyValue: new Guid("a92cffec-1524-417c-a671-1dce8b3ac538"));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UploadedDate",
                table: "Candidates",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 9, 29, 6, 42, 7, 507, DateTimeKind.Utc).AddTicks(8909),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 9, 29, 9, 47, 27, 373, DateTimeKind.Utc).AddTicks(8609));

            migrationBuilder.AddForeignKey(
                name: "FK_Candidates_Vendors_VendorId",
                table: "Candidates",
                column: "VendorId",
                principalTable: "Vendors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
