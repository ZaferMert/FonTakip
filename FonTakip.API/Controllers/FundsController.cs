using Microsoft.AspNetCore.Mvc;
using FonTakip.API.Data;
using FonTakip.API.Models;
using FonTakip.API.DTOs;
using FonTakip.API.Services;
using Microsoft.AspNetCore.Authorization;

namespace FonTakip.API.Controllers
{
    // Sisteme bunun bir API kapısı olduğunu ve adresinin "api/funds" olacağını söylüyoruz
    [Route("api/[controller]")]
    [ApiController]
    public class FundsController : ControllerBase
    {
        // Artık veritabanı yok, Servis var!
        private readonly FundService _fundService;
        // private readonly AppDbContext _context;

        public FundsController(FundService fundService, AppDbContext context)
        {
            _fundService = fundService;
            // _context = context;
        }

        // 1. GET: Tüm fonları listeleme kapısı
        [HttpGet]
        public IActionResult GetFunds()
        {
           var funds = _fundService.GetAllFunds();

           return Ok(funds);
        }

        // 2. GET: Kategoriye göre fonları filtreleme kapısı
        // URL örneği: GET /api/funds/category/Hisse
        [HttpGet("category/{categoryName}")]
        public IActionResult GetByCategory(string categoryName)
        {
            var funds = _fundService.GetFundsByCategory(categoryName);

            return Ok(funds);
        }

        // 2. POST: Yeni fon ekleme kapısı
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public IActionResult CreateFund([FromBody] FundCreateDto request)
        {
            // Dışarıdan gelen garsonu (DTO), mutfağın anladığı dile (Entity) çeviriyoruz.
            var newFund = new Fund
            {
                Name = request.Name,
                Code = request.Code,
                Category = request.Category,
                IsActive = true // Yeni eklenen bir fon varsayılan olarak aktiftir.
            };

            _fundService.AddFund(newFund);

            return Ok("Fon başarıyla eklendi.");
        }

        // 3. PUT: Mevcut bir fonu güncelleme kapısı
        [HttpPut("{id}")] // Adres örn: api/funds/1 (1 nolu fonu güncelle demek)
        public IActionResult UpdateFund(int id, [FromBody] FundUpdateDto request)
        {
            // 1. Veritabanına gidip bu ID'ye sahip fonu arıyoruz
            var existingFund = _fundService.GetFundById(id);

            // Eğer veritabanında böyle bir fon yoksa 404 Hatası dönüyoruz
            if (existingFund == null)
            {
                return NotFound("Güncellenmek istenen fon bulunamadı.");
            }
            
            existingFund.Name = request.Name;
            existingFund.Code = request.Code;
            existingFund.Category = request.Category;
            existingFund.IsActive = request.IsActive;

            // 2. Değişiklikleri SQL Server'a kaydet
            _fundService.UpdateFund(existingFund);

            return Ok("Fon başarıyla güncellendi.");
        }

        // 4. DELETE: Bir fonu pasife çekme (Soft Delete) kapısı
        [HttpDelete("{id}")]
        public IActionResult DeleteFund(int id)
        {
            var existingFund = _fundService.GetFundById(id);

            if (existingFund == null)
            {
                return NotFound("Silinmek istenen fon bulunamadı.");
            }

            _fundService.DeleteFund(existingFund);

            return Ok("Fon başarıyla silindi.");
        }

        // 5. POST: Bir fona yeni fiyat ekleme kapısı
        // Adres Örneği: POST /api/funds/5/prices (5 numaralı fona fiyat ekle)
        [HttpPost("{fundId}/prices")]
        public IActionResult AddPrice(int fundId, [FromBody] FundPriceCreateDto request)
        {
            _fundService.AddPriceToFund(fundId, request.Price);

            return Ok("Fiyat başarıyla eklendi.");
        }
    }
}