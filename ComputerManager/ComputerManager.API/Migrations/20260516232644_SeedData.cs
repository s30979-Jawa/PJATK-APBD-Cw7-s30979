using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ComputerManager.API.Migrations
{
    /// <inheritdoc />
    public partial class SeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "ComponentManufacturers",
                columns: new[] { "Id", "Abbreviation", "FoundationDate", "FullName" },
                values: new object[,]
                {
                    { 1, "AMD", new DateOnly(1969, 5, 1), "Advanced Micro Devices" },
                    { 2, "NV", new DateOnly(1993, 4, 5), "NVIDIA Corporation" },
                    { 3, "COR", new DateOnly(1994, 1, 1), "Corsair Gaming Inc." }
                });

            migrationBuilder.InsertData(
                table: "ComponentTypes",
                columns: new[] { "Id", "Abbreviation", "Name" },
                values: new object[,]
                {
                    { 1, "CPU", "Processor" },
                    { 2, "GPU", "Graphics Card" },
                    { 3, "RAM", "Memory" }
                });

            migrationBuilder.InsertData(
                table: "Pcs",
                columns: new[] { "Id", "CreatedAt", "Name", "Stock", "Warranty", "Weight" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 5, 5, 9, 0, 0, 0, DateTimeKind.Unspecified), "Komputer1", 1, 5, 50f },
                    { 2, new DateTime(1999, 2, 12, 7, 3, 12, 0, DateTimeKind.Unspecified), "Stary Komputer", 12, 1, 700f },
                    { 3, new DateTime(2014, 8, 12, 17, 32, 45, 0, DateTimeKind.Unspecified), "Nowy Komputer", 5, 20, 900f }
                });

            migrationBuilder.InsertData(
                table: "Components",
                columns: new[] { "Code", "ComponentManufacturerId", "ComponentTypeId", "Description", "Name" },
                values: new object[,]
                {
                    { "CPU9999999", 1, 1, "To jest CPU", "Super Duper Processor" },
                    { "GPU0000001", 2, 2, "To jest GPU", "GjePeUu" },
                    { "RAM1234567", 3, 3, "To jest RAM", "Osiem Bajtow" }
                });

            migrationBuilder.InsertData(
                table: "PcComponents",
                columns: new[] { "ComponentCode", "PcId", "Amount" },
                values: new object[,]
                {
                    { "GPU0000001", 1, 10 },
                    { "CPU9999999", 2, 20 },
                    { "RAM1234567", 3, 30 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "PcComponents",
                keyColumns: new[] { "ComponentCode", "PcId" },
                keyValues: new object[] { "GPU0000001", 1 });

            migrationBuilder.DeleteData(
                table: "PcComponents",
                keyColumns: new[] { "ComponentCode", "PcId" },
                keyValues: new object[] { "CPU9999999", 2 });

            migrationBuilder.DeleteData(
                table: "PcComponents",
                keyColumns: new[] { "ComponentCode", "PcId" },
                keyValues: new object[] { "RAM1234567", 3 });

            migrationBuilder.DeleteData(
                table: "Components",
                keyColumn: "Code",
                keyValue: "CPU9999999");

            migrationBuilder.DeleteData(
                table: "Components",
                keyColumn: "Code",
                keyValue: "GPU0000001");

            migrationBuilder.DeleteData(
                table: "Components",
                keyColumn: "Code",
                keyValue: "RAM1234567");

            migrationBuilder.DeleteData(
                table: "Pcs",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Pcs",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Pcs",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "ComponentManufacturers",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ComponentManufacturers",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "ComponentManufacturers",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "ComponentTypes",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ComponentTypes",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "ComponentTypes",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
