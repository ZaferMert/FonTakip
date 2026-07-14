namespace FonTakip.API.DTOs
{
    // Sisteme giriş yaparken (Token almak için) bize gönderilecek zarf
    public class UserLoginDto
    {
        public string Username { get; set; } = String.Empty;
        public string Password { get; set; } = string.Empty;
    }
}