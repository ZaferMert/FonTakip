namespace FonTakip.API.Models
{
    public class Fund
    {
        // Fonun veritabanındaki benzersiz kimliği (Primary Key)
        public int Id { get; set; }

        // Fonun tam adı (Örn: Emlak Katılım Birinci Katılım Fonu)
        public string Name { get; set; } = string.Empty;

        // Fonun 3 harfli TEFAS kodu (Örn: EKF)
        public string Code { get; set; } = string.Empty;

        // Fonun kategorisi (Örn: Hisse Senedi, Kıymetli Madenler)
        public string Category { get; set; } = string.Empty;

        // Fonun şu an piyasada aktif işlem görüp görmediği durumu
        public bool IsActive { get; set; } = true;
    }
}