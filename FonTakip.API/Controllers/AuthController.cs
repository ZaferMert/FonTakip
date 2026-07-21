using Microsoft.AspNetCore.Mvc;
using FonTakip.API.DTOs;
using FonTakip.API.Services;

namespace FonTakip.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly AuthService _authService;

        public AuthController(AuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("register")]
        public IActionResult Register(UserRegisterDto request)
        {
            _authService.Register(request);
            return Ok("Kayıt işlemi başarıyla tamamlandı.");
        }

        [HttpPost("login")]
        public IActionResult Login(UserLoginDto request)
        {
            var token = _authService.Login(request); 

            return Ok(token); 
        }
    }
}