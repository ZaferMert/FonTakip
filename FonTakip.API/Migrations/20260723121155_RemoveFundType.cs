using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FonTakip.API.Migrations
{
    /// <inheritdoc />
    public partial class RemoveFundType : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Type",
                table: "Funds");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Type",
                table: "Funds",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Funds",
                keyColumn: "Id",
                keyValue: 101,
                column: "Type",
                value: "Menkul Kıymet Yatırım Fonları");

            migrationBuilder.UpdateData(
                table: "Funds",
                keyColumn: "Id",
                keyValue: 102,
                column: "Type",
                value: "Menkul Kıymet Yatırım Fonları");

            migrationBuilder.UpdateData(
                table: "Funds",
                keyColumn: "Id",
                keyValue: 103,
                column: "Type",
                value: "Menkul Kıymet Yatırım Fonları");

            migrationBuilder.UpdateData(
                table: "Funds",
                keyColumn: "Id",
                keyValue: 104,
                column: "Type",
                value: "Menkul Kıymet Yatırım Fonları");

            migrationBuilder.UpdateData(
                table: "Funds",
                keyColumn: "Id",
                keyValue: 105,
                column: "Type",
                value: "Menkul Kıymet Yatırım Fonları");

            migrationBuilder.UpdateData(
                table: "Funds",
                keyColumn: "Id",
                keyValue: 106,
                column: "Type",
                value: "Menkul Kıymet Yatırım Fonları");

            migrationBuilder.UpdateData(
                table: "Funds",
                keyColumn: "Id",
                keyValue: 107,
                column: "Type",
                value: "Menkul Kıymet Yatırım Fonları");

            migrationBuilder.UpdateData(
                table: "Funds",
                keyColumn: "Id",
                keyValue: 108,
                column: "Type",
                value: "Menkul Kıymet Yatırım Fonları");

            migrationBuilder.UpdateData(
                table: "Funds",
                keyColumn: "Id",
                keyValue: 109,
                column: "Type",
                value: "Menkul Kıymet Yatırım Fonları");

            migrationBuilder.UpdateData(
                table: "Funds",
                keyColumn: "Id",
                keyValue: 110,
                column: "Type",
                value: "Menkul Kıymet Yatırım Fonları");

            migrationBuilder.UpdateData(
                table: "Funds",
                keyColumn: "Id",
                keyValue: 111,
                column: "Type",
                value: "Menkul Kıymet Yatırım Fonları");

            migrationBuilder.UpdateData(
                table: "Funds",
                keyColumn: "Id",
                keyValue: 112,
                column: "Type",
                value: "Menkul Kıymet Yatırım Fonları");

            migrationBuilder.UpdateData(
                table: "Funds",
                keyColumn: "Id",
                keyValue: 113,
                column: "Type",
                value: "Menkul Kıymet Yatırım Fonları");

            migrationBuilder.UpdateData(
                table: "Funds",
                keyColumn: "Id",
                keyValue: 114,
                column: "Type",
                value: "Menkul Kıymet Yatırım Fonları");

            migrationBuilder.UpdateData(
                table: "Funds",
                keyColumn: "Id",
                keyValue: 115,
                column: "Type",
                value: "Menkul Kıymet Yatırım Fonları");
        }
    }
}
