namespace FonTakip.API.Models
{
    public class User
    {
        // Kullanıcının benzersiz kimliği
        public int Id { get; set; }

        // Kullanıcının adı
        public string FirstName { get; set; } = string.Empty;

        // Kullanıcının soyadı
        public string LastName { get; set; } = string.Empty;

        // Sisteme giriş için kullanılacak e-posta adresi
        public string Email { get; set; } = string.Empty;

        // Güvenlik için şifrenin gizlenmiş (hashlenmiş) hali
        public string PasswordHash { get; set; } = string.Empty;

        // Kullanıcının sistemde aktif olup olmadığı
        public bool IsActive { get; set; } = true;
    }
}