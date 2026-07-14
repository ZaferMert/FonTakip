namespace FonTakip.API.DTOs
{
    // Dışarıdan yeni kayıt olurken bize gelecek olan güvenli zarf
    public class UserRegisterDto
    {
        public string Username { get; set; } = string.Empty;
        
        // Kullanıcının dışarıdan gireceği açık şifre (Bunu serviste kriptolayacağız)
        public string Password { get; set; } = string.Empty;
    }
}