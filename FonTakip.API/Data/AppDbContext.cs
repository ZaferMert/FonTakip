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
    }
}