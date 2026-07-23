namespace FonTakip.API.Models
{
    public class Fund
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public string Code { get; set; } = string.Empty;

        public string Category { get; set; } = "Katılım Fonu";

        public int Risk { get; set; } = 3; // Risk Seviyesi (1 - 7)

        public decimal ManagementFee { get; set; } = 1.5m; // Yıllık Yönetim Ücreti %

        public int InvestorCount { get; set; } = 0; // Toplam Yatırımcı Sayısı

        public decimal TotalValue { get; set; } = 0m; // Toplam Portföy Büyüklüğü (₺)

        public string AssetDistribution { get; set; } = string.Empty; // Varlık / İçerik Dağılımı

        public bool IsActive { get; set; } = true;
        
        public List<FundPrice> Prices { get; set; } = new List<FundPrice>();
    }
}