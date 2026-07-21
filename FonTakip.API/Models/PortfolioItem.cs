using System.ComponentModel.DataAnnotations;

namespace FonTakip.API.Models
{
    public class PortfolioItem
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string UserId { get; set; } = string.Empty; 

        [Required]
        public int FundId { get; set; }
        
        public Fund Fund { get; set; } = null!;

        [Required]
        public decimal Shares { get; set; }

        public decimal AverageCost { get; set; }
    }
}