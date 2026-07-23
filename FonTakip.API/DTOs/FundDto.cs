namespace FonTakip.API.DTOs
{
    public class FundDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Code { get; set; } = string.Empty;
        public string Category { get; set; } = string.Empty;
        public int Risk { get; set; } = 3;
        public decimal ManagementFee { get; set; } = 1.5m;
        public int InvestorCount { get; set; } = 0;
        public decimal TotalValue { get; set; } = 0m;
        public string AssetDistribution { get; set; } = string.Empty;
        public bool IsActive { get; set; } = true;
    }
}