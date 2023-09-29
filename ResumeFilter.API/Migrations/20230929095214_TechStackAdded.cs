using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ResumeFilter.API.Migrations
{
    /// <inheritdoc />
    public partial class TechStackAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "TechStacks",
                keyColumn: "Id",
                keyValue: new Guid("4afd9bbf-ed1f-44cc-9bfc-0af4f4cd3294"));

            migrationBuilder.DeleteData(
                table: "TechStacks",
                keyColumn: "Id",
                keyValue: new Guid("76e1a134-81d5-4a0d-9b82-7efb826e04ca"));

            migrationBuilder.DeleteData(
                table: "TechStacks",
                keyColumn: "Id",
                keyValue: new Guid("cbc23e6a-d503-44f9-83d1-86a1ceadf862"));

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

            migrationBuilder.DropColumn(
                name: "TechStack",
                table: "Candidates");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UploadedDate",
                table: "Candidates",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 9, 29, 9, 52, 14, 126, DateTimeKind.Utc).AddTicks(8048),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 9, 29, 9, 47, 27, 373, DateTimeKind.Utc).AddTicks(8609));

            migrationBuilder.AddColumn<Guid>(
                name: "TechStackId",
                table: "Candidates",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.InsertData(
                table: "TechStacks",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("508d71e2-a90e-4f28-bfaa-f08994b8f01e"), "React, java, Azure" },
                    { new Guid("53fd680f-cc17-4280-add4-eb1ba39abdf9"), "React, dotnet, Azure" },
                    { new Guid("9aeeada7-5325-4abd-8b9c-3d1393fc27a1"), "Angular, dotnet, Azure" }
                });

            migrationBuilder.InsertData(
                table: "Vendors",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("3646c493-12d1-40dd-8f8c-c0469ecce665"), "Vaishnavi" },
                    { new Guid("55479f37-65cd-48e0-a397-498b90622249"), "Abi" },
                    { new Guid("8e4910ce-f358-411e-80de-3f38d8c9ef23"), "Hema" },
                    { new Guid("bf02241e-db05-4fbf-a04a-9dbb864559b6"), "Sudha" },
                    { new Guid("f7cb0aac-3d13-4139-9c57-19b6bffa6d1c"), "prem" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Candidates_TechStackId",
                table: "Candidates",
                column: "TechStackId");

            migrationBuilder.AddForeignKey(
                name: "FK_Candidates_TechStacks_TechStackId",
                table: "Candidates",
                column: "TechStackId",
                principalTable: "TechStacks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Candidates_TechStacks_TechStackId",
                table: "Candidates");

            migrationBuilder.DropIndex(
                name: "IX_Candidates_TechStackId",
                table: "Candidates");

            migrationBuilder.DeleteData(
                table: "TechStacks",
                keyColumn: "Id",
                keyValue: new Guid("508d71e2-a90e-4f28-bfaa-f08994b8f01e"));

            migrationBuilder.DeleteData(
                table: "TechStacks",
                keyColumn: "Id",
                keyValue: new Guid("53fd680f-cc17-4280-add4-eb1ba39abdf9"));

            migrationBuilder.DeleteData(
                table: "TechStacks",
                keyColumn: "Id",
                keyValue: new Guid("9aeeada7-5325-4abd-8b9c-3d1393fc27a1"));

            migrationBuilder.DeleteData(
                table: "Vendors",
                keyColumn: "Id",
                keyValue: new Guid("3646c493-12d1-40dd-8f8c-c0469ecce665"));

            migrationBuilder.DeleteData(
                table: "Vendors",
                keyColumn: "Id",
                keyValue: new Guid("55479f37-65cd-48e0-a397-498b90622249"));

            migrationBuilder.DeleteData(
                table: "Vendors",
                keyColumn: "Id",
                keyValue: new Guid("8e4910ce-f358-411e-80de-3f38d8c9ef23"));

            migrationBuilder.DeleteData(
                table: "Vendors",
                keyColumn: "Id",
                keyValue: new Guid("bf02241e-db05-4fbf-a04a-9dbb864559b6"));

            migrationBuilder.DeleteData(
                table: "Vendors",
                keyColumn: "Id",
                keyValue: new Guid("f7cb0aac-3d13-4139-9c57-19b6bffa6d1c"));

            migrationBuilder.DropColumn(
                name: "TechStackId",
                table: "Candidates");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UploadedDate",
                table: "Candidates",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 9, 29, 9, 47, 27, 373, DateTimeKind.Utc).AddTicks(8609),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 9, 29, 9, 52, 14, 126, DateTimeKind.Utc).AddTicks(8048));

            migrationBuilder.AddColumn<string>(
                name: "TechStack",
                table: "Candidates",
                type: "varchar(254)",
                nullable: true);

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
        }
    }
}
