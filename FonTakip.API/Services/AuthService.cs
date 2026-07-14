using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using FonTakip.API.Data;
using FonTakip.API.DTOs;
using FonTakip.API.Models;
using Microsoft.IdentityModel.Tokens;

namespace FonTakip.API.Services
{
    // Güvenlik Merkezi: Kayıt ve Giriş işlemlerinin mantığı burada çalışır
    public class AuthService
    {
        // Veritabanına (Kiler) erişim köprümüz
        private readonly AppDbContext _context;
        private readonly IConfiguration _configuration; // 1. YENİ EKLENEN

        // 2. YENİ EKLENEN: Parantez içine IConfiguration configuration yazıldı
        public AuthService(AppDbContext context, IConfiguration configuration) 
        {
            _context = context;
            _configuration = configuration; // 3. YENİ EKLENEN
        }

        // 1. KAYIT OLMA OPERASYONU
        public void Register(UserRegisterDto request)
        {
            // Adım 1: Dışarıdan gelen "12345" şifresini BCrypt makinesine atıp kriptoluyoruz
            string passwordHash = BCrypt.Net.BCrypt.HashPassword(request.Password);

            // Adım 2: Veritabanına kaydedilecek gerçek User (Kullanıcı) nesnesini oluşturuyoruz
            var newUser = new User
            {
                Username = request.Username,
                PasswordHash = passwordHash, // Açık şifreyi DEĞİL, kriptolu şifreyi veriyoruz
                Role = "User" // Kayıt olan herkese standart olarak 'User' yetkisi veriyoruz
            };

            // Adım 3: Kullanıcıyı veritabanına ekle ve kaydet
            _context.Users.Add(newUser);
            _context.SaveChanges();
        }

        // 2. GİRİŞ YAPMA OPERASYONU
        public string Login(UserLoginDto request)
        {
            var user = _context.Users.FirstOrDefault(u => u.Username == request.Username);

            if (user == null)
            {
                throw new Exception("Kullanıcı bulunamadı!");
            }

            bool isPasswordValid = BCrypt.Net.BCrypt.Verify(request.Password, user.PasswordHash);

            if (isPasswordValid == false)
            {
                throw new Exception("Şifre hatalı!");
            }

            return CreateToken(user);
        }

        // YAKA KARTI BASIM MAKİNESİ (Sadece bu sınıfın içinde kullanılabilir)
        private string CreateToken(User user)
        {
            // 1. Token'ın içine koyacağımız bilgiler (Kullanıcı adı ve Rolü)
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.Username),
                new Claim(ClaimTypes.Role, user.Role)
            };

            // 2. appsettings.json'dan gizli anahtarımızı çekip dijital bir kilit oluşturuyoruz
            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(_configuration["JwtSettings:SecretKey"]!));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature);

            // 3. Token'ın üretim ayarları (Kimden, Kime, Ne zamana kadar geçerli?)
            var token = new JwtSecurityToken(
                issuer: _configuration["JwtSettings:Issuer"],
                audience: _configuration["JwtSettings:Audience"],
                claims: claims,
                expires: DateTime.Now.AddDays(1), // Kartın geçerlilik süresi 1 Gün
                signingCredentials: creds
            );

            // 4. Token'ı şifreli bir metne çevirip teslim ediyoruz
            var jwt = new System.IdentityModel.Tokens.Jwt.JwtSecurityTokenHandler().WriteToken(token);
            return jwt;
        }
    }
}