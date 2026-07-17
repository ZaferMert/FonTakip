using System.Security.Claims;
using FonTakip.API.Data;
using FonTakip.API.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FonTakip.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize] // Bu sınıftaki işlemleri sadece giriş yapmış (token'ı olan) kullanıcılar yapabilir
    public class FavoritesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public FavoritesController(AppDbContext context)
        {
            _context = context;
        }

        // 1. GET: /api/favorites
        // Kullanıcının favoriye aldığı fonların SADECE ID'lerini liste olarak döner. 
        // (UI tarafında hangi kalplerin dolu olacağını bilmek için bu yeterlidir)
        [HttpGet]
        public async Task<IActionResult> GetFavorites()
        {
            // JWT Token içinden kullanıcının ID'sini yakalıyoruz
            var userIdStr = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (string.IsNullOrEmpty(userIdStr)) return Unauthorized();
            
            int userId = int.Parse(userIdStr);

            var favoriteFundIds = await _context.UserFavorites
                .Where(uf => uf.UserId == userId)
                .Select(uf => uf.FundId)
                .ToListAsync();

            return Ok(favoriteFundIds);
        }

        // 2. POST: /api/favorites/{fundId}
        // Kalp ikonuna basıldığında tetiklenir. Fon favorilerdeyse siler, değilse ekler (Toggle mantığı).
        [HttpPost("{fundId}")]
        public async Task<IActionResult> ToggleFavorite(int fundId)
        {
            var userIdStr = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (string.IsNullOrEmpty(userIdStr)) return Unauthorized();

            int userId = int.Parse(userIdStr);

            // Bu kullanıcı bu fonu daha önce favoriye eklemiş mi diye veritabanına bak
            var existingFavorite = await _context.UserFavorites
                .FirstOrDefaultAsync(uf => uf.UserId == userId && uf.FundId == fundId);

            if (existingFavorite != null)
            {
                // Zaten favorilerdeyse, tablodan sil (Kalbi boşalt)
                _context.UserFavorites.Remove(existingFavorite);
                await _context.SaveChangesAsync();
                
                return Ok(new { message = "Fon favorilerden çıkarıldı.", isFavorite = false });
            }
            else
            {
                // Favorilerde yoksa, tabloya yeni kayıt olarak ekle (Kalbi doldur)
                var newFavorite = new UserFavorite
                {
                    UserId = userId,
                    FundId = fundId
                };
                
                _context.UserFavorites.Add(newFavorite);
                await _context.SaveChangesAsync();
                
                return Ok(new { message = "Fon favorilere eklendi.", isFavorite = true });
            }
        }
    }
}