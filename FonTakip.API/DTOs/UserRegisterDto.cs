namespace FonTakip.API.DTOs
{
    // Dışarıdan yeni kayıt olurken bize gelecek olan güvenli zarf
    public class UserRegisterDto
{
    public string FullName { get; set; } = string.Empty;

    public string Email { get; set; } = string.Empty;

    public string Password { get; set; } = string.Empty;
}
}