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

            // --- 1. DECIMAL HASSASİYET AYARLARI (Sarı uyarıları çözen kısım) ---
            modelBuilder.Entity<FundPrice>()
                .Property(f => f.Price)
                .HasPrecision(18, 6);

            modelBuilder.Entity<FundPrice>()
                .Property(f => f.ChangeRate)
                .HasPrecision(18, 2);

            modelBuilder.Entity<PortfolioItem>()
                .Property(p => p.AverageCost)
                .HasPrecision(18, 6);

            modelBuilder.Entity<PortfolioItem>()
                .Property(p => p.Shares)
                .HasPrecision(18, 3);
            // -------------------------------------------------------------------

            // --- 2. ÖN YÜZDEKİ VERİLERİ VERİTABANINA SABİTLİYORUZ (Senin Kodların) ---
            modelBuilder.Entity<Fund>().HasData(
                new Fund { Id = 1, Code = "MAC", Name = "Marmara Capital Hisse Senedi Fonu" },
                new Fund { Id = 2, Code = "AFT", Name = "Ak Portföy Teknoloji Şirketleri Fonu" },
                new Fund { Id = 3, Code = "YAF", Name = "Yapı Kredi Altın Fonu" },
                new Fund { Id = 4, Code = "NNF", Name = "Hedef Portföy Birinci Hisse Senedi Fonu" }
            );

            // MAC Fonu (Id = 1) için geçmiş 1 aylık test fiyatları
            modelBuilder.Entity<FundPrice>().HasData(
                new FundPrice { Id = 1, FundId = 1, Date = new DateTime(2026, 6, 14), Price = 13.00m, ChangeRate = 0 },
                new FundPrice { Id = 2, FundId = 1, Date = new DateTime(2026, 6, 21), Price = 13.20m, ChangeRate = 1.5m },
                new FundPrice { Id = 3, FundId = 1, Date = new DateTime(2026, 6, 28), Price = 13.50m, ChangeRate = 2.2m },
                new FundPrice { Id = 4, FundId = 1, Date = new DateTime(2026, 7, 5), Price = 13.65m, ChangeRate = 1.1m },
                new FundPrice { Id = 5, FundId = 1, Date = new DateTime(2026, 7, 14), Price = 14.52m, ChangeRate = 6.3m }
            );

            // AFT Fonu (Id = 2) için geçmiş 1 aylık test fiyatları
            modelBuilder.Entity<FundPrice>().HasData(
                new FundPrice { Id = 6, FundId = 2, Date = new DateTime(2026, 6, 14), Price = 26.10m, ChangeRate = 0 },
                new FundPrice { Id = 7, FundId = 2, Date = new DateTime(2026, 6, 21), Price = 26.80m, ChangeRate = 2.6m },
                new FundPrice { Id = 8, FundId = 2, Date = new DateTime(2026, 6, 28), Price = 27.50m, ChangeRate = 2.6m },
                new FundPrice { Id = 9, FundId = 2, Date = new DateTime(2026, 7, 5), Price = 28.00m, ChangeRate = 1.8m },
                new FundPrice { Id = 10, FundId = 2, Date = new DateTime(2026, 7, 14), Price = 28.30m, ChangeRate = 1.0m }
            );
        }
    }
}