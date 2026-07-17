namespace FonTakip.API.Models
{
    public class UserFavorite
    {
        // Hangi kullanıcı?
        public int Id { get; set; }
        public int UserId { get; set; }
        public User User { get; set; } = null!;

        // Hangi fonu favoriye aldı?
        public int FundId { get; set; }
        public Fund Fund { get; set; } = null!;

        // Ne zaman favoriye eklendi?
        public DateTime AddedAt { get; set; } = DateTime.UtcNow;
    }
}