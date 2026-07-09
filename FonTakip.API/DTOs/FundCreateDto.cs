namespace FonTakip.API.DTOs
{
    public class FundCreateDto
    {
        // Fon eklerken Id istemeyiz, çünkü Id'yi SQL otomatik verir.
        // IsActive durumunu da istemeyiz, yeni eklenen fon zaten varsayılan olarak aktiftir.
        
        public string Name { get; set; } = string.Empty;
        public string Code { get; set; } = string.Empty;
        public string Category { get; set; } = string.Empty;
    }
}