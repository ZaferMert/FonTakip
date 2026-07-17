using FonTakip.API.Models;
using Microsoft.EntityFrameworkCore;

namespace FonTakip.API.Data 
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Fund> Funds { get; set; }
        public DbSet<User> Users { get; set; }
        // Unuttuğumuz tabloyu geri ekliyoruz:
        public DbSet<FundPrice> FundPrices { get; set; } 
        // Yeni tablomuz:
        public DbSet<UserFavorite> UserFavorites { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // ÖN YÜZDEKİ VERİLERİ VERİTABANINA SABİTLİYORUZ
            // Sadece sabit verileri (Id, Code, Name) veritabanına ekliyoruz.
            modelBuilder.Entity<Fund>().HasData(
                new Fund { Id = 1, Code = "MAC", Name = "Marmara Capital Hisse Senedi Fonu" },
                new Fund { Id = 2, Code = "AFT", Name = "Ak Portföy Teknoloji Şirketleri Fonu" },
                new Fund { Id = 3, Code = "YAF", Name = "Yapı Kredi Altın Fonu" },
                new Fund { Id = 4, Code = "NNF", Name = "Hedef Portföy Birinci Hisse Senedi Fonu" }
            );
        }
    }
}