namespace FonTakip.API.Models
{
    public class User
    {
        public int Id { get; set; }
        
        // Username'i tamamen kaldırdık.
        public string Role { get; set; } = string.Empty; 

        // Frontend'deki (React) formData.fullName ile eşleşmesi için birleştirdik:
        public string FullName { get; set; } = string.Empty; 
        
        public string Email { get; set; } = string.Empty;
        public string PasswordHash { get; set; } = string.Empty;
        public bool IsActive { get; set; } = true;
    }
}