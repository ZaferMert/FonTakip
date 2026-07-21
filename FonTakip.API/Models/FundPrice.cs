namespace FonTakip.API.Models
{
    public class FundPrice
    {
        public int Id { get; set; }

        public int FundId { get; set; }

        public decimal Price { get; set; }

        public DateTime Date { get; set; }

        public decimal ChangeRate { get; set; }

        public Fund? Fund { get; set; }
    }
}