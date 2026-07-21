namespace FonTakip.API.Models
{
    public class Fund
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public string Code { get; set; } = string.Empty;

        public string Category { get; set; } = string.Empty;

        public bool IsActive { get; set; } = true;
        
        public List<FundPrice> Prices { get; set; } = new List<FundPrice>();
    }
}