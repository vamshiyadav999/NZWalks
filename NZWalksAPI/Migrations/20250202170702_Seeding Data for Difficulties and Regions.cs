using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace NZWalksAPI.Migrations
{
    /// <inheritdoc />
    public partial class SeedingDataforDifficultiesandRegions : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Difficulties",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("077d5b86-b89c-41c3-83d3-71f6cede5aa2"), "Easy" },
                    { new Guid("38366b78-5f37-4079-aa37-b7ce3face9f8"), "Medium" },
                    { new Guid("63912060-f0b2-4926-a971-c54bee89074e"), "Hard" }
                });

            migrationBuilder.InsertData(
                table: "Regions",
                columns: new[] { "Id", "Code", "Name", "RegionImageUrl" },
                values: new object[,]
                {
                    { new Guid("0cb89754-9bbf-49b9-a674-4de2b9d7ed16"), "HAM", "Hamilton", "hamilton-region-image.jpg" },
                    { new Guid("5f23a7a3-756f-4415-b81a-392ea1f74b88"), "DUN", "Dunedin", null },
                    { new Guid("74f9d399-c607-45bb-a3f2-f7e5f28c9a7d"), "CHC", "Christchurch", "christchurch-image.jpg" },
                    { new Guid("9e9c14f1-b4f1-44f9-ab98-bff2faa0bd2a"), "AKL", "Auckland", "179003-North-Island.jpg" },
                    { new Guid("d9d3c9d5-9ac5-4c47-9f8e-cd4c0b1fdb61"), "WEL", "Wellington", null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("077d5b86-b89c-41c3-83d3-71f6cede5aa2"));

            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("38366b78-5f37-4079-aa37-b7ce3face9f8"));

            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("63912060-f0b2-4926-a971-c54bee89074e"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("0cb89754-9bbf-49b9-a674-4de2b9d7ed16"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("5f23a7a3-756f-4415-b81a-392ea1f74b88"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("74f9d399-c607-45bb-a3f2-f7e5f28c9a7d"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("9e9c14f1-b4f1-44f9-ab98-bff2faa0bd2a"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("d9d3c9d5-9ac5-4c47-9f8e-cd4c0b1fdb61"));
        }
    }
}
