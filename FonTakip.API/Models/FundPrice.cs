namespace FonTakip.API.Models
{
    public class FundPrice
    {
        // Fiyat kaydının benzersiz kimliği
        public int Id { get; set; }

        // HANGİ fona ait olduğunu belirten Yabancı Anahtar (Foreign Key)
        public int FundId { get; set; }

        // O günkü fiyat değeri (Ondalıklı işlemler için decimal kullanılır)
        public decimal Price { get; set; }

        // Fiyatın ait olduğu tarih
        public DateTime Date { get; set; }

        // Bir önceki güne göre değişim oranı (Örn: %1.5 artış)
        public decimal ChangeRate { get; set; }

        // OOP İlişkisi: Bu fiyatın ait olduğu Ana Fon nesnesi (Navigasyon özelliği)
        public Fund? Fund { get; set; }
    }
}