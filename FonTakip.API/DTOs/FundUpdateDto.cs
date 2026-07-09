namespace FonTakip.API.DTOs
{
    public class FundUpdateDto
    {
        // Güncellenecek fona ait yeni bilgileri taşıyacak
        public string Name { get; set; } = string.Empty;
        public string Code { get; set; } = string.Empty;
        public string Category { get; set; } = string.Empty;
        public bool IsActive { get; set; } // Fonu aktife/pasife çekebilmek için bunu da ekledik
    }
}