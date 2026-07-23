using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FonTakip.API.Migrations
{
    /// <inheritdoc />
    public partial class RestoreFundDetails : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DeleteData(
                table: "Funds",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Funds",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Funds",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Funds",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.AlterColumn<decimal>(
                name: "Shares",
                table: "PortfolioItems",
                type: "decimal(18,3)",
                precision: 18,
                scale: 3,
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "AverageCost",
                table: "PortfolioItems",
                type: "decimal(18,6)",
                precision: 18,
                scale: 6,
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AddColumn<string>(
                name: "AssetDistribution",
                table: "Funds",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "InvestorCount",
                table: "Funds",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<decimal>(
                name: "ManagementFee",
                table: "Funds",
                type: "decimal(18,2)",
                precision: 18,
                scale: 2,
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<int>(
                name: "Risk",
                table: "Funds",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<decimal>(
                name: "TotalValue",
                table: "Funds",
                type: "decimal(18,2)",
                precision: 18,
                scale: 2,
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AlterColumn<decimal>(
                name: "Price",
                table: "FundPrices",
                type: "decimal(18,6)",
                precision: 18,
                scale: 6,
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.InsertData(
                table: "Funds",
                columns: new[] { "Id", "AssetDistribution", "Category", "Code", "InvestorCount", "IsActive", "ManagementFee", "Name", "Risk", "TotalValue" },
                values: new object[,]
                {
                    { 101, "%85 Katılım Hisse, %15 Kira Sertifikası", "Katılım Fonu", "KFA", 18450, true, 2.10m, "Emlak Katılım Birinci Hisse Senedi Katılım Fonu", 6, 850400000.00m },
                    { 102, "%70 Kira Sertifikası, %30 Katılma Hesabı", "Katılım Fonu", "KMT", 12300, true, 1.50m, "Emlak Katılım Katılım Fonu", 3, 420100000.00m },
                    { 103, "%90 Katılma Hesabı, %10 Altın", "Para Piyasası", "KPE", 25100, true, 0.90m, "Emlak Katılım Para Piyasası Katılım Fonu", 1, 1250000000.00m },
                    { 104, "%80 Kira Sertifikası, %20 Hisse", "Katılım Fonu", "ZPC", 9800, true, 1.75m, "Ziraat Portföy Katılım Fonu", 4, 310500000.00m },
                    { 105, "%95 Altın / Kıymetli Maden, %5 Nakit", "Kıymetli Maden", "ZPF", 31200, true, 1.80m, "Ziraat Portföy Altın Katılım Fonu", 5, 980300000.00m },
                    { 106, "%65 Kira Sertifikası, %35 Sukuk", "Katılım Fonu", "TFX", 14200, true, 1.60m, "Türkiye Finans Katılım Fonu", 3, 510000000.00m },
                    { 107, "%75 Hisse Senedi, %25 Kira Sertifikası", "Katılım Fonu", "MPS", 8700, true, 1.95m, "Albaraka Portföy Katılım Fonu", 5, 290800000.00m },
                    { 108, "%60 Kira Sertifikası, %40 Katılma Hesabı", "Katılım Fonu", "KDV", 11500, true, 1.70m, "Kuveyt Türk Portföy Katılım Fonu", 4, 480200000.00m },
                    { 109, "%70 Hisse, %30 Sukuk", "Katılım Fonu", "AAK", 6400, true, 1.85m, "Ata Portföy Katılım Fonu", 4, 195000000.00m },
                    { 110, "%75 Kira Sertifikası, %25 Katılma Hesabı", "Katılım Fonu", "VKK", 15600, true, 1.45m, "Vakıf Katılım Birinci Katılım Fonu", 3, 620000000.00m },
                    { 111, "%92 BIST Hisse, %8 VIOP Teminat", "Hisse Senedi", "MAC", 42100, true, 2.20m, "Marmara Capital Portföy Hisse Senedi Fonu", 6, 1850000000.00m },
                    { 112, "%95 Yabancı Teknoloji Hisse, %5 Dövüz", "Teknoloji", "AFT", 89000, true, 2.90m, "Ak Portföy Amerika Yabancı Hisse Senedi Fonu", 7, 3450000000.00m },
                    { 113, "%98 Altın Sertifikası / Ons, %2 Nakit", "Kıymetli Maden", "YAF", 54000, true, 1.75m, "Yapı Kredi Portföy Altın Fonu", 5, 2100000000.00m },
                    { 114, "%90 Hisse Senedi, %10 Nakit", "Hisse Senedi", "NNF", 38000, true, 2.50m, "Hedef Portföy Birinci Hisse Senedi Fonu", 6, 1420000000.00m },
                    { 115, "%94 Yan Tahta Hisse, %6 Mevduat", "Hisse Senedi", "TI3", 27500, true, 2.30m, "İş Portföy BIST 100 Dışı Şirketler Fonu", 6, 990000000.00m }
                });

            migrationBuilder.InsertData(
                table: "FundPrices",
                columns: new[] { "Id", "ChangeRate", "Date", "FundId", "Price" },
                values: new object[,]
                {
                    { 2000, 0m, new DateTime(2026, 6, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), 101, 33.185714m },
                    { 2001, -5.8m, new DateTime(2026, 6, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), 101, 33.327231m },
                    { 2002, -5.4m, new DateTime(2026, 6, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 101, 33.468748m },
                    { 2003, -5m, new DateTime(2026, 6, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), 101, 33.610265m },
                    { 2004, -4.6m, new DateTime(2026, 6, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), 101, 33.751782m },
                    { 2005, -4.2m, new DateTime(2026, 6, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 101, 33.893299m },
                    { 2006, -3.8m, new DateTime(2026, 6, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), 101, 34.034815m },
                    { 2007, -3.4m, new DateTime(2026, 6, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 101, 34.176332m },
                    { 2008, -3m, new DateTime(2026, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 101, 34.317849m },
                    { 2009, -2.6m, new DateTime(2026, 7, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 101, 34.459366m },
                    { 2010, -2.2m, new DateTime(2026, 7, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 101, 34.600883m },
                    { 2011, -1.8m, new DateTime(2026, 7, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 101, 34.742400m },
                    { 2012, -1.4m, new DateTime(2026, 7, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 101, 34.883917m },
                    { 2013, -1m, new DateTime(2026, 7, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 101, 35.025434m },
                    { 2014, -0.6m, new DateTime(2026, 7, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 101, 35.166951m },
                    { 2015, -0.2m, new DateTime(2026, 7, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 101, 35.308468m },
                    { 2016, 0.2m, new DateTime(2026, 7, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 101, 35.449984m },
                    { 2017, 0.6m, new DateTime(2026, 7, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 101, 35.591501m },
                    { 2018, 1m, new DateTime(2026, 7, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 101, 35.733018m },
                    { 2019, 1.4m, new DateTime(2026, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 101, 35.874535m },
                    { 2020, 1.8m, new DateTime(2026, 7, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 101, 36.016052m },
                    { 2021, 2.2m, new DateTime(2026, 7, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 101, 36.157569m },
                    { 2022, 2.6m, new DateTime(2026, 7, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 101, 36.299086m },
                    { 2023, 3m, new DateTime(2026, 7, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 101, 36.440603m },
                    { 2024, 3.4m, new DateTime(2026, 7, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 101, 36.582120m },
                    { 2025, 3.8m, new DateTime(2026, 7, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 101, 36.723637m },
                    { 2026, 4.2m, new DateTime(2026, 7, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), 101, 36.865153m },
                    { 2027, 4.6m, new DateTime(2026, 7, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 101, 37.006670m },
                    { 2028, 5m, new DateTime(2026, 7, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), 101, 37.148187m },
                    { 2029, 5.4m, new DateTime(2026, 7, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 101, 37.289704m },
                    { 2030, 5.8m, new DateTime(2026, 7, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), 101, 37.431221m },
                    { 2031, 0m, new DateTime(2026, 6, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), 102, 25.097449m },
                    { 2032, -5.6m, new DateTime(2026, 6, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), 102, 25.204247m },
                    { 2033, -5.2m, new DateTime(2026, 6, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 102, 25.311044m },
                    { 2034, -4.8m, new DateTime(2026, 6, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), 102, 25.417842m },
                    { 2035, -4.4m, new DateTime(2026, 6, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), 102, 25.524640m },
                    { 2036, -4m, new DateTime(2026, 6, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 102, 25.631437m },
                    { 2037, -3.6m, new DateTime(2026, 6, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), 102, 25.738235m },
                    { 2038, -3.2m, new DateTime(2026, 6, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 102, 25.845033m },
                    { 2039, -2.8m, new DateTime(2026, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 102, 25.951830m },
                    { 2040, -2.4m, new DateTime(2026, 7, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 102, 26.058628m },
                    { 2041, -2m, new DateTime(2026, 7, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 102, 26.165426m },
                    { 2042, -1.6m, new DateTime(2026, 7, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 102, 26.272223m },
                    { 2043, -1.2m, new DateTime(2026, 7, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 102, 26.379021m },
                    { 2044, -0.80m, new DateTime(2026, 7, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 102, 26.485819m },
                    { 2045, -0.4m, new DateTime(2026, 7, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 102, 26.592616m },
                    { 2046, 0m, new DateTime(2026, 7, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 102, 26.699414m },
                    { 2047, 0.4m, new DateTime(2026, 7, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 102, 26.806212m },
                    { 2048, 0.80m, new DateTime(2026, 7, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 102, 26.913009m },
                    { 2049, 1.2m, new DateTime(2026, 7, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 102, 27.019807m },
                    { 2050, 1.6m, new DateTime(2026, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 102, 27.126605m },
                    { 2051, 2m, new DateTime(2026, 7, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 102, 27.233402m },
                    { 2052, 2.4m, new DateTime(2026, 7, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 102, 27.340200m },
                    { 2053, 2.8m, new DateTime(2026, 7, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 102, 27.446998m },
                    { 2054, 3.2m, new DateTime(2026, 7, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 102, 27.553795m },
                    { 2055, 3.6m, new DateTime(2026, 7, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 102, 27.660593m },
                    { 2056, 4m, new DateTime(2026, 7, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 102, 27.767391m },
                    { 2057, 4.4m, new DateTime(2026, 7, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), 102, 27.874188m },
                    { 2058, 4.8m, new DateTime(2026, 7, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 102, 27.980986m },
                    { 2059, 5.2m, new DateTime(2026, 7, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), 102, 28.087784m },
                    { 2060, 5.6m, new DateTime(2026, 7, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 102, 28.194581m },
                    { 2061, 6m, new DateTime(2026, 7, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), 102, 28.301379m },
                    { 2062, 0m, new DateTime(2026, 6, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), 103, 13.725338m },
                    { 2063, -5.4m, new DateTime(2026, 6, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), 103, 13.783619m },
                    { 2064, -5m, new DateTime(2026, 6, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 103, 13.841901m },
                    { 2065, -4.6m, new DateTime(2026, 6, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), 103, 13.900183m },
                    { 2066, -4.2m, new DateTime(2026, 6, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), 103, 13.958464m },
                    { 2067, -3.8m, new DateTime(2026, 6, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 103, 14.016746m },
                    { 2068, -3.4m, new DateTime(2026, 6, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), 103, 14.075028m },
                    { 2069, -3m, new DateTime(2026, 6, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 103, 14.133309m },
                    { 2070, -2.6m, new DateTime(2026, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 103, 14.191591m },
                    { 2071, -2.2m, new DateTime(2026, 7, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 103, 14.249873m },
                    { 2072, -1.8m, new DateTime(2026, 7, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 103, 14.308154m },
                    { 2073, -1.4m, new DateTime(2026, 7, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 103, 14.366436m },
                    { 2074, -1m, new DateTime(2026, 7, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 103, 14.424718m },
                    { 2075, -0.6m, new DateTime(2026, 7, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 103, 14.482999m },
                    { 2076, -0.2m, new DateTime(2026, 7, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 103, 14.541281m },
                    { 2077, 0.2m, new DateTime(2026, 7, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 103, 14.599563m },
                    { 2078, 0.6m, new DateTime(2026, 7, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 103, 14.657845m },
                    { 2079, 1m, new DateTime(2026, 7, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 103, 14.716126m },
                    { 2080, 1.4m, new DateTime(2026, 7, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 103, 14.774408m },
                    { 2081, 1.8m, new DateTime(2026, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 103, 14.832690m },
                    { 2082, 2.2m, new DateTime(2026, 7, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 103, 14.890971m },
                    { 2083, 2.6m, new DateTime(2026, 7, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 103, 14.949253m },
                    { 2084, 3m, new DateTime(2026, 7, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 103, 15.007535m },
                    { 2085, 3.4m, new DateTime(2026, 7, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 103, 15.065816m },
                    { 2086, 3.8m, new DateTime(2026, 7, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 103, 15.124098m },
                    { 2087, 4.2m, new DateTime(2026, 7, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 103, 15.182380m },
                    { 2088, 4.6m, new DateTime(2026, 7, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), 103, 15.240661m },
                    { 2089, 5m, new DateTime(2026, 7, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 103, 15.298943m },
                    { 2090, 5.4m, new DateTime(2026, 7, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), 103, 15.357225m },
                    { 2091, 5.8m, new DateTime(2026, 7, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 103, 15.415506m },
                    { 2092, 6.2m, new DateTime(2026, 7, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), 103, 15.473788m },
                    { 2093, 0m, new DateTime(2026, 6, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), 104, 26.095196m },
                    { 2094, -5.2m, new DateTime(2026, 6, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), 104, 26.205769m },
                    { 2095, -4.8m, new DateTime(2026, 6, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 104, 26.316342m },
                    { 2096, -4.4m, new DateTime(2026, 6, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), 104, 26.426914m },
                    { 2097, -4m, new DateTime(2026, 6, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), 104, 26.537487m },
                    { 2098, -3.6m, new DateTime(2026, 6, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 104, 26.648060m },
                    { 2099, -3.2m, new DateTime(2026, 6, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), 104, 26.758633m },
                    { 2100, -2.8m, new DateTime(2026, 6, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 104, 26.869206m },
                    { 2101, -2.4m, new DateTime(2026, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 104, 26.979779m },
                    { 2102, -2m, new DateTime(2026, 7, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 104, 27.090352m },
                    { 2103, -1.6m, new DateTime(2026, 7, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 104, 27.200925m },
                    { 2104, -1.2m, new DateTime(2026, 7, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 104, 27.311497m },
                    { 2105, -0.80m, new DateTime(2026, 7, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 104, 27.422070m },
                    { 2106, -0.4m, new DateTime(2026, 7, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 104, 27.532643m },
                    { 2107, 0m, new DateTime(2026, 7, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 104, 27.643216m },
                    { 2108, 0.4m, new DateTime(2026, 7, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 104, 27.753789m },
                    { 2109, 0.80m, new DateTime(2026, 7, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 104, 27.864362m },
                    { 2110, 1.2m, new DateTime(2026, 7, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 104, 27.974935m },
                    { 2111, 1.6m, new DateTime(2026, 7, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 104, 28.085507m },
                    { 2112, 2m, new DateTime(2026, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 104, 28.196080m },
                    { 2113, 2.4m, new DateTime(2026, 7, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 104, 28.306653m },
                    { 2114, 2.8m, new DateTime(2026, 7, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 104, 28.417226m },
                    { 2115, 3.2m, new DateTime(2026, 7, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 104, 28.527799m },
                    { 2116, 3.6m, new DateTime(2026, 7, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 104, 28.638372m },
                    { 2117, 4m, new DateTime(2026, 7, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 104, 28.748945m },
                    { 2118, 4.4m, new DateTime(2026, 7, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 104, 28.859518m },
                    { 2119, 4.8m, new DateTime(2026, 7, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), 104, 28.970090m },
                    { 2120, 5.2m, new DateTime(2026, 7, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 104, 29.080663m },
                    { 2121, 5.6m, new DateTime(2026, 7, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), 104, 29.191236m },
                    { 2122, 6m, new DateTime(2026, 7, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 104, 29.301809m },
                    { 2123, 6.40m, new DateTime(2026, 7, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), 104, 29.412382m },
                    { 2124, 0m, new DateTime(2026, 6, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), 105, 28.446703m },
                    { 2125, -6m, new DateTime(2026, 6, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), 105, 28.568270m },
                    { 2126, -5.6m, new DateTime(2026, 6, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 105, 28.689837m },
                    { 2127, -5.2m, new DateTime(2026, 6, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), 105, 28.811405m },
                    { 2128, -4.8m, new DateTime(2026, 6, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), 105, 28.932972m },
                    { 2129, -4.4m, new DateTime(2026, 6, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 105, 29.054539m },
                    { 2130, -4m, new DateTime(2026, 6, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), 105, 29.176106m },
                    { 2131, -3.6m, new DateTime(2026, 6, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 105, 29.297673m },
                    { 2132, -3.2m, new DateTime(2026, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 105, 29.419240m },
                    { 2133, -2.8m, new DateTime(2026, 7, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 105, 29.540807m },
                    { 2134, -2.4m, new DateTime(2026, 7, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 105, 29.662374m },
                    { 2135, -2m, new DateTime(2026, 7, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 105, 29.783941m },
                    { 2136, -1.6m, new DateTime(2026, 7, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 105, 29.905509m },
                    { 2137, -1.2m, new DateTime(2026, 7, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 105, 30.027076m },
                    { 2138, -0.80m, new DateTime(2026, 7, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 105, 30.148643m },
                    { 2139, -0.4m, new DateTime(2026, 7, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 105, 30.270210m },
                    { 2140, 0m, new DateTime(2026, 7, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 105, 30.391777m },
                    { 2141, 0.4m, new DateTime(2026, 7, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 105, 30.513344m },
                    { 2142, 0.80m, new DateTime(2026, 7, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 105, 30.634911m },
                    { 2143, 1.2m, new DateTime(2026, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 105, 30.756478m },
                    { 2144, 1.6m, new DateTime(2026, 7, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 105, 30.878045m },
                    { 2145, 2m, new DateTime(2026, 7, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 105, 30.999613m },
                    { 2146, 2.4m, new DateTime(2026, 7, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 105, 31.121180m },
                    { 2147, 2.8m, new DateTime(2026, 7, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 105, 31.242747m },
                    { 2148, 3.2m, new DateTime(2026, 7, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 105, 31.364314m },
                    { 2149, 3.6m, new DateTime(2026, 7, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 105, 31.485881m },
                    { 2150, 4m, new DateTime(2026, 7, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), 105, 31.607448m },
                    { 2151, 4.4m, new DateTime(2026, 7, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 105, 31.729015m },
                    { 2152, 4.8m, new DateTime(2026, 7, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), 105, 31.850582m },
                    { 2153, 5.2m, new DateTime(2026, 7, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 105, 31.972149m },
                    { 2154, 5.6m, new DateTime(2026, 7, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), 105, 32.093717m },
                    { 2155, 0m, new DateTime(2026, 6, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), 106, 30.585204m },
                    { 2156, -5.8m, new DateTime(2026, 6, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), 106, 30.715631m },
                    { 2157, -5.4m, new DateTime(2026, 6, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 106, 30.846058m },
                    { 2158, -5m, new DateTime(2026, 6, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), 106, 30.976486m },
                    { 2159, -4.6m, new DateTime(2026, 6, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), 106, 31.106913m },
                    { 2160, -4.2m, new DateTime(2026, 6, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 106, 31.237340m },
                    { 2161, -3.8m, new DateTime(2026, 6, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), 106, 31.367768m },
                    { 2162, -3.4m, new DateTime(2026, 6, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 106, 31.498195m },
                    { 2163, -3m, new DateTime(2026, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 106, 31.628622m },
                    { 2164, -2.6m, new DateTime(2026, 7, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 106, 31.759049m },
                    { 2165, -2.2m, new DateTime(2026, 7, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 106, 31.889477m },
                    { 2166, -1.8m, new DateTime(2026, 7, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 106, 32.019904m },
                    { 2167, -1.4m, new DateTime(2026, 7, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 106, 32.150331m },
                    { 2168, -1m, new DateTime(2026, 7, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 106, 32.280759m },
                    { 2169, -0.6m, new DateTime(2026, 7, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 106, 32.411186m },
                    { 2170, -0.2m, new DateTime(2026, 7, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 106, 32.541613m },
                    { 2171, 0.2m, new DateTime(2026, 7, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 106, 32.672041m },
                    { 2172, 0.6m, new DateTime(2026, 7, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 106, 32.802468m },
                    { 2173, 1m, new DateTime(2026, 7, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 106, 32.932895m },
                    { 2174, 1.4m, new DateTime(2026, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 106, 33.063323m },
                    { 2175, 1.8m, new DateTime(2026, 7, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 106, 33.193750m },
                    { 2176, 2.2m, new DateTime(2026, 7, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 106, 33.324177m },
                    { 2177, 2.6m, new DateTime(2026, 7, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 106, 33.454605m },
                    { 2178, 3m, new DateTime(2026, 7, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 106, 33.585032m },
                    { 2179, 3.4m, new DateTime(2026, 7, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 106, 33.715459m },
                    { 2180, 3.8m, new DateTime(2026, 7, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 106, 33.845886m },
                    { 2181, 4.2m, new DateTime(2026, 7, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), 106, 33.976314m },
                    { 2182, 4.6m, new DateTime(2026, 7, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 106, 34.106741m },
                    { 2183, 5m, new DateTime(2026, 7, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), 106, 34.237168m },
                    { 2184, 5.4m, new DateTime(2026, 7, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 106, 34.367596m },
                    { 2185, 5.8m, new DateTime(2026, 7, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), 106, 34.498023m },
                    { 2186, 0m, new DateTime(2026, 6, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), 107, 28.568270m },
                    { 2187, -5.6m, new DateTime(2026, 6, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), 107, 28.689837m },
                    { 2188, -5.2m, new DateTime(2026, 6, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 107, 28.811405m },
                    { 2189, -4.8m, new DateTime(2026, 6, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), 107, 28.932972m },
                    { 2190, -4.4m, new DateTime(2026, 6, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), 107, 29.054539m },
                    { 2191, -4m, new DateTime(2026, 6, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 107, 29.176106m },
                    { 2192, -3.6m, new DateTime(2026, 6, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), 107, 29.297673m },
                    { 2193, -3.2m, new DateTime(2026, 6, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 107, 29.419240m },
                    { 2194, -2.8m, new DateTime(2026, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 107, 29.540807m },
                    { 2195, -2.4m, new DateTime(2026, 7, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 107, 29.662374m },
                    { 2196, -2m, new DateTime(2026, 7, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 107, 29.783941m },
                    { 2197, -1.6m, new DateTime(2026, 7, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 107, 29.905509m },
                    { 2198, -1.2m, new DateTime(2026, 7, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 107, 30.027076m },
                    { 2199, -0.80m, new DateTime(2026, 7, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 107, 30.148643m },
                    { 2200, -0.4m, new DateTime(2026, 7, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 107, 30.270210m },
                    { 2201, 0m, new DateTime(2026, 7, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 107, 30.391777m },
                    { 2202, 0.4m, new DateTime(2026, 7, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 107, 30.513344m },
                    { 2203, 0.80m, new DateTime(2026, 7, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 107, 30.634911m },
                    { 2204, 1.2m, new DateTime(2026, 7, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 107, 30.756478m },
                    { 2205, 1.6m, new DateTime(2026, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 107, 30.878045m },
                    { 2206, 2m, new DateTime(2026, 7, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 107, 30.999613m },
                    { 2207, 2.4m, new DateTime(2026, 7, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 107, 31.121180m },
                    { 2208, 2.8m, new DateTime(2026, 7, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 107, 31.242747m },
                    { 2209, 3.2m, new DateTime(2026, 7, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 107, 31.364314m },
                    { 2210, 3.6m, new DateTime(2026, 7, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 107, 31.485881m },
                    { 2211, 4m, new DateTime(2026, 7, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 107, 31.607448m },
                    { 2212, 4.4m, new DateTime(2026, 7, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), 107, 31.729015m },
                    { 2213, 4.8m, new DateTime(2026, 7, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 107, 31.850582m },
                    { 2214, 5.2m, new DateTime(2026, 7, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), 107, 31.972149m },
                    { 2215, 5.6m, new DateTime(2026, 7, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 107, 32.093717m },
                    { 2216, 6m, new DateTime(2026, 7, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), 107, 32.215284m },
                    { 2217, 0m, new DateTime(2026, 6, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), 108, 18.382175m },
                    { 2218, -5.4m, new DateTime(2026, 6, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), 108, 18.460231m },
                    { 2219, -5m, new DateTime(2026, 6, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 108, 18.538287m },
                    { 2220, -4.6m, new DateTime(2026, 6, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), 108, 18.616343m },
                    { 2221, -4.2m, new DateTime(2026, 6, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), 108, 18.694399m },
                    { 2222, -3.8m, new DateTime(2026, 6, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 108, 18.772455m },
                    { 2223, -3.4m, new DateTime(2026, 6, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), 108, 18.850510m },
                    { 2224, -3m, new DateTime(2026, 6, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 108, 18.928566m },
                    { 2225, -2.6m, new DateTime(2026, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 108, 19.006622m },
                    { 2226, -2.2m, new DateTime(2026, 7, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 108, 19.084678m },
                    { 2227, -1.8m, new DateTime(2026, 7, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 108, 19.162734m },
                    { 2228, -1.4m, new DateTime(2026, 7, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 108, 19.240790m },
                    { 2229, -1m, new DateTime(2026, 7, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 108, 19.318846m },
                    { 2230, -0.6m, new DateTime(2026, 7, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 108, 19.396902m },
                    { 2231, -0.2m, new DateTime(2026, 7, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 108, 19.474958m },
                    { 2232, 0.2m, new DateTime(2026, 7, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 108, 19.553014m },
                    { 2233, 0.6m, new DateTime(2026, 7, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 108, 19.631070m },
                    { 2234, 1m, new DateTime(2026, 7, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 108, 19.709126m },
                    { 2235, 1.4m, new DateTime(2026, 7, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 108, 19.787182m },
                    { 2236, 1.8m, new DateTime(2026, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 108, 19.865238m },
                    { 2237, 2.2m, new DateTime(2026, 7, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 108, 19.943294m },
                    { 2238, 2.6m, new DateTime(2026, 7, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 108, 20.021350m },
                    { 2239, 3m, new DateTime(2026, 7, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 108, 20.099406m },
                    { 2240, 3.4m, new DateTime(2026, 7, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 108, 20.177462m },
                    { 2241, 3.8m, new DateTime(2026, 7, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 108, 20.255517m },
                    { 2242, 4.2m, new DateTime(2026, 7, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 108, 20.333573m },
                    { 2243, 4.6m, new DateTime(2026, 7, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), 108, 20.411629m },
                    { 2244, 5m, new DateTime(2026, 7, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 108, 20.489685m },
                    { 2245, 5.4m, new DateTime(2026, 7, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), 108, 20.567741m },
                    { 2246, 5.8m, new DateTime(2026, 7, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 108, 20.645797m },
                    { 2247, 6.2m, new DateTime(2026, 7, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), 108, 20.723853m },
                    { 2248, 0m, new DateTime(2026, 6, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), 109, 28.899026m },
                    { 2249, -5.2m, new DateTime(2026, 6, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), 109, 29.021480m },
                    { 2250, -4.8m, new DateTime(2026, 6, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 109, 29.143933m },
                    { 2251, -4.4m, new DateTime(2026, 6, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), 109, 29.266386m },
                    { 2252, -4m, new DateTime(2026, 6, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), 109, 29.388840m },
                    { 2253, -3.6m, new DateTime(2026, 6, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 109, 29.511294m },
                    { 2254, -3.2m, new DateTime(2026, 6, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), 109, 29.633747m },
                    { 2255, -2.8m, new DateTime(2026, 6, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 109, 29.756200m },
                    { 2256, -2.4m, new DateTime(2026, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 109, 29.878654m },
                    { 2257, -2m, new DateTime(2026, 7, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 109, 30.001108m },
                    { 2258, -1.6m, new DateTime(2026, 7, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 109, 30.123561m },
                    { 2259, -1.2m, new DateTime(2026, 7, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 109, 30.246014m },
                    { 2260, -0.80m, new DateTime(2026, 7, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 109, 30.368468m },
                    { 2261, -0.4m, new DateTime(2026, 7, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 109, 30.490922m },
                    { 2262, 0m, new DateTime(2026, 7, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 109, 30.613375m },
                    { 2263, 0.4m, new DateTime(2026, 7, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 109, 30.735828m },
                    { 2264, 0.80m, new DateTime(2026, 7, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 109, 30.858282m },
                    { 2265, 1.2m, new DateTime(2026, 7, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 109, 30.980736m },
                    { 2266, 1.6m, new DateTime(2026, 7, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 109, 31.103189m },
                    { 2267, 2m, new DateTime(2026, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 109, 31.225642m },
                    { 2268, 2.4m, new DateTime(2026, 7, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 109, 31.348096m },
                    { 2269, 2.8m, new DateTime(2026, 7, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 109, 31.470550m },
                    { 2270, 3.2m, new DateTime(2026, 7, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 109, 31.593003m },
                    { 2271, 3.6m, new DateTime(2026, 7, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 109, 31.715456m },
                    { 2272, 4m, new DateTime(2026, 7, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 109, 31.837910m },
                    { 2273, 4.4m, new DateTime(2026, 7, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 109, 31.960364m },
                    { 2274, 4.8m, new DateTime(2026, 7, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), 109, 32.082817m },
                    { 2275, 5.2m, new DateTime(2026, 7, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 109, 32.205270m },
                    { 2276, 5.6m, new DateTime(2026, 7, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), 109, 32.327724m },
                    { 2277, 6m, new DateTime(2026, 7, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 109, 32.450178m },
                    { 2278, 6.40m, new DateTime(2026, 7, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), 109, 32.572631m },
                    { 2279, 0m, new DateTime(2026, 6, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), 110, 21.013200m },
                    { 2280, -6m, new DateTime(2026, 6, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), 110, 21.103000m },
                    { 2281, -5.6m, new DateTime(2026, 6, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 110, 21.192800m },
                    { 2282, -5.2m, new DateTime(2026, 6, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), 110, 21.282600m },
                    { 2283, -4.8m, new DateTime(2026, 6, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), 110, 21.372400m },
                    { 2284, -4.4m, new DateTime(2026, 6, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 110, 21.462200m },
                    { 2285, -4m, new DateTime(2026, 6, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), 110, 21.552000m },
                    { 2286, -3.6m, new DateTime(2026, 6, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 110, 21.641800m },
                    { 2287, -3.2m, new DateTime(2026, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 110, 21.731600m },
                    { 2288, -2.8m, new DateTime(2026, 7, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 110, 21.821400m },
                    { 2289, -2.4m, new DateTime(2026, 7, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 110, 21.911200m },
                    { 2290, -2m, new DateTime(2026, 7, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 110, 22.001000m },
                    { 2291, -1.6m, new DateTime(2026, 7, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 110, 22.090800m },
                    { 2292, -1.2m, new DateTime(2026, 7, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 110, 22.180600m },
                    { 2293, -0.80m, new DateTime(2026, 7, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 110, 22.270400m },
                    { 2294, -0.4m, new DateTime(2026, 7, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 110, 22.360200m },
                    { 2295, 0m, new DateTime(2026, 7, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 110, 22.450000m },
                    { 2296, 0.4m, new DateTime(2026, 7, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 110, 22.539800m },
                    { 2297, 0.80m, new DateTime(2026, 7, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 110, 22.629600m },
                    { 2298, 1.2m, new DateTime(2026, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 110, 22.719400m },
                    { 2299, 1.6m, new DateTime(2026, 7, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 110, 22.809200m },
                    { 2300, 2m, new DateTime(2026, 7, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 110, 22.899000m },
                    { 2301, 2.4m, new DateTime(2026, 7, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 110, 22.988800m },
                    { 2302, 2.8m, new DateTime(2026, 7, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 110, 23.078600m },
                    { 2303, 3.2m, new DateTime(2026, 7, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 110, 23.168400m },
                    { 2304, 3.6m, new DateTime(2026, 7, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 110, 23.258200m },
                    { 2305, 4m, new DateTime(2026, 7, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), 110, 23.348000m },
                    { 2306, 4.4m, new DateTime(2026, 7, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 110, 23.437800m },
                    { 2307, 4.8m, new DateTime(2026, 7, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), 110, 23.527600m },
                    { 2308, 5.2m, new DateTime(2026, 7, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 110, 23.617400m },
                    { 2309, 5.6m, new DateTime(2026, 7, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), 110, 23.707200m },
                    { 2310, 0m, new DateTime(2026, 6, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), 111, 17.307976m },
                    { 2311, -5.8m, new DateTime(2026, 6, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), 111, 17.381784m },
                    { 2312, -5.4m, new DateTime(2026, 6, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 111, 17.455592m },
                    { 2313, -5m, new DateTime(2026, 6, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), 111, 17.529400m },
                    { 2314, -4.6m, new DateTime(2026, 6, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), 111, 17.603208m },
                    { 2315, -4.2m, new DateTime(2026, 6, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 111, 17.677016m },
                    { 2316, -3.8m, new DateTime(2026, 6, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), 111, 17.750824m },
                    { 2317, -3.4m, new DateTime(2026, 6, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 111, 17.824632m },
                    { 2318, -3m, new DateTime(2026, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 111, 17.898440m },
                    { 2319, -2.6m, new DateTime(2026, 7, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 111, 17.972248m },
                    { 2320, -2.2m, new DateTime(2026, 7, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 111, 18.046056m },
                    { 2321, -1.8m, new DateTime(2026, 7, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 111, 18.119864m },
                    { 2322, -1.4m, new DateTime(2026, 7, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 111, 18.193672m },
                    { 2323, -1m, new DateTime(2026, 7, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 111, 18.267480m },
                    { 2324, -0.6m, new DateTime(2026, 7, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 111, 18.341288m },
                    { 2325, -0.2m, new DateTime(2026, 7, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 111, 18.415096m },
                    { 2326, 0.2m, new DateTime(2026, 7, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 111, 18.488904m },
                    { 2327, 0.6m, new DateTime(2026, 7, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 111, 18.562712m },
                    { 2328, 1m, new DateTime(2026, 7, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 111, 18.636520m },
                    { 2329, 1.4m, new DateTime(2026, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 111, 18.710328m },
                    { 2330, 1.8m, new DateTime(2026, 7, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 111, 18.784136m },
                    { 2331, 2.2m, new DateTime(2026, 7, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 111, 18.857944m },
                    { 2332, 2.6m, new DateTime(2026, 7, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 111, 18.931752m },
                    { 2333, 3m, new DateTime(2026, 7, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 111, 19.005560m },
                    { 2334, 3.4m, new DateTime(2026, 7, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 111, 19.079368m },
                    { 2335, 3.8m, new DateTime(2026, 7, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 111, 19.153176m },
                    { 2336, 4.2m, new DateTime(2026, 7, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), 111, 19.226984m },
                    { 2337, 4.6m, new DateTime(2026, 7, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 111, 19.300792m },
                    { 2338, 5m, new DateTime(2026, 7, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), 111, 19.374600m },
                    { 2339, 5.4m, new DateTime(2026, 7, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 111, 19.448408m },
                    { 2340, 5.8m, new DateTime(2026, 7, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), 111, 19.522216m },
                    { 2341, 0m, new DateTime(2026, 6, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), 112, 42.582000m },
                    { 2342, -5.6m, new DateTime(2026, 6, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), 112, 42.763200m },
                    { 2343, -5.2m, new DateTime(2026, 6, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 112, 42.944400m },
                    { 2344, -4.8m, new DateTime(2026, 6, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), 112, 43.125600m },
                    { 2345, -4.4m, new DateTime(2026, 6, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), 112, 43.306800m },
                    { 2346, -4m, new DateTime(2026, 6, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 112, 43.488000m },
                    { 2347, -3.6m, new DateTime(2026, 6, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), 112, 43.669200m },
                    { 2348, -3.2m, new DateTime(2026, 6, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 112, 43.850400m },
                    { 2349, -2.8m, new DateTime(2026, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 112, 44.031600m },
                    { 2350, -2.4m, new DateTime(2026, 7, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 112, 44.212800m },
                    { 2351, -2m, new DateTime(2026, 7, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 112, 44.394000m },
                    { 2352, -1.6m, new DateTime(2026, 7, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 112, 44.575200m },
                    { 2353, -1.2m, new DateTime(2026, 7, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 112, 44.756400m },
                    { 2354, -0.80m, new DateTime(2026, 7, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 112, 44.937600m },
                    { 2355, -0.4m, new DateTime(2026, 7, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 112, 45.118800m },
                    { 2356, 0m, new DateTime(2026, 7, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 112, 45.300000m },
                    { 2357, 0.4m, new DateTime(2026, 7, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 112, 45.481200m },
                    { 2358, 0.80m, new DateTime(2026, 7, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 112, 45.662400m },
                    { 2359, 1.2m, new DateTime(2026, 7, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 112, 45.843600m },
                    { 2360, 1.6m, new DateTime(2026, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 112, 46.024800m },
                    { 2361, 2m, new DateTime(2026, 7, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 112, 46.206000m },
                    { 2362, 2.4m, new DateTime(2026, 7, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 112, 46.387200m },
                    { 2363, 2.8m, new DateTime(2026, 7, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 112, 46.568400m },
                    { 2364, 3.2m, new DateTime(2026, 7, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 112, 46.749600m },
                    { 2365, 3.6m, new DateTime(2026, 7, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 112, 46.930800m },
                    { 2366, 4m, new DateTime(2026, 7, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 112, 47.112000m },
                    { 2367, 4.4m, new DateTime(2026, 7, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), 112, 47.293200m },
                    { 2368, 4.8m, new DateTime(2026, 7, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 112, 47.474400m },
                    { 2369, 5.2m, new DateTime(2026, 7, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), 112, 47.655600m },
                    { 2370, 5.6m, new DateTime(2026, 7, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 112, 47.836800m },
                    { 2371, 6m, new DateTime(2026, 7, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), 112, 48.018000m },
                    { 2372, 0m, new DateTime(2026, 6, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), 113, 109.083600m },
                    { 2373, -5.4m, new DateTime(2026, 6, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), 113, 109.546800m },
                    { 2374, -5m, new DateTime(2026, 6, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 113, 110.010000m },
                    { 2375, -4.6m, new DateTime(2026, 6, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), 113, 110.473200m },
                    { 2376, -4.2m, new DateTime(2026, 6, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), 113, 110.936400m },
                    { 2377, -3.8m, new DateTime(2026, 6, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 113, 111.399600m },
                    { 2378, -3.4m, new DateTime(2026, 6, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), 113, 111.862800m },
                    { 2379, -3m, new DateTime(2026, 6, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 113, 112.326000m },
                    { 2380, -2.6m, new DateTime(2026, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 113, 112.789200m },
                    { 2381, -2.2m, new DateTime(2026, 7, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 113, 113.252400m },
                    { 2382, -1.8m, new DateTime(2026, 7, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 113, 113.715600m },
                    { 2383, -1.4m, new DateTime(2026, 7, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 113, 114.178800m },
                    { 2384, -1m, new DateTime(2026, 7, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 113, 114.642000m },
                    { 2385, -0.6m, new DateTime(2026, 7, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 113, 115.105200m },
                    { 2386, -0.2m, new DateTime(2026, 7, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 113, 115.568400m },
                    { 2387, 0.2m, new DateTime(2026, 7, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 113, 116.031600m },
                    { 2388, 0.6m, new DateTime(2026, 7, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 113, 116.494800m },
                    { 2389, 1m, new DateTime(2026, 7, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 113, 116.958000m },
                    { 2390, 1.4m, new DateTime(2026, 7, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 113, 117.421200m },
                    { 2391, 1.8m, new DateTime(2026, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 113, 117.884400m },
                    { 2392, 2.2m, new DateTime(2026, 7, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 113, 118.347600m },
                    { 2393, 2.6m, new DateTime(2026, 7, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 113, 118.810800m },
                    { 2394, 3m, new DateTime(2026, 7, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 113, 119.274000m },
                    { 2395, 3.4m, new DateTime(2026, 7, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 113, 119.737200m },
                    { 2396, 3.8m, new DateTime(2026, 7, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 113, 120.200400m },
                    { 2397, 4.2m, new DateTime(2026, 7, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 113, 120.663600m },
                    { 2398, 4.6m, new DateTime(2026, 7, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), 113, 121.126800m },
                    { 2399, 5m, new DateTime(2026, 7, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 113, 121.590000m },
                    { 2400, 5.4m, new DateTime(2026, 7, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), 113, 122.053200m },
                    { 2401, 5.8m, new DateTime(2026, 7, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 113, 122.516400m },
                    { 2402, 6.2m, new DateTime(2026, 7, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), 113, 122.979600m },
                    { 2403, 0m, new DateTime(2026, 6, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), 114, 11.705600m },
                    { 2404, -5.2m, new DateTime(2026, 6, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), 114, 11.755200m },
                    { 2405, -4.8m, new DateTime(2026, 6, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 114, 11.804800m },
                    { 2406, -4.4m, new DateTime(2026, 6, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), 114, 11.854400m },
                    { 2407, -4m, new DateTime(2026, 6, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), 114, 11.904000m },
                    { 2408, -3.6m, new DateTime(2026, 6, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 114, 11.953600m },
                    { 2409, -3.2m, new DateTime(2026, 6, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), 114, 12.003200m },
                    { 2410, -2.8m, new DateTime(2026, 6, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 114, 12.052800m },
                    { 2411, -2.4m, new DateTime(2026, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 114, 12.102400m },
                    { 2412, -2m, new DateTime(2026, 7, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 114, 12.152000m },
                    { 2413, -1.6m, new DateTime(2026, 7, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 114, 12.201600m },
                    { 2414, -1.2m, new DateTime(2026, 7, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 114, 12.251200m },
                    { 2415, -0.80m, new DateTime(2026, 7, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 114, 12.300800m },
                    { 2416, -0.4m, new DateTime(2026, 7, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 114, 12.350400m },
                    { 2417, 0m, new DateTime(2026, 7, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 114, 12.400000m },
                    { 2418, 0.4m, new DateTime(2026, 7, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 114, 12.449600m },
                    { 2419, 0.80m, new DateTime(2026, 7, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 114, 12.499200m },
                    { 2420, 1.2m, new DateTime(2026, 7, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 114, 12.548800m },
                    { 2421, 1.6m, new DateTime(2026, 7, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 114, 12.598400m },
                    { 2422, 2m, new DateTime(2026, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 114, 12.648000m },
                    { 2423, 2.4m, new DateTime(2026, 7, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 114, 12.697600m },
                    { 2424, 2.8m, new DateTime(2026, 7, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 114, 12.747200m },
                    { 2425, 3.2m, new DateTime(2026, 7, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 114, 12.796800m },
                    { 2426, 3.6m, new DateTime(2026, 7, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 114, 12.846400m },
                    { 2427, 4m, new DateTime(2026, 7, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 114, 12.896000m },
                    { 2428, 4.4m, new DateTime(2026, 7, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 114, 12.945600m },
                    { 2429, 4.8m, new DateTime(2026, 7, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), 114, 12.995200m },
                    { 2430, 5.2m, new DateTime(2026, 7, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 114, 13.044800m },
                    { 2431, 5.6m, new DateTime(2026, 7, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), 114, 13.094400m },
                    { 2432, 6m, new DateTime(2026, 7, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 114, 13.144000m },
                    { 2433, 6.40m, new DateTime(2026, 7, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), 114, 13.193600m },
                    { 2434, 0m, new DateTime(2026, 6, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), 115, 8.377200m },
                    { 2435, -6m, new DateTime(2026, 6, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), 115, 8.413000m },
                    { 2436, -5.6m, new DateTime(2026, 6, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 115, 8.448800m },
                    { 2437, -5.2m, new DateTime(2026, 6, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), 115, 8.484600m },
                    { 2438, -4.8m, new DateTime(2026, 6, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), 115, 8.520400m },
                    { 2439, -4.4m, new DateTime(2026, 6, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 115, 8.556200m },
                    { 2440, -4m, new DateTime(2026, 6, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), 115, 8.592000m },
                    { 2441, -3.6m, new DateTime(2026, 6, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 115, 8.627800m },
                    { 2442, -3.2m, new DateTime(2026, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 115, 8.663600m },
                    { 2443, -2.8m, new DateTime(2026, 7, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 115, 8.699400m },
                    { 2444, -2.4m, new DateTime(2026, 7, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 115, 8.735200m },
                    { 2445, -2m, new DateTime(2026, 7, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 115, 8.771000m },
                    { 2446, -1.6m, new DateTime(2026, 7, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 115, 8.806800m },
                    { 2447, -1.2m, new DateTime(2026, 7, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 115, 8.842600m },
                    { 2448, -0.80m, new DateTime(2026, 7, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 115, 8.878400m },
                    { 2449, -0.4m, new DateTime(2026, 7, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 115, 8.914200m },
                    { 2450, 0m, new DateTime(2026, 7, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 115, 8.950000m },
                    { 2451, 0.4m, new DateTime(2026, 7, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 115, 8.985800m },
                    { 2452, 0.80m, new DateTime(2026, 7, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 115, 9.021600m },
                    { 2453, 1.2m, new DateTime(2026, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 115, 9.057400m },
                    { 2454, 1.6m, new DateTime(2026, 7, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 115, 9.093200m },
                    { 2455, 2m, new DateTime(2026, 7, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 115, 9.129000m },
                    { 2456, 2.4m, new DateTime(2026, 7, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 115, 9.164800m },
                    { 2457, 2.8m, new DateTime(2026, 7, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 115, 9.200600m },
                    { 2458, 3.2m, new DateTime(2026, 7, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 115, 9.236400m },
                    { 2459, 3.6m, new DateTime(2026, 7, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 115, 9.272200m },
                    { 2460, 4m, new DateTime(2026, 7, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), 115, 9.308000m },
                    { 2461, 4.4m, new DateTime(2026, 7, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 115, 9.343800m },
                    { 2462, 4.8m, new DateTime(2026, 7, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), 115, 9.379600m },
                    { 2463, 5.2m, new DateTime(2026, 7, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 115, 9.415400m },
                    { 2464, 5.6m, new DateTime(2026, 7, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), 115, 9.451200m }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "FundPrices",
                keyColumn: "Id",
                keyValue: 2000);

            migrationBuilder.DeleteData(
                table: "FundPrices",
                keyColumn: "Id",
                keyValue: 2001);

            migrationBuilder.DeleteData(
                table: "FundPrices",
                keyColumn: "Id",
                keyValue: 2002);

            migrationBuilder.DeleteData(
                table: "FundPrices",
                keyColumn: "Id",
                keyValue: 2003);

            migrationBuilder.DeleteData(
                table: "FundPrices",
                keyColumn: "Id",
                keyValue: 2004);

            migrationBuilder.DeleteData(
                table: "FundPrices",
                keyColumn: "Id",
                keyValue: 2005);

            migrationBuilder.DeleteData(
                table: "FundPrices",
                keyColumn: "Id",
                keyValue: 2006);

            migrationBuilder.DeleteData(
                table: "FundPrices",
                keyColumn: "Id",
                keyValue: 2007);

            migrationBuilder.DeleteData(
                table: "FundPrices",
                keyColumn: "Id",
                keyValue: 2008);

            migrationBuilder.DeleteData(
                table: "FundPrices",
                keyColumn: "Id",
                keyValue: 2009);

            migrationBuilder.DeleteData(
                table: "FundPrices",
                keyColumn: "Id",
                keyValue: 2010);

            migrationBuilder.DeleteData(
                table: "FundPrices",
                keyColumn: "Id",
                keyValue: 2011);

            migrationBuilder.DeleteData(
                table: "FundPrices",
                keyColumn: "Id",
                keyValue: 2012);

            migrationBuilder.DeleteData(
                table: "FundPrices",
                keyColumn: "Id",
                keyValue: 2013);

            migrationBuilder.DeleteData(
                table: "FundPrices",
                keyColumn: "Id",
                keyValue: 2014);

            migrationBuilder.DeleteData(
                table: "FundPrices",
                keyColumn: "Id",
                keyValue: 2015);

            migrationBuilder.DeleteData(
                table: "FundPrices",
                keyColumn: "Id",
                keyValue: 2016);

            migrationBuilder.DeleteData(
                table: "FundPrices",
                keyColumn: "Id",
                keyValue: 2017);

            migrationBuilder.DeleteData(
                table: "FundPrices",
                keyColumn: "Id",
                keyValue: 2018);

            migrationBuilder.DeleteData(
                table: "FundPrices",
                keyColumn: "Id",
                keyValue: 2019);

            migrationBuilder.DeleteData(
                table: "FundPrices",
                keyColumn: "Id",
                keyValue: 2020);

            migrationBuilder.DeleteData(
                table: "FundPrices",
                keyColumn: "Id",
                keyValue: 2021);

            migrationBuilder.DeleteData(
                table: "FundPrices",
                keyColumn: "Id",
                keyValue: 2022);

            migrationBuilder.DeleteData(
                table: "FundPrices",
                keyColumn: "Id",
                keyValue: 2023);

            migrationBuilder.DeleteData(
                table: "FundPrices",
                keyColumn: "Id",
                keyValue: 2024);

            migrationBuilder.DeleteData(
                table: "FundPrices",
                keyColumn: "Id",
                keyValue: 2025);

            migrationBuilder.DeleteData(
                table: "FundPrices",
                keyColumn: "Id",
                keyValue: 2026);

            migrationBuilder.DeleteData(
                table: "FundPrices",
                keyColumn: "Id",
                keyValue: 2027);

            migrationBuilder.DeleteData(
                table: "FundPrices",
                keyColumn: "Id",
                keyValue: 2028);

            migrationBuilder.DeleteData(
                table: "FundPrices",
                keyColumn: "Id",
                keyValue: 2029);

            migrationBuilder.DeleteData(
                table: "FundPrices",
                keyColumn: "Id",
                keyValue: 2030);

            migrationBuilder.DeleteData(
                table: "FundPrices",
                keyColumn: "Id",
                keyValue: 2031);

            migrationBuilder.DeleteData(
                table: "FundPrices",
                keyColumn: "Id",
                keyValue: 2032);

            migrationBuilder.DeleteData(
                table: "FundPrices",
                keyColumn: "Id",
                keyValue: 2033);

            migrationBuilder.DeleteData(
                table: "FundPrices",
                keyColumn: "Id",
                keyValue: 2034);

            migrationBuilder.DeleteData(
                table: "FundPrices",
                keyColumn: "Id",
                keyValue: 2035);

            migrationBuilder.DeleteData(
                table: "FundPrices",
                keyColumn: "Id",
                keyValue: 2036);

            migrationBuilder.DeleteData(
                table: "FundPrices",
                keyColumn: "Id",
                keyValue: 2037);

            migrationBuilder.DeleteData(
                table: "FundPrices",
                keyColumn: "Id",
                keyValue: 2038);

            migrationBuilder.DeleteData(
                table: "FundPrices",
                keyColumn: "Id",
                keyValue: 2039);

            migrationBuilder.DeleteData(
                table: "FundPrices",
                keyColumn: "Id",
                keyValue: 2040);

            migrationBuilder.DeleteData(
                table: "FundPrices",
                keyColumn: "Id",
                keyValue: 2041);

            migrationBuilder.DeleteData(
                table: "FundPrices",
                keyColumn: "Id",
                keyValue: 2042);

            migrationBuilder.DeleteData(
                table: "FundPrices",
                keyColumn: "Id",
                keyValue: 2043);

            migrationBuilder.DeleteData(
                table: "FundPrices",
                keyColumn: "Id",
                keyValue: 2044);

            migrationBuilder.DeleteData(
                table: "FundPrices",
                keyColumn: "Id",
                keyValue: 2045);

            migrationBuilder.DeleteData(
                table: "FundPrices",
                keyColumn: "Id",
                keyValue: 2046);

            migrationBuilder.DeleteData(
                table: "FundPrices",
                keyColumn: "Id",
                keyValue: 2047);

            migrationBuilder.DeleteData(
                table: "FundPrices",
                keyColumn: "Id",
                keyValue: 2048);

            migrationBuilder.DeleteData(
                table: "FundPrices",
                keyColumn: "Id",
                keyValue: 2049);

            migrationBuilder.DeleteData(
                table: "FundPrices",
                keyColumn: "Id",
                keyValue: 2050);

            migrationBuilder.DeleteData(
                table: "FundPrices",
                keyColumn: "Id",
                keyValue: 2051);

            migrationBuilder.DeleteData(
                table: "FundPrices",
                keyColumn: "Id",
                keyValue: 2052);

            migrationBuilder.DeleteData(
                table: "FundPrices",
                keyColumn: "Id",
                keyValue: 2053);

            migrationBuilder.DeleteData(
                table: "FundPrices",
                keyColumn: "Id",
                keyValue: 2054);

            migrationBuilder.DeleteData(
                table: "FundPrices",
                keyColumn: "Id",
                keyValue: 2055);

            migrationBuilder.DeleteData(
                table: "FundPrices",
                keyColumn: "Id",
                keyValue: 2056);

            migrationBuilder.DeleteData(
                table: "FundPrices",
                keyColumn: "Id",
                keyValue: 2057);

            migrationBuilder.DeleteData(
                table: "FundPrices",
                keyColumn: "Id",
                keyValue: 2058);

            migrationBuilder.DeleteData(
                table: "FundPrices",
                keyColumn: "Id",
                keyValue: 2059);

            migrationBuilder.DeleteData(
                table: "FundPrices",
                keyColumn: "Id",
                keyValue: 2060);

            migrationBuilder.DeleteData(
                table: "FundPrices",
                keyColumn: "Id",
                keyValue: 2061);

            migrationBuilder.DeleteData(
                table: "FundPrices",
                keyColumn: "Id",
                keyValue: 2062);

            migrationBuilder.DeleteData(
                table: "FundPrices",
                keyColumn: "Id",
                keyValue: 2063);

            migrationBuilder.DeleteData(
                table: "FundPrices",
                keyColumn: "Id",
                keyValue: 2064);

            migrationBuilder.DeleteData(
                table: "FundPrices",
                keyColumn: "Id",
                keyValue: 2065);

            migrationBuilder.DeleteData(
                table: "FundPrices",
                keyColumn: "Id",
                keyValue: 2066);

            migrationBuilder.DeleteData(
                table: "FundPrices",
                keyColumn: "Id",
                keyValue: 2067);

            migrationBuilder.DeleteData(
                table: "FundPrices",
                keyColumn: "Id",
                keyValue: 2068);

            migrationBuilder.DeleteData(
                table: "FundPrices",
                keyColumn: "Id",
                keyValue: 2069);

            migrationBuilder.DeleteData(
                table: "FundPrices",
                keyColumn: "Id",
                keyValue: 2070);

            migrationBuilder.DeleteData(
                table: "FundPrices",
                keyColumn: "Id",
                keyValue: 2071);

            migrationBuilder.DeleteData(
                table: "FundPrices",
                keyColumn: "Id",
                keyValue: 2072);

            migrationBuilder.DeleteData(
                table: "FundPrices",
                keyColumn: "Id",
                keyValue: 2073);

            migrationBuilder.DeleteData(
                table: "FundPrices",
                keyColumn: "Id",
                keyValue: 2074);

            migrationBuilder.DeleteData(
                table: "FundPrices",
                keyColumn: "Id",
                keyValue: 2075);

            migrationBuilder.DeleteData(
                table: "FundPrices",
                keyColumn: "Id",
                keyValue: 2076);

            migrationBuilder.DeleteData(
                table: "FundPrices",
                keyColumn: "Id",
                keyValue: 2077);

            migrationBuilder.DeleteData(
                table: "FundPrices",
                keyColumn: "Id",
                keyValue: 2078);

            migrationBuilder.DeleteData(
                table: "FundPrices",
                keyColumn: "Id",
                keyValue: 2079);

            migrationBuilder.DeleteData(
                table: "FundPrices",
                keyColumn: "Id",
                keyValue: 2080);

            migrationBuilder.DeleteData(
                table: "FundPrices",
                keyColumn: "Id",
                keyValue: 2081);

            migrationBuilder.DeleteData(
                table: "FundPrices",
                keyColumn: "Id",
                keyValue: 2082);

            migrationBuilder.DeleteData(
                table: "FundPrices",
                keyColumn: "Id",
                keyValue: 2083);

            migrationBuilder.DeleteData(
                table: "FundPrices",
                keyColumn: "Id",
                keyValue: 2084);

            migrationBuilder.DeleteData(
                table: "FundPrices",
                keyColumn: "Id",
                keyValue: 2085);

            migrationBuilder.DeleteData(
                table: "FundPrices",
                keyColumn: "Id",
                keyValue: 2086);

            migrationBuilder.DeleteData(
                table: "FundPrices",
                keyColumn: "Id",
                keyValue: 2087);

            migrationBuilder.DeleteData(
                table: "FundPrices",
                keyColumn: "Id",
                keyValue: 2088);

            migrationBuilder.DeleteData(
                table: "FundPrices",
                keyColumn: "Id",
                keyValue: 2089);

            migrationBuilder.DeleteData(
                table: "FundPrices",
                keyColumn: "Id",
                keyValue: 2090);

            migrationBuilder.DeleteData(
                table: "FundPrices",
                keyColumn: "Id",
                keyValue: 2091);

            migrationBuilder.DeleteData(
                table: "FundPrices",
                keyColumn: "Id",
                keyValue: 2092);

            migrationBuilder.DeleteData(
                table: "FundPrices",
                keyColumn: "Id",
                keyValue: 2093);

            migrationBuilder.DeleteData(
                table: "FundPrices",
                keyColumn: "Id",
                keyValue: 2094);

            migrationBuilder.DeleteData(
                table: "FundPrices",
                keyColumn: "Id",
                keyValue: 2095);

            migrationBuilder.DeleteData(
                table: "FundPrices",
                keyColumn: "Id",
                keyValue: 2096);

            migrationBuilder.DeleteData(
                table: "FundPrices",
                keyColumn: "Id",
                keyValue: 2097);

            migrationBuilder.DeleteData(
                table: "FundPrices",
                keyColumn: "Id",
                keyValue: 2098);

            migrationBuilder.DeleteData(
                table: "FundPrices",
                keyColumn: "Id",
                keyValue: 2099);

            migrationBuilder.DeleteData(
                table: "FundPrices",
                keyColumn: "Id",
                keyValue: 2100);

            migrationBuilder.DeleteData(
                table: "FundPrices",
                keyColumn: "Id",
                keyValue: 2101);

            migrationBuilder.DeleteData(
                table: "FundPrices",
                keyColumn: "Id",
                keyValue: 2102);

            migrationBuilder.DeleteData(
                table: "FundPrices",
                keyColumn: "Id",
                keyValue: 2103);

            migrationBuilder.DeleteData(
                table: "FundPrices",
                keyColumn: "Id",
                keyValue: 2104);

            migrationBuilder.DeleteData(
                table: "FundPrices",
                keyColumn: "Id",
                keyValue: 2105);

            migrationBuilder.DeleteData(
                table: "FundPrices",
                keyColumn: "Id",
                keyValue: 2106);

            migrationBuilder.DeleteData(
                table: "FundPrices",
                keyColumn: "Id",
                keyValue: 2107);

            migrationBuilder.DeleteData(
                table: "FundPrices",
                keyColumn: "Id",
                keyValue: 2108);

            migrationBuilder.DeleteData(
                table: "FundPrices",
                keyColumn: "Id",
                keyValue: 2109);

            migrationBuilder.DeleteData(
                table: "FundPrices",
                keyColumn: "Id",
                keyValue: 2110);

            migrationBuilder.DeleteData(
                table: "FundPrices",
                keyColumn: "Id",
                keyValue: 2111);

            migrationBuilder.DeleteData(
                table: "FundPrices",
                keyColumn: "Id",
                keyValue: 2112);

            migrationBuilder.DeleteData(
                table: "FundPrices",
                keyColumn: "Id",
                keyValue: 2113);

            migrationBuilder.DeleteData(
                table: "FundPrices",
                keyColumn: "Id",
                keyValue: 2114);

            migrationBuilder.DeleteData(
                table: "FundPrices",
                keyColumn: "Id",
                keyValue: 2115);

            migrationBuilder.DeleteData(
                table: "FundPrices",
                keyColumn: "Id",
                keyValue: 2116);

            migrationBuilder.DeleteData(
                table: "FundPrices",
                keyColumn: "Id",
                keyValue: 2117);

            migrationBuilder.DeleteData(
                table: "FundPrices",
                keyColumn: "Id",
                keyValue: 2118);

            migrationBuilder.DeleteData(
                table: "FundPrices",
                keyColumn: "Id",
                keyValue: 2119);

            migrationBuilder.DeleteData(
                table: "FundPrices",
                keyColumn: "Id",
                keyValue: 2120);

            migrationBuilder.DeleteData(
                table: "FundPrices",
                keyColumn: "Id",
                keyValue: 2121);

            migrationBuilder.DeleteData(
                table: "FundPrices",
                keyColumn: "Id",
                keyValue: 2122);

            migrationBuilder.DeleteData(
                table: "FundPrices",
                keyColumn: "Id",
                keyValue: 2123);

            migrationBuilder.DeleteData(
                table: "FundPrices",
                keyColumn: "Id",
                keyValue: 2124);

            migrationBuilder.DeleteData(
                table: "FundPrices",
                keyColumn: "Id",
                keyValue: 2125);

            migrationBuilder.DeleteData(
                table: "FundPrices",
                keyColumn: "Id",
                keyValue: 2126);

            migrationBuilder.DeleteData(
                table: "FundPrices",
                keyColumn: "Id",
                keyValue: 2127);

            migrationBuilder.DeleteData(
                table: "FundPrices",
                keyColumn: "Id",
                keyValue: 2128);

            migrationBuilder.DeleteData(
                table: "FundPrices",
                keyColumn: "Id",
                keyValue: 2129);

            migrationBuilder.DeleteData(
                table: "FundPrices",
                keyColumn: "Id",
                keyValue: 2130);

            migrationBuilder.DeleteData(
                table: "FundPrices",
                keyColumn: "Id",
                keyValue: 2131);

            migrationBuilder.DeleteData(
                table: "FundPrices",
                keyColumn: "Id",
                keyValue: 2132);

            migrationBuilder.DeleteData(
                table: "FundPrices",
                keyColumn: "Id",
                keyValue: 2133);

            migrationBuilder.DeleteData(
                table: "FundPrices",
                keyColumn: "Id",
                keyValue: 2134);

            migrationBuilder.DeleteData(
                table: "FundPrices",
                keyColumn: "Id",
                keyValue: 2135);

            migrationBuilder.DeleteData(
                table: "FundPrices",
                keyColumn: "Id",
                keyValue: 2136);

            migrationBuilder.DeleteData(
                table: "FundPrices",
                keyColumn: "Id",
                keyValue: 2137);

            migrationBuilder.DeleteData(
                table: "FundPrices",
                keyColumn: "Id",
                keyValue: 2138);

            migrationBuilder.DeleteData(
                table: "FundPrices",
                keyColumn: "Id",
                keyValue: 2139);

            migrationBuilder.DeleteData(
                table: "FundPrices",
                keyColumn: "Id",
                keyValue: 2140);

            migrationBuilder.DeleteData(
                table: "FundPrices",
                keyColumn: "Id",
                keyValue: 2141);

            migrationBuilder.DeleteData(
                table: "FundPrices",
                keyColumn: "Id",
                keyValue: 2142);

            migrationBuilder.DeleteData(
                table: "FundPrices",
                keyColumn: "Id",
                keyValue: 2143);

            migrationBuilder.DeleteData(
                table: "FundPrices",
                keyColumn: "Id",
                keyValue: 2144);

            migrationBuilder.DeleteData(
                table: "FundPrices",
                keyColumn: "Id",
                keyValue: 2145);

            migrationBuilder.DeleteData(
                table: "FundPrices",
                keyColumn: "Id",
                keyValue: 2146);

            migrationBuilder.DeleteData(
                table: "FundPrices",
                keyColumn: "Id",
                keyValue: 2147);

            migrationBuilder.DeleteData(
                table: "FundPrices",
                keyColumn: "Id",
                keyValue: 2148);

            migrationBuilder.DeleteData(
                table: "FundPrices",
                keyColumn: "Id",
                keyValue: 2149);

            migrationBuilder.DeleteData(
                table: "FundPrices",
                keyColumn: "Id",
                keyValue: 2150);

            migrationBuilder.DeleteData(
                table: "FundPrices",
                keyColumn: "Id",
                keyValue: 2151);

            migrationBuilder.DeleteData(
                table: "FundPrices",
                keyColumn: "Id",
                keyValue: 2152);

            migrationBuilder.DeleteData(
                table: "FundPrices",
                keyColumn: "Id",
                keyValue: 2153);

            migrationBuilder.DeleteData(
                table: "FundPrices",
                keyColumn: "Id",
                keyValue: 2154);

            migrationBuilder.DeleteData(
                table: "FundPrices",
                keyColumn: "Id",
                keyValue: 2155);

            migrationBuilder.DeleteData(
                table: "FundPrices",
                keyColumn: "Id",
                keyValue: 2156);

            migrationBuilder.DeleteData(
                table: "FundPrices",
                keyColumn: "Id",
                keyValue: 2157);

            migrationBuilder.DeleteData(
                table: "FundPrices",
                keyColumn: "Id",
                keyValue: 2158);

            migrationBuilder.DeleteData(
                table: "FundPrices",
                keyColumn: "Id",
                keyValue: 2159);

            migrationBuilder.DeleteData(
                table: "FundPrices",
                keyColumn: "Id",
                keyValue: 2160);

            migrationBuilder.DeleteData(
                table: "FundPrices",
                keyColumn: "Id",
                keyValue: 2161);

            migrationBuilder.DeleteData(
                table: "FundPrices",
                keyColumn: "Id",
                keyValue: 2162);

            migrationBuilder.DeleteData(
                table: "FundPrices",
                keyColumn: "Id",
                keyValue: 2163);

            migrationBuilder.DeleteData(
                table: "FundPrices",
                keyColumn: "Id",
                keyValue: 2164);

            migrationBuilder.DeleteData(
                table: "FundPrices",
                keyColumn: "Id",
                keyValue: 2165);

            migrationBuilder.DeleteData(
                table: "FundPrices",
                keyColumn: "Id",
                keyValue: 2166);

            migrationBuilder.DeleteData(
                table: "FundPrices",
                keyColumn: "Id",
                keyValue: 2167);

            migrationBuilder.DeleteData(
                table: "FundPrices",
                keyColumn: "Id",
                keyValue: 2168);

            migrationBuilder.DeleteData(
                table: "FundPrices",
                keyColumn: "Id",
                keyValue: 2169);

            migrationBuilder.DeleteData(
                table: "FundPrices",
                keyColumn: "Id",
                keyValue: 2170);

            migrationBuilder.DeleteData(
                table: "FundPrices",
                keyColumn: "Id",
                keyValue: 2171);

            migrationBuilder.DeleteData(
                table: "FundPrices",
                keyColumn: "Id",
                keyValue: 2172);

            migrationBuilder.DeleteData(
                table: "FundPrices",
                keyColumn: "Id",
                keyValue: 2173);

            migrationBuilder.DeleteData(
                table: "FundPrices",
                keyColumn: "Id",
                keyValue: 2174);

            migrationBuilder.DeleteData(
                table: "FundPrices",
                keyColumn: "Id",
                keyValue: 2175);

            migrationBuilder.DeleteData(
                table: "FundPrices",
                keyColumn: "Id",
                keyValue: 2176);

            migrationBuilder.DeleteData(
                table: "FundPrices",
                keyColumn: "Id",
                keyValue: 2177);

            migrationBuilder.DeleteData(
                table: "FundPrices",
                keyColumn: "Id",
                keyValue: 2178);

            migrationBuilder.DeleteData(
                table: "FundPrices",
                keyColumn: "Id",
                keyValue: 2179);

            migrationBuilder.DeleteData(
                table: "FundPrices",
                keyColumn: "Id",
                keyValue: 2180);

            migrationBuilder.DeleteData(
                table: "FundPrices",
                keyColumn: "Id",
                keyValue: 2181);

            migrationBuilder.DeleteData(
                table: "FundPrices",
                keyColumn: "Id",
                keyValue: 2182);

            migrationBuilder.DeleteData(
                table: "FundPrices",
                keyColumn: "Id",
                keyValue: 2183);

            migrationBuilder.DeleteData(
                table: "FundPrices",
                keyColumn: "Id",
                keyValue: 2184);

            migrationBuilder.DeleteData(
                table: "FundPrices",
                keyColumn: "Id",
                keyValue: 2185);

            migrationBuilder.DeleteData(
                table: "FundPrices",
                keyColumn: "Id",
                keyValue: 2186);

            migrationBuilder.DeleteData(
                table: "FundPrices",
                keyColumn: "Id",
                keyValue: 2187);

            migrationBuilder.DeleteData(
                table: "FundPrices",
                keyColumn: "Id",
                keyValue: 2188);

            migrationBuilder.DeleteData(
                table: "FundPrices",
                keyColumn: "Id",
                keyValue: 2189);

            migrationBuilder.DeleteData(
                table: "FundPrices",
                keyColumn: "Id",
                keyValue: 2190);

            migrationBuilder.DeleteData(
                table: "FundPrices",
                keyColumn: "Id",
                keyValue: 2191);

            migrationBuilder.DeleteData(
                table: "FundPrices",
                keyColumn: "Id",
                keyValue: 2192);

            migrationBuilder.DeleteData(
                table: "FundPrices",
                keyColumn: "Id",
                keyValue: 2193);

            migrationBuilder.DeleteData(
                table: "FundPrices",
                keyColumn: "Id",
                keyValue: 2194);

            migrationBuilder.DeleteData(
                table: "FundPrices",
                keyColumn: "Id",
                keyValue: 2195);

            migrationBuilder.DeleteData(
                table: "FundPrices",
                keyColumn: "Id",
                keyValue: 2196);

            migrationBuilder.DeleteData(
                table: "FundPrices",
                keyColumn: "Id",
                keyValue: 2197);

            migrationBuilder.DeleteData(
                table: "FundPrices",
                keyColumn: "Id",
                keyValue: 2198);

            migrationBuilder.DeleteData(
                table: "FundPrices",
                keyColumn: "Id",
                keyValue: 2199);

            migrationBuilder.DeleteData(
                table: "FundPrices",
                keyColumn: "Id",
                keyValue: 2200);

            migrationBuilder.DeleteData(
                table: "FundPrices",
                keyColumn: "Id",
                keyValue: 2201);

            migrationBuilder.DeleteData(
                table: "FundPrices",
                keyColumn: "Id",
                keyValue: 2202);

            migrationBuilder.DeleteData(
                table: "FundPrices",
                keyColumn: "Id",
                keyValue: 2203);

            migrationBuilder.DeleteData(
                table: "FundPrices",
                keyColumn: "Id",
                keyValue: 2204);

            migrationBuilder.DeleteData(
                table: "FundPrices",
                keyColumn: "Id",
                keyValue: 2205);

            migrationBuilder.DeleteData(
                table: "FundPrices",
                keyColumn: "Id",
                keyValue: 2206);

            migrationBuilder.DeleteData(
                table: "FundPrices",
                keyColumn: "Id",
                keyValue: 2207);

            migrationBuilder.DeleteData(
                table: "FundPrices",
                keyColumn: "Id",
                keyValue: 2208);

            migrationBuilder.DeleteData(
                table: "FundPrices",
                keyColumn: "Id",
                keyValue: 2209);

            migrationBuilder.DeleteData(
                table: "FundPrices",
                keyColumn: "Id",
                keyValue: 2210);

            migrationBuilder.DeleteData(
                table: "FundPrices",
                keyColumn: "Id",
                keyValue: 2211);

            migrationBuilder.DeleteData(
                table: "FundPrices",
                keyColumn: "Id",
                keyValue: 2212);

            migrationBuilder.DeleteData(
                table: "FundPrices",
                keyColumn: "Id",
                keyValue: 2213);

            migrationBuilder.DeleteData(
                table: "FundPrices",
                keyColumn: "Id",
                keyValue: 2214);

            migrationBuilder.DeleteData(
                table: "FundPrices",
                keyColumn: "Id",
                keyValue: 2215);

            migrationBuilder.DeleteData(
                table: "FundPrices",
                keyColumn: "Id",
                keyValue: 2216);

            migrationBuilder.DeleteData(
                table: "FundPrices",
                keyColumn: "Id",
                keyValue: 2217);

            migrationBuilder.DeleteData(
                table: "FundPrices",
                keyColumn: "Id",
                keyValue: 2218);

            migrationBuilder.DeleteData(
                table: "FundPrices",
                keyColumn: "Id",
                keyValue: 2219);

            migrationBuilder.DeleteData(
                table: "FundPrices",
                keyColumn: "Id",
                keyValue: 2220);

            migrationBuilder.DeleteData(
                table: "FundPrices",
                keyColumn: "Id",
                keyValue: 2221);

            migrationBuilder.DeleteData(
                table: "FundPrices",
                keyColumn: "Id",
                keyValue: 2222);

            migrationBuilder.DeleteData(
                table: "FundPrices",
                keyColumn: "Id",
                keyValue: 2223);

            migrationBuilder.DeleteData(
                table: "FundPrices",
                keyColumn: "Id",
                keyValue: 2224);

            migrationBuilder.DeleteData(
                table: "FundPrices",
                keyColumn: "Id",
                keyValue: 2225);

            migrationBuilder.DeleteData(
                table: "FundPrices",
                keyColumn: "Id",
                keyValue: 2226);

            migrationBuilder.DeleteData(
                table: "FundPrices",
                keyColumn: "Id",
                keyValue: 2227);

            migrationBuilder.DeleteData(
                table: "FundPrices",
                keyColumn: "Id",
                keyValue: 2228);

            migrationBuilder.DeleteData(
                table: "FundPrices",
                keyColumn: "Id",
                keyValue: 2229);

            migrationBuilder.DeleteData(
                table: "FundPrices",
                keyColumn: "Id",
                keyValue: 2230);

            migrationBuilder.DeleteData(
                table: "FundPrices",
                keyColumn: "Id",
                keyValue: 2231);

            migrationBuilder.DeleteData(
                table: "FundPrices",
                keyColumn: "Id",
                keyValue: 2232);

            migrationBuilder.DeleteData(
                table: "FundPrices",
                keyColumn: "Id",
                keyValue: 2233);

            migrationBuilder.DeleteData(
                table: "FundPrices",
                keyColumn: "Id",
                keyValue: 2234);

            migrationBuilder.DeleteData(
                table: "FundPrices",
                keyColumn: "Id",
                keyValue: 2235);

            migrationBuilder.DeleteData(
                table: "FundPrices",
                keyColumn: "Id",
                keyValue: 2236);

            migrationBuilder.DeleteData(
                table: "FundPrices",
                keyColumn: "Id",
                keyValue: 2237);

            migrationBuilder.DeleteData(
                table: "FundPrices",
                keyColumn: "Id",
                keyValue: 2238);

            migrationBuilder.DeleteData(
                table: "FundPrices",
                keyColumn: "Id",
                keyValue: 2239);

            migrationBuilder.DeleteData(
                table: "FundPrices",
                keyColumn: "Id",
                keyValue: 2240);

            migrationBuilder.DeleteData(
                table: "FundPrices",
                keyColumn: "Id",
                keyValue: 2241);

            migrationBuilder.DeleteData(
                table: "FundPrices",
                keyColumn: "Id",
                keyValue: 2242);

            migrationBuilder.DeleteData(
                table: "FundPrices",
                keyColumn: "Id",
                keyValue: 2243);

            migrationBuilder.DeleteData(
                table: "FundPrices",
                keyColumn: "Id",
                keyValue: 2244);

            migrationBuilder.DeleteData(
                table: "FundPrices",
                keyColumn: "Id",
                keyValue: 2245);

            migrationBuilder.DeleteData(
                table: "FundPrices",
                keyColumn: "Id",
                keyValue: 2246);

            migrationBuilder.DeleteData(
                table: "FundPrices",
                keyColumn: "Id",
                keyValue: 2247);

            migrationBuilder.DeleteData(
                table: "FundPrices",
                keyColumn: "Id",
                keyValue: 2248);

            migrationBuilder.DeleteData(
                table: "FundPrices",
                keyColumn: "Id",
                keyValue: 2249);

            migrationBuilder.DeleteData(
                table: "FundPrices",
                keyColumn: "Id",
                keyValue: 2250);

            migrationBuilder.DeleteData(
                table: "FundPrices",
                keyColumn: "Id",
                keyValue: 2251);

            migrationBuilder.DeleteData(
                table: "FundPrices",
                keyColumn: "Id",
                keyValue: 2252);

            migrationBuilder.DeleteData(
                table: "FundPrices",
                keyColumn: "Id",
                keyValue: 2253);

            migrationBuilder.DeleteData(
                table: "FundPrices",
                keyColumn: "Id",
                keyValue: 2254);

            migrationBuilder.DeleteData(
                table: "FundPrices",
                keyColumn: "Id",
                keyValue: 2255);

            migrationBuilder.DeleteData(
                table: "FundPrices",
                keyColumn: "Id",
                keyValue: 2256);

            migrationBuilder.DeleteData(
                table: "FundPrices",
                keyColumn: "Id",
                keyValue: 2257);

            migrationBuilder.DeleteData(
                table: "FundPrices",
                keyColumn: "Id",
                keyValue: 2258);

            migrationBuilder.DeleteData(
                table: "FundPrices",
                keyColumn: "Id",
                keyValue: 2259);

            migrationBuilder.DeleteData(
                table: "FundPrices",
                keyColumn: "Id",
                keyValue: 2260);

            migrationBuilder.DeleteData(
                table: "FundPrices",
                keyColumn: "Id",
                keyValue: 2261);

            migrationBuilder.DeleteData(
                table: "FundPrices",
                keyColumn: "Id",
                keyValue: 2262);

            migrationBuilder.DeleteData(
                table: "FundPrices",
                keyColumn: "Id",
                keyValue: 2263);

            migrationBuilder.DeleteData(
                table: "FundPrices",
                keyColumn: "Id",
                keyValue: 2264);

            migrationBuilder.DeleteData(
                table: "FundPrices",
                keyColumn: "Id",
                keyValue: 2265);

            migrationBuilder.DeleteData(
                table: "FundPrices",
                keyColumn: "Id",
                keyValue: 2266);

            migrationBuilder.DeleteData(
                table: "FundPrices",
                keyColumn: "Id",
                keyValue: 2267);

            migrationBuilder.DeleteData(
                table: "FundPrices",
                keyColumn: "Id",
                keyValue: 2268);

            migrationBuilder.DeleteData(
                table: "FundPrices",
                keyColumn: "Id",
                keyValue: 2269);

            migrationBuilder.DeleteData(
                table: "FundPrices",
                keyColumn: "Id",
                keyValue: 2270);

            migrationBuilder.DeleteData(
                table: "FundPrices",
                keyColumn: "Id",
                keyValue: 2271);

            migrationBuilder.DeleteData(
                table: "FundPrices",
                keyColumn: "Id",
                keyValue: 2272);

            migrationBuilder.DeleteData(
                table: "FundPrices",
                keyColumn: "Id",
                keyValue: 2273);

            migrationBuilder.DeleteData(
                table: "FundPrices",
                keyColumn: "Id",
                keyValue: 2274);

            migrationBuilder.DeleteData(
                table: "FundPrices",
                keyColumn: "Id",
                keyValue: 2275);

            migrationBuilder.DeleteData(
                table: "FundPrices",
                keyColumn: "Id",
                keyValue: 2276);

            migrationBuilder.DeleteData(
                table: "FundPrices",
                keyColumn: "Id",
                keyValue: 2277);

            migrationBuilder.DeleteData(
                table: "FundPrices",
                keyColumn: "Id",
                keyValue: 2278);

            migrationBuilder.DeleteData(
                table: "FundPrices",
                keyColumn: "Id",
                keyValue: 2279);

            migrationBuilder.DeleteData(
                table: "FundPrices",
                keyColumn: "Id",
                keyValue: 2280);

            migrationBuilder.DeleteData(
                table: "FundPrices",
                keyColumn: "Id",
                keyValue: 2281);

            migrationBuilder.DeleteData(
                table: "FundPrices",
                keyColumn: "Id",
                keyValue: 2282);

            migrationBuilder.DeleteData(
                table: "FundPrices",
                keyColumn: "Id",
                keyValue: 2283);

            migrationBuilder.DeleteData(
                table: "FundPrices",
                keyColumn: "Id",
                keyValue: 2284);

            migrationBuilder.DeleteData(
                table: "FundPrices",
                keyColumn: "Id",
                keyValue: 2285);

            migrationBuilder.DeleteData(
                table: "FundPrices",
                keyColumn: "Id",
                keyValue: 2286);

            migrationBuilder.DeleteData(
                table: "FundPrices",
                keyColumn: "Id",
                keyValue: 2287);

            migrationBuilder.DeleteData(
                table: "FundPrices",
                keyColumn: "Id",
                keyValue: 2288);

            migrationBuilder.DeleteData(
                table: "FundPrices",
                keyColumn: "Id",
                keyValue: 2289);

            migrationBuilder.DeleteData(
                table: "FundPrices",
                keyColumn: "Id",
                keyValue: 2290);

            migrationBuilder.DeleteData(
                table: "FundPrices",
                keyColumn: "Id",
                keyValue: 2291);

            migrationBuilder.DeleteData(
                table: "FundPrices",
                keyColumn: "Id",
                keyValue: 2292);

            migrationBuilder.DeleteData(
                table: "FundPrices",
                keyColumn: "Id",
                keyValue: 2293);

            migrationBuilder.DeleteData(
                table: "FundPrices",
                keyColumn: "Id",
                keyValue: 2294);

            migrationBuilder.DeleteData(
                table: "FundPrices",
                keyColumn: "Id",
                keyValue: 2295);

            migrationBuilder.DeleteData(
                table: "FundPrices",
                keyColumn: "Id",
                keyValue: 2296);

            migrationBuilder.DeleteData(
                table: "FundPrices",
                keyColumn: "Id",
                keyValue: 2297);

            migrationBuilder.DeleteData(
                table: "FundPrices",
                keyColumn: "Id",
                keyValue: 2298);

            migrationBuilder.DeleteData(
                table: "FundPrices",
                keyColumn: "Id",
                keyValue: 2299);

            migrationBuilder.DeleteData(
                table: "FundPrices",
                keyColumn: "Id",
                keyValue: 2300);

            migrationBuilder.DeleteData(
                table: "FundPrices",
                keyColumn: "Id",
                keyValue: 2301);

            migrationBuilder.DeleteData(
                table: "FundPrices",
                keyColumn: "Id",
                keyValue: 2302);

            migrationBuilder.DeleteData(
                table: "FundPrices",
                keyColumn: "Id",
                keyValue: 2303);

            migrationBuilder.DeleteData(
                table: "FundPrices",
                keyColumn: "Id",
                keyValue: 2304);

            migrationBuilder.DeleteData(
                table: "FundPrices",
                keyColumn: "Id",
                keyValue: 2305);

            migrationBuilder.DeleteData(
                table: "FundPrices",
                keyColumn: "Id",
                keyValue: 2306);

            migrationBuilder.DeleteData(
                table: "FundPrices",
                keyColumn: "Id",
                keyValue: 2307);

            migrationBuilder.DeleteData(
                table: "FundPrices",
                keyColumn: "Id",
                keyValue: 2308);

            migrationBuilder.DeleteData(
                table: "FundPrices",
                keyColumn: "Id",
                keyValue: 2309);

            migrationBuilder.DeleteData(
                table: "FundPrices",
                keyColumn: "Id",
                keyValue: 2310);

            migrationBuilder.DeleteData(
                table: "FundPrices",
                keyColumn: "Id",
                keyValue: 2311);

            migrationBuilder.DeleteData(
                table: "FundPrices",
                keyColumn: "Id",
                keyValue: 2312);

            migrationBuilder.DeleteData(
                table: "FundPrices",
                keyColumn: "Id",
                keyValue: 2313);

            migrationBuilder.DeleteData(
                table: "FundPrices",
                keyColumn: "Id",
                keyValue: 2314);

            migrationBuilder.DeleteData(
                table: "FundPrices",
                keyColumn: "Id",
                keyValue: 2315);

            migrationBuilder.DeleteData(
                table: "FundPrices",
                keyColumn: "Id",
                keyValue: 2316);

            migrationBuilder.DeleteData(
                table: "FundPrices",
                keyColumn: "Id",
                keyValue: 2317);

            migrationBuilder.DeleteData(
                table: "FundPrices",
                keyColumn: "Id",
                keyValue: 2318);

            migrationBuilder.DeleteData(
                table: "FundPrices",
                keyColumn: "Id",
                keyValue: 2319);

            migrationBuilder.DeleteData(
                table: "FundPrices",
                keyColumn: "Id",
                keyValue: 2320);

            migrationBuilder.DeleteData(
                table: "FundPrices",
                keyColumn: "Id",
                keyValue: 2321);

            migrationBuilder.DeleteData(
                table: "FundPrices",
                keyColumn: "Id",
                keyValue: 2322);

            migrationBuilder.DeleteData(
                table: "FundPrices",
                keyColumn: "Id",
                keyValue: 2323);

            migrationBuilder.DeleteData(
                table: "FundPrices",
                keyColumn: "Id",
                keyValue: 2324);

            migrationBuilder.DeleteData(
                table: "FundPrices",
                keyColumn: "Id",
                keyValue: 2325);

            migrationBuilder.DeleteData(
                table: "FundPrices",
                keyColumn: "Id",
                keyValue: 2326);

            migrationBuilder.DeleteData(
                table: "FundPrices",
                keyColumn: "Id",
                keyValue: 2327);

            migrationBuilder.DeleteData(
                table: "FundPrices",
                keyColumn: "Id",
                keyValue: 2328);

            migrationBuilder.DeleteData(
                table: "FundPrices",
                keyColumn: "Id",
                keyValue: 2329);

            migrationBuilder.DeleteData(
                table: "FundPrices",
                keyColumn: "Id",
                keyValue: 2330);

            migrationBuilder.DeleteData(
                table: "FundPrices",
                keyColumn: "Id",
                keyValue: 2331);

            migrationBuilder.DeleteData(
                table: "FundPrices",
                keyColumn: "Id",
                keyValue: 2332);

            migrationBuilder.DeleteData(
                table: "FundPrices",
                keyColumn: "Id",
                keyValue: 2333);

            migrationBuilder.DeleteData(
                table: "FundPrices",
                keyColumn: "Id",
                keyValue: 2334);

            migrationBuilder.DeleteData(
                table: "FundPrices",
                keyColumn: "Id",
                keyValue: 2335);

            migrationBuilder.DeleteData(
                table: "FundPrices",
                keyColumn: "Id",
                keyValue: 2336);

            migrationBuilder.DeleteData(
                table: "FundPrices",
                keyColumn: "Id",
                keyValue: 2337);

            migrationBuilder.DeleteData(
                table: "FundPrices",
                keyColumn: "Id",
                keyValue: 2338);

            migrationBuilder.DeleteData(
                table: "FundPrices",
                keyColumn: "Id",
                keyValue: 2339);

            migrationBuilder.DeleteData(
                table: "FundPrices",
                keyColumn: "Id",
                keyValue: 2340);

            migrationBuilder.DeleteData(
                table: "FundPrices",
                keyColumn: "Id",
                keyValue: 2341);

            migrationBuilder.DeleteData(
                table: "FundPrices",
                keyColumn: "Id",
                keyValue: 2342);

            migrationBuilder.DeleteData(
                table: "FundPrices",
                keyColumn: "Id",
                keyValue: 2343);

            migrationBuilder.DeleteData(
                table: "FundPrices",
                keyColumn: "Id",
                keyValue: 2344);

            migrationBuilder.DeleteData(
                table: "FundPrices",
                keyColumn: "Id",
                keyValue: 2345);

            migrationBuilder.DeleteData(
                table: "FundPrices",
                keyColumn: "Id",
                keyValue: 2346);

            migrationBuilder.DeleteData(
                table: "FundPrices",
                keyColumn: "Id",
                keyValue: 2347);

            migrationBuilder.DeleteData(
                table: "FundPrices",
                keyColumn: "Id",
                keyValue: 2348);

            migrationBuilder.DeleteData(
                table: "FundPrices",
                keyColumn: "Id",
                keyValue: 2349);

            migrationBuilder.DeleteData(
                table: "FundPrices",
                keyColumn: "Id",
                keyValue: 2350);

            migrationBuilder.DeleteData(
                table: "FundPrices",
                keyColumn: "Id",
                keyValue: 2351);

            migrationBuilder.DeleteData(
                table: "FundPrices",
                keyColumn: "Id",
                keyValue: 2352);

            migrationBuilder.DeleteData(
                table: "FundPrices",
                keyColumn: "Id",
                keyValue: 2353);

            migrationBuilder.DeleteData(
                table: "FundPrices",
                keyColumn: "Id",
                keyValue: 2354);

            migrationBuilder.DeleteData(
                table: "FundPrices",
                keyColumn: "Id",
                keyValue: 2355);

            migrationBuilder.DeleteData(
                table: "FundPrices",
                keyColumn: "Id",
                keyValue: 2356);

            migrationBuilder.DeleteData(
                table: "FundPrices",
                keyColumn: "Id",
                keyValue: 2357);

            migrationBuilder.DeleteData(
                table: "FundPrices",
                keyColumn: "Id",
                keyValue: 2358);

            migrationBuilder.DeleteData(
                table: "FundPrices",
                keyColumn: "Id",
                keyValue: 2359);

            migrationBuilder.DeleteData(
                table: "FundPrices",
                keyColumn: "Id",
                keyValue: 2360);

            migrationBuilder.DeleteData(
                table: "FundPrices",
                keyColumn: "Id",
                keyValue: 2361);

            migrationBuilder.DeleteData(
                table: "FundPrices",
                keyColumn: "Id",
                keyValue: 2362);

            migrationBuilder.DeleteData(
                table: "FundPrices",
                keyColumn: "Id",
                keyValue: 2363);

            migrationBuilder.DeleteData(
                table: "FundPrices",
                keyColumn: "Id",
                keyValue: 2364);

            migrationBuilder.DeleteData(
                table: "FundPrices",
                keyColumn: "Id",
                keyValue: 2365);

            migrationBuilder.DeleteData(
                table: "FundPrices",
                keyColumn: "Id",
                keyValue: 2366);

            migrationBuilder.DeleteData(
                table: "FundPrices",
                keyColumn: "Id",
                keyValue: 2367);

            migrationBuilder.DeleteData(
                table: "FundPrices",
                keyColumn: "Id",
                keyValue: 2368);

            migrationBuilder.DeleteData(
                table: "FundPrices",
                keyColumn: "Id",
                keyValue: 2369);

            migrationBuilder.DeleteData(
                table: "FundPrices",
                keyColumn: "Id",
                keyValue: 2370);

            migrationBuilder.DeleteData(
                table: "FundPrices",
                keyColumn: "Id",
                keyValue: 2371);

            migrationBuilder.DeleteData(
                table: "FundPrices",
                keyColumn: "Id",
                keyValue: 2372);

            migrationBuilder.DeleteData(
                table: "FundPrices",
                keyColumn: "Id",
                keyValue: 2373);

            migrationBuilder.DeleteData(
                table: "FundPrices",
                keyColumn: "Id",
                keyValue: 2374);

            migrationBuilder.DeleteData(
                table: "FundPrices",
                keyColumn: "Id",
                keyValue: 2375);

            migrationBuilder.DeleteData(
                table: "FundPrices",
                keyColumn: "Id",
                keyValue: 2376);

            migrationBuilder.DeleteData(
                table: "FundPrices",
                keyColumn: "Id",
                keyValue: 2377);

            migrationBuilder.DeleteData(
                table: "FundPrices",
                keyColumn: "Id",
                keyValue: 2378);

            migrationBuilder.DeleteData(
                table: "FundPrices",
                keyColumn: "Id",
                keyValue: 2379);

            migrationBuilder.DeleteData(
                table: "FundPrices",
                keyColumn: "Id",
                keyValue: 2380);

            migrationBuilder.DeleteData(
                table: "FundPrices",
                keyColumn: "Id",
                keyValue: 2381);

            migrationBuilder.DeleteData(
                table: "FundPrices",
                keyColumn: "Id",
                keyValue: 2382);

            migrationBuilder.DeleteData(
                table: "FundPrices",
                keyColumn: "Id",
                keyValue: 2383);

            migrationBuilder.DeleteData(
                table: "FundPrices",
                keyColumn: "Id",
                keyValue: 2384);

            migrationBuilder.DeleteData(
                table: "FundPrices",
                keyColumn: "Id",
                keyValue: 2385);

            migrationBuilder.DeleteData(
                table: "FundPrices",
                keyColumn: "Id",
                keyValue: 2386);

            migrationBuilder.DeleteData(
                table: "FundPrices",
                keyColumn: "Id",
                keyValue: 2387);

            migrationBuilder.DeleteData(
                table: "FundPrices",
                keyColumn: "Id",
                keyValue: 2388);

            migrationBuilder.DeleteData(
                table: "FundPrices",
                keyColumn: "Id",
                keyValue: 2389);

            migrationBuilder.DeleteData(
                table: "FundPrices",
                keyColumn: "Id",
                keyValue: 2390);

            migrationBuilder.DeleteData(
                table: "FundPrices",
                keyColumn: "Id",
                keyValue: 2391);

            migrationBuilder.DeleteData(
                table: "FundPrices",
                keyColumn: "Id",
                keyValue: 2392);

            migrationBuilder.DeleteData(
                table: "FundPrices",
                keyColumn: "Id",
                keyValue: 2393);

            migrationBuilder.DeleteData(
                table: "FundPrices",
                keyColumn: "Id",
                keyValue: 2394);

            migrationBuilder.DeleteData(
                table: "FundPrices",
                keyColumn: "Id",
                keyValue: 2395);

            migrationBuilder.DeleteData(
                table: "FundPrices",
                keyColumn: "Id",
                keyValue: 2396);

            migrationBuilder.DeleteData(
                table: "FundPrices",
                keyColumn: "Id",
                keyValue: 2397);

            migrationBuilder.DeleteData(
                table: "FundPrices",
                keyColumn: "Id",
                keyValue: 2398);

            migrationBuilder.DeleteData(
                table: "FundPrices",
                keyColumn: "Id",
                keyValue: 2399);

            migrationBuilder.DeleteData(
                table: "FundPrices",
                keyColumn: "Id",
                keyValue: 2400);

            migrationBuilder.DeleteData(
                table: "FundPrices",
                keyColumn: "Id",
                keyValue: 2401);

            migrationBuilder.DeleteData(
                table: "FundPrices",
                keyColumn: "Id",
                keyValue: 2402);

            migrationBuilder.DeleteData(
                table: "FundPrices",
                keyColumn: "Id",
                keyValue: 2403);

            migrationBuilder.DeleteData(
                table: "FundPrices",
                keyColumn: "Id",
                keyValue: 2404);

            migrationBuilder.DeleteData(
                table: "FundPrices",
                keyColumn: "Id",
                keyValue: 2405);

            migrationBuilder.DeleteData(
                table: "FundPrices",
                keyColumn: "Id",
                keyValue: 2406);

            migrationBuilder.DeleteData(
                table: "FundPrices",
                keyColumn: "Id",
                keyValue: 2407);

            migrationBuilder.DeleteData(
                table: "FundPrices",
                keyColumn: "Id",
                keyValue: 2408);

            migrationBuilder.DeleteData(
                table: "FundPrices",
                keyColumn: "Id",
                keyValue: 2409);

            migrationBuilder.DeleteData(
                table: "FundPrices",
                keyColumn: "Id",
                keyValue: 2410);

            migrationBuilder.DeleteData(
                table: "FundPrices",
                keyColumn: "Id",
                keyValue: 2411);

            migrationBuilder.DeleteData(
                table: "FundPrices",
                keyColumn: "Id",
                keyValue: 2412);

            migrationBuilder.DeleteData(
                table: "FundPrices",
                keyColumn: "Id",
                keyValue: 2413);

            migrationBuilder.DeleteData(
                table: "FundPrices",
                keyColumn: "Id",
                keyValue: 2414);

            migrationBuilder.DeleteData(
                table: "FundPrices",
                keyColumn: "Id",
                keyValue: 2415);

            migrationBuilder.DeleteData(
                table: "FundPrices",
                keyColumn: "Id",
                keyValue: 2416);

            migrationBuilder.DeleteData(
                table: "FundPrices",
                keyColumn: "Id",
                keyValue: 2417);

            migrationBuilder.DeleteData(
                table: "FundPrices",
                keyColumn: "Id",
                keyValue: 2418);

            migrationBuilder.DeleteData(
                table: "FundPrices",
                keyColumn: "Id",
                keyValue: 2419);

            migrationBuilder.DeleteData(
                table: "FundPrices",
                keyColumn: "Id",
                keyValue: 2420);

            migrationBuilder.DeleteData(
                table: "FundPrices",
                keyColumn: "Id",
                keyValue: 2421);

            migrationBuilder.DeleteData(
                table: "FundPrices",
                keyColumn: "Id",
                keyValue: 2422);

            migrationBuilder.DeleteData(
                table: "FundPrices",
                keyColumn: "Id",
                keyValue: 2423);

            migrationBuilder.DeleteData(
                table: "FundPrices",
                keyColumn: "Id",
                keyValue: 2424);

            migrationBuilder.DeleteData(
                table: "FundPrices",
                keyColumn: "Id",
                keyValue: 2425);

            migrationBuilder.DeleteData(
                table: "FundPrices",
                keyColumn: "Id",
                keyValue: 2426);

            migrationBuilder.DeleteData(
                table: "FundPrices",
                keyColumn: "Id",
                keyValue: 2427);

            migrationBuilder.DeleteData(
                table: "FundPrices",
                keyColumn: "Id",
                keyValue: 2428);

            migrationBuilder.DeleteData(
                table: "FundPrices",
                keyColumn: "Id",
                keyValue: 2429);

            migrationBuilder.DeleteData(
                table: "FundPrices",
                keyColumn: "Id",
                keyValue: 2430);

            migrationBuilder.DeleteData(
                table: "FundPrices",
                keyColumn: "Id",
                keyValue: 2431);

            migrationBuilder.DeleteData(
                table: "FundPrices",
                keyColumn: "Id",
                keyValue: 2432);

            migrationBuilder.DeleteData(
                table: "FundPrices",
                keyColumn: "Id",
                keyValue: 2433);

            migrationBuilder.DeleteData(
                table: "FundPrices",
                keyColumn: "Id",
                keyValue: 2434);

            migrationBuilder.DeleteData(
                table: "FundPrices",
                keyColumn: "Id",
                keyValue: 2435);

            migrationBuilder.DeleteData(
                table: "FundPrices",
                keyColumn: "Id",
                keyValue: 2436);

            migrationBuilder.DeleteData(
                table: "FundPrices",
                keyColumn: "Id",
                keyValue: 2437);

            migrationBuilder.DeleteData(
                table: "FundPrices",
                keyColumn: "Id",
                keyValue: 2438);

            migrationBuilder.DeleteData(
                table: "FundPrices",
                keyColumn: "Id",
                keyValue: 2439);

            migrationBuilder.DeleteData(
                table: "FundPrices",
                keyColumn: "Id",
                keyValue: 2440);

            migrationBuilder.DeleteData(
                table: "FundPrices",
                keyColumn: "Id",
                keyValue: 2441);

            migrationBuilder.DeleteData(
                table: "FundPrices",
                keyColumn: "Id",
                keyValue: 2442);

            migrationBuilder.DeleteData(
                table: "FundPrices",
                keyColumn: "Id",
                keyValue: 2443);

            migrationBuilder.DeleteData(
                table: "FundPrices",
                keyColumn: "Id",
                keyValue: 2444);

            migrationBuilder.DeleteData(
                table: "FundPrices",
                keyColumn: "Id",
                keyValue: 2445);

            migrationBuilder.DeleteData(
                table: "FundPrices",
                keyColumn: "Id",
                keyValue: 2446);

            migrationBuilder.DeleteData(
                table: "FundPrices",
                keyColumn: "Id",
                keyValue: 2447);

            migrationBuilder.DeleteData(
                table: "FundPrices",
                keyColumn: "Id",
                keyValue: 2448);

            migrationBuilder.DeleteData(
                table: "FundPrices",
                keyColumn: "Id",
                keyValue: 2449);

            migrationBuilder.DeleteData(
                table: "FundPrices",
                keyColumn: "Id",
                keyValue: 2450);

            migrationBuilder.DeleteData(
                table: "FundPrices",
                keyColumn: "Id",
                keyValue: 2451);

            migrationBuilder.DeleteData(
                table: "FundPrices",
                keyColumn: "Id",
                keyValue: 2452);

            migrationBuilder.DeleteData(
                table: "FundPrices",
                keyColumn: "Id",
                keyValue: 2453);

            migrationBuilder.DeleteData(
                table: "FundPrices",
                keyColumn: "Id",
                keyValue: 2454);

            migrationBuilder.DeleteData(
                table: "FundPrices",
                keyColumn: "Id",
                keyValue: 2455);

            migrationBuilder.DeleteData(
                table: "FundPrices",
                keyColumn: "Id",
                keyValue: 2456);

            migrationBuilder.DeleteData(
                table: "FundPrices",
                keyColumn: "Id",
                keyValue: 2457);

            migrationBuilder.DeleteData(
                table: "FundPrices",
                keyColumn: "Id",
                keyValue: 2458);

            migrationBuilder.DeleteData(
                table: "FundPrices",
                keyColumn: "Id",
                keyValue: 2459);

            migrationBuilder.DeleteData(
                table: "FundPrices",
                keyColumn: "Id",
                keyValue: 2460);

            migrationBuilder.DeleteData(
                table: "FundPrices",
                keyColumn: "Id",
                keyValue: 2461);

            migrationBuilder.DeleteData(
                table: "FundPrices",
                keyColumn: "Id",
                keyValue: 2462);

            migrationBuilder.DeleteData(
                table: "FundPrices",
                keyColumn: "Id",
                keyValue: 2463);

            migrationBuilder.DeleteData(
                table: "FundPrices",
                keyColumn: "Id",
                keyValue: 2464);

            migrationBuilder.DeleteData(
                table: "Funds",
                keyColumn: "Id",
                keyValue: 101);

            migrationBuilder.DeleteData(
                table: "Funds",
                keyColumn: "Id",
                keyValue: 102);

            migrationBuilder.DeleteData(
                table: "Funds",
                keyColumn: "Id",
                keyValue: 103);

            migrationBuilder.DeleteData(
                table: "Funds",
                keyColumn: "Id",
                keyValue: 104);

            migrationBuilder.DeleteData(
                table: "Funds",
                keyColumn: "Id",
                keyValue: 105);

            migrationBuilder.DeleteData(
                table: "Funds",
                keyColumn: "Id",
                keyValue: 106);

            migrationBuilder.DeleteData(
                table: "Funds",
                keyColumn: "Id",
                keyValue: 107);

            migrationBuilder.DeleteData(
                table: "Funds",
                keyColumn: "Id",
                keyValue: 108);

            migrationBuilder.DeleteData(
                table: "Funds",
                keyColumn: "Id",
                keyValue: 109);

            migrationBuilder.DeleteData(
                table: "Funds",
                keyColumn: "Id",
                keyValue: 110);

            migrationBuilder.DeleteData(
                table: "Funds",
                keyColumn: "Id",
                keyValue: 111);

            migrationBuilder.DeleteData(
                table: "Funds",
                keyColumn: "Id",
                keyValue: 112);

            migrationBuilder.DeleteData(
                table: "Funds",
                keyColumn: "Id",
                keyValue: 113);

            migrationBuilder.DeleteData(
                table: "Funds",
                keyColumn: "Id",
                keyValue: 114);

            migrationBuilder.DeleteData(
                table: "Funds",
                keyColumn: "Id",
                keyValue: 115);

            migrationBuilder.DropColumn(
                name: "AssetDistribution",
                table: "Funds");

            migrationBuilder.DropColumn(
                name: "InvestorCount",
                table: "Funds");

            migrationBuilder.DropColumn(
                name: "ManagementFee",
                table: "Funds");

            migrationBuilder.DropColumn(
                name: "Risk",
                table: "Funds");

            migrationBuilder.DropColumn(
                name: "TotalValue",
                table: "Funds");

            migrationBuilder.AlterColumn<decimal>(
                name: "Shares",
                table: "PortfolioItems",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,3)",
                oldPrecision: 18,
                oldScale: 3);

            migrationBuilder.AlterColumn<decimal>(
                name: "AverageCost",
                table: "PortfolioItems",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,6)",
                oldPrecision: 18,
                oldScale: 6);

            migrationBuilder.AlterColumn<decimal>(
                name: "Price",
                table: "FundPrices",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,6)",
                oldPrecision: 18,
                oldScale: 6);

            migrationBuilder.InsertData(
                table: "Funds",
                columns: new[] { "Id", "Category", "Code", "IsActive", "Name" },
                values: new object[,]
                {
                    { 1, "", "MAC", true, "Marmara Capital Hisse Senedi Fonu" },
                    { 2, "", "AFT", true, "Ak Portföy Teknoloji Şirketleri Fonu" },
                    { 3, "", "YAF", true, "Yapı Kredi Altın Fonu" },
                    { 4, "", "NNF", true, "Hedef Portföy Birinci Hisse Senedi Fonu" }
                });

            migrationBuilder.InsertData(
                table: "FundPrices",
                columns: new[] { "Id", "ChangeRate", "Date", "FundId", "Price" },
                values: new object[,]
                {
                    { 1, 0m, new DateTime(2026, 6, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 13.00m },
                    { 2, 1.5m, new DateTime(2026, 6, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 13.20m },
                    { 3, 2.2m, new DateTime(2026, 6, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 13.50m },
                    { 4, 1.1m, new DateTime(2026, 7, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 13.65m },
                    { 5, 6.3m, new DateTime(2026, 7, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 14.52m },
                    { 6, 0m, new DateTime(2026, 6, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 26.10m },
                    { 7, 2.6m, new DateTime(2026, 6, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 26.80m },
                    { 8, 2.6m, new DateTime(2026, 6, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 27.50m },
                    { 9, 1.8m, new DateTime(2026, 7, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 28.00m },
                    { 10, 1.0m, new DateTime(2026, 7, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 28.30m }
                });
        }
    }
}
