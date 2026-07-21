using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using FonTakip.API.Data;
using FonTakip.API.DTOs;
using FonTakip.API.Models;
using Microsoft.IdentityModel.Tokens;

namespace FonTakip.API.Services
{
    public class AuthService
    {
        private readonly AppDbContext _context;
        private readonly IConfiguration _configuration;

        public AuthService(AppDbContext context, IConfiguration configuration) 
        {
            _context = context;
            _configuration = configuration;
        }

        // 1. KAYIT OLMA OPERASYONU
        public void Register(UserRegisterDto request)
        {
            string passwordHash = BCrypt.Net.BCrypt.HashPassword(request.Password);

            var newUser = new User
            {
                FullName = request.FullName,
                Email = request.Email,
                PasswordHash = passwordHash,
                Role = "User" 
            };

            _context.Users.Add(newUser);
            _context.SaveChanges();
        }

        // 2. GİRİŞ YAPMA OPERASYONU
        public string Login(UserLoginDto request)
        {
            var user = _context.Users.FirstOrDefault(u => u.Email == request.Email);

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

        private string CreateToken(User user)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.Name, user.FullName),
                new Claim(ClaimTypes.Role, user.Role)
            };

            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(_configuration["JwtSettings:SecretKey"]!));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature);

            var token = new JwtSecurityToken(
                issuer: _configuration["JwtSettings:Issuer"],
                audience: _configuration["JwtSettings:Audience"],
                claims: claims,
                expires: DateTime.Now.AddDays(1),
                signingCredentials: creds
            );

            var jwt = new System.IdentityModel.Tokens.Jwt.JwtSecurityTokenHandler().WriteToken(token);
            return jwt;
        }
    }
}