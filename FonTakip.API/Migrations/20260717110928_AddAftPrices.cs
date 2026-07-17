using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FonTakip.API.Migrations
{
    /// <inheritdoc />
    public partial class AddAftPrices : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "FundPrices",
                columns: new[] { "Id", "ChangeRate", "Date", "FundId", "Price" },
                values: new object[,]
                {
                    { 6, 0m, new DateTime(2026, 6, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 26.10m },
                    { 7, 2.6m, new DateTime(2026, 6, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 26.80m },
                    { 8, 2.6m, new DateTime(2026, 6, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 27.50m },
                    { 9, 1.8m, new DateTime(2026, 7, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 28.00m },
                    { 10, 1.0m, new DateTime(2026, 7, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 28.30m }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "FundPrices",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "FundPrices",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "FundPrices",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "FundPrices",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "FundPrices",
                keyColumn: "Id",
                keyValue: 10);
        }
    }
}
