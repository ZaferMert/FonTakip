using Microsoft.AspNetCore.Mvc;
using FonTakip.API.DTOs;
using FonTakip.API.Services;

namespace FonTakip.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        // 1. Kapıdaki garsonun, içerideki güvenlik şefini (AuthService) tanıması lazım
        private readonly AuthService _authService;

        public AuthController(AuthService authService)
        {
            _authService = authService;
        }

        // 2. DIŞARIDAN KAYIT OLMA KAPISI (POST /api/auth/register)
        [HttpPost("register")]
        public IActionResult Register(UserRegisterDto request)
        {
            _authService.Register(request); // Çantayı şefe veriyoruz
            return Ok("Kayıt işlemi başarıyla tamamlandı."); // Müşteriye olumlu yanıt dönüyoruz
        }

        // 3. DIŞARIDAN GİRİŞ YAPMA KAPISI (POST /api/auth/login)
        [HttpPost("login")]
        public IActionResult Login(UserLoginDto request)
        {
            // Şef çantayı kontrol ediyor, her şey doğruysa dijital yaka kartını (Token) üretiyor
            var token = _authService.Login(request); 
            
            // Üretilen bu şifreli kartı müşteriye (Swagger'a) teslim ediyoruz
            return Ok(token); 
        }
    }
}