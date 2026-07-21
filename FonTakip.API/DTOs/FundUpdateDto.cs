namespace FonTakip.API.DTOs
{
    public class FundUpdateDto
    {
        public string Name { get; set; } = string.Empty;
        public string Code { get; set; } = string.Empty;
        public string Category { get; set; } = string.Empty;
        public bool IsActive { get; set; }
    }
}