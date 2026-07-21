namespace FonTakip.API.Models
{
    public class UserFavorite
    {
        public int Id { get; set; }
        
        public int UserId { get; set; }

        public User User { get; set; } = null!;

        public int FundId { get; set; }

        public Fund Fund { get; set; } = null!;

        public DateTime AddedAt { get; set; } = DateTime.UtcNow;
    }
}