using Microsoft.EntityFrameworkCore;
using FonTakip.API.Models;

namespace FonTakip.API.Data
{
    // Sınıfımızın EF Core'un DbContext altyapısından miras almasını sağlıyoruz
    public class AppDbContext : DbContext
    {
        // Constructor: Proje başlarken veritabanı ayarlarını (şifre, port vb.) içeri almamızı sağlar
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        // C# modellerimizi SQL Server'daki fiziksel tablolara eşleyen köprüler
        public DbSet<Fund> Funds { get; set; }
        public DbSet<FundPrice> FundPrices { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Bire-Çok (One-to-Many) İlişkinin C# dilinde kurumsal tanımı:
            modelBuilder.Entity<FundPrice>()
                .HasOne(fp => fp.Fund)          // Bir fiyatın TEK BİR fonu vardır.
                .WithMany(f => f.Prices)        // Bir fonun BİRDEN ÇOK fiyatı olabilir.
                .HasForeignKey(fp => fp.FundId); // Aralarındaki bağlantı köprüsü "FundId" numarasıdır.

            base.OnModelCreating(modelBuilder);
        }
    }
}