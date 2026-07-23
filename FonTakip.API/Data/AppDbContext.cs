using FonTakip.API.Models;
using Microsoft.EntityFrameworkCore;

namespace FonTakip.API.Data 
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Fund> Funds { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<FundPrice> FundPrices { get; set; } 
        public DbSet<UserFavorite> UserFavorites { get; set; }
        public DbSet<PortfolioItem> PortfolioItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // --- 1. DECIMAL HASSASİYET AYARLARI ---
            modelBuilder.Entity<FundPrice>()
                .Property(f => f.Price)
                .HasPrecision(18, 6);

            modelBuilder.Entity<FundPrice>()
                .Property(f => f.ChangeRate)
                .HasPrecision(18, 2);

            modelBuilder.Entity<Fund>()
                .Property(f => f.ManagementFee)
                .HasPrecision(18, 2);

            modelBuilder.Entity<Fund>()
                .Property(f => f.TotalValue)
                .HasPrecision(18, 2);

            modelBuilder.Entity<PortfolioItem>()
                .Property(p => p.AverageCost)
                .HasPrecision(18, 6);

            modelBuilder.Entity<PortfolioItem>()
                .Property(p => p.Shares)
                .HasPrecision(18, 3);

            // --- 2. TEFAS KAPSAMLI CANLI KATILIM & PİYASA FONLARI VERİ KÜMESİ ---
            var seedFunds = new List<Fund>
            {
                new Fund { Id = 101, Code = "KFA", Name = "Emlak Katılım Birinci Hisse Senedi Katılım Fonu", Category = "Katılım Fonu", Risk = 6, ManagementFee = 2.10m, InvestorCount = 18450, TotalValue = 850400000.00m, AssetDistribution = "%85 Katılım Hisse, %15 Kira Sertifikası" },
                new Fund { Id = 102, Code = "KMT", Name = "Emlak Katılım Katılım Fonu", Category = "Katılım Fonu", Risk = 3, ManagementFee = 1.50m, InvestorCount = 12300, TotalValue = 420100000.00m, AssetDistribution = "%70 Kira Sertifikası, %30 Katılma Hesabı" },
                new Fund { Id = 103, Code = "KPE", Name = "Emlak Katılım Para Piyasası Katılım Fonu", Category = "Para Piyasası", Risk = 1, ManagementFee = 0.90m, InvestorCount = 25100, TotalValue = 1250000000.00m, AssetDistribution = "%90 Katılma Hesabı, %10 Altın" },
                new Fund { Id = 104, Code = "ZPC", Name = "Ziraat Portföy Katılım Fonu", Category = "Katılım Fonu", Risk = 4, ManagementFee = 1.75m, InvestorCount = 9800, TotalValue = 310500000.00m, AssetDistribution = "%80 Kira Sertifikası, %20 Hisse" },
                new Fund { Id = 105, Code = "ZPF", Name = "Ziraat Portföy Altın Katılım Fonu", Category = "Kıymetli Maden", Risk = 5, ManagementFee = 1.80m, InvestorCount = 31200, TotalValue = 980300000.00m, AssetDistribution = "%95 Altın / Kıymetli Maden, %5 Nakit" },
                new Fund { Id = 106, Code = "TFX", Name = "Türkiye Finans Katılım Fonu", Category = "Katılım Fonu", Risk = 3, ManagementFee = 1.60m, InvestorCount = 14200, TotalValue = 510000000.00m, AssetDistribution = "%65 Kira Sertifikası, %35 Sukuk" },
                new Fund { Id = 107, Code = "MPS", Name = "Albaraka Portföy Katılım Fonu", Category = "Katılım Fonu", Risk = 5, ManagementFee = 1.95m, InvestorCount = 8700, TotalValue = 290800000.00m, AssetDistribution = "%75 Hisse Senedi, %25 Kira Sertifikası" },
                new Fund { Id = 108, Code = "KDV", Name = "Kuveyt Türk Portföy Katılım Fonu", Category = "Katılım Fonu", Risk = 4, ManagementFee = 1.70m, InvestorCount = 11500, TotalValue = 480200000.00m, AssetDistribution = "%60 Kira Sertifikası, %40 Katılma Hesabı" },
                new Fund { Id = 109, Code = "AAK", Name = "Ata Portföy Katılım Fonu", Category = "Katılım Fonu", Risk = 4, ManagementFee = 1.85m, InvestorCount = 6400, TotalValue = 195000000.00m, AssetDistribution = "%70 Hisse, %30 Sukuk" },
                new Fund { Id = 110, Code = "VKK", Name = "Vakıf Katılım Birinci Katılım Fonu", Category = "Katılım Fonu", Risk = 3, ManagementFee = 1.45m, InvestorCount = 15600, TotalValue = 620000000.00m, AssetDistribution = "%75 Kira Sertifikası, %25 Katılma Hesabı" },
                new Fund { Id = 111, Code = "MAC", Name = "Marmara Capital Portföy Hisse Senedi Fonu", Category = "Hisse Senedi", Risk = 6, ManagementFee = 2.20m, InvestorCount = 42100, TotalValue = 1850000000.00m, AssetDistribution = "%92 BIST Hisse, %8 VIOP Teminat" },
                new Fund { Id = 112, Code = "AFT", Name = "Ak Portföy Amerika Yabancı Hisse Senedi Fonu", Category = "Teknoloji", Risk = 7, ManagementFee = 2.90m, InvestorCount = 89000, TotalValue = 3450000000.00m, AssetDistribution = "%95 Yabancı Teknoloji Hisse, %5 Dövüz" },
                new Fund { Id = 113, Code = "YAF", Name = "Yapı Kredi Portföy Altın Fonu", Category = "Kıymetli Maden", Risk = 5, ManagementFee = 1.75m, InvestorCount = 54000, TotalValue = 2100000000.00m, AssetDistribution = "%98 Altın Sertifikası / Ons, %2 Nakit" },
                new Fund { Id = 114, Code = "NNF", Name = "Hedef Portföy Birinci Hisse Senedi Fonu", Category = "Hisse Senedi", Risk = 6, ManagementFee = 2.50m, InvestorCount = 38000, TotalValue = 1420000000.00m, AssetDistribution = "%90 Hisse Senedi, %10 Nakit" },
                new Fund { Id = 115, Code = "TI3", Name = "İş Portföy BIST 100 Dışı Şirketler Fonu", Category = "Hisse Senedi", Risk = 6, ManagementFee = 2.30m, InvestorCount = 27500, TotalValue = 990000000.00m, AssetDistribution = "%94 Yan Tahta Hisse, %6 Mevduat" }
            };

            modelBuilder.Entity<Fund>().HasData(seedFunds);

            // 30 Günlük Fiyat Geçmişi Oluştur
            var seedPrices = new List<FundPrice>();
            int priceIdCounter = 2000;
            var startDate = new DateTime(2026, 6, 23);

            foreach (var fund in seedFunds)
            {
                decimal currentP = fund.Id switch {
                    101 => 35.379226m,
                    102 => 26.699414m,
                    103 => 14.570422m,
                    104 => 27.643216m,
                    105 => 30.391777m,
                    106 => 32.606827m,
                    107 => 30.391777m,
                    108 => 19.513986m,
                    109 => 30.613375m,
                    110 => 22.450000m,
                    111 => 18.452000m,
                    112 => 45.300000m,
                    113 => 115.800000m,
                    114 => 12.400000m,
                    115 => 8.950000m,
                    _ => 15.00m
                };

                for (int day = 0; day <= 30; day++)
                {
                    var pDate = startDate.AddDays(day);
                    double trendFactor = 1.0 + ((day - 15) * 0.004) + ((fund.Id % 5 - 2) * 0.002);
                    decimal pVal = Math.Round(currentP * (decimal)trendFactor, 6);
                    decimal change = day > 0 ? Math.Round((decimal)((trendFactor - 1.0) * 100), 2) : 0m;

                    seedPrices.Add(new FundPrice
                    {
                        Id = priceIdCounter++,
                        FundId = fund.Id,
                        Date = pDate,
                        Price = pVal,
                        ChangeRate = change
                    });
                }
            }

            modelBuilder.Entity<FundPrice>().HasData(seedPrices);
        }
    }
}