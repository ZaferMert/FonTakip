namespace FonTakip.API.Models
{
    // Güvenlik Şefinin müşteriye vereceği standart yanıt şablonu
    public class ErrorResult
    {
        public int StatusCode { get; set; } // Hata kodu (Örn: 500)
        public string Message { get; set; } = string.Empty; // Kibar mesajımız
    }
}