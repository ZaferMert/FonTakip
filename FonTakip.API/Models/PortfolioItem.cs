using System.ComponentModel.DataAnnotations;

namespace FonTakip.API.Models // HATA BURADAYDI: .API eklendi
{
    public class PortfolioItem
    {
        [Key]
        public int Id { get; set; }

        [Required]
        // SARI UYARI ÇÖZÜMÜ: = string.Empty; eklendi
        public string UserId { get; set; } = string.Empty; 

        [Required]
        public int FundId { get; set; }
        
        // Artık aynı isim alanında oldukları için Fund modelini hatasız tanıyacak
        public Fund Fund { get; set; } = null!;

        [Required]
        public decimal Shares { get; set; }

        public decimal AverageCost { get; set; }
    }
}