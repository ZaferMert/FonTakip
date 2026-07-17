using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FonTakip.API.Migrations
{
    /// <inheritdoc />
    public partial class AddSeedPrices : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "FundPrices",
                columns: new[] { "Id", "ChangeRate", "Date", "FundId", "Price" },
                values: new object[,]
                {
                    { 1, 0m, new DateTime(2026, 6, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 13.00m },
                    { 2, 1.5m, new DateTime(2026, 6, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 13.20m },
                    { 3, 2.2m, new DateTime(2026, 6, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 13.50m },
                    { 4, 1.1m, new DateTime(2026, 7, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 13.65m },
                    { 5, 6.3m, new DateTime(2026, 7, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 14.52m }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "FundPrices",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "FundPrices",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "FundPrices",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "FundPrices",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "FundPrices",
                keyColumn: "Id",
                keyValue: 5);
        }
    }
}
