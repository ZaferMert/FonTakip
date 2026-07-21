using Microsoft.AspNetCore.Mvc;
using FonTakip.API.Data;
using FonTakip.API.Models;
using FonTakip.API.DTOs;
using FonTakip.API.Services;
using Microsoft.AspNetCore.Authorization;
using System.Globalization;

namespace FonTakip.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FundsController : ControllerBase
    {
        private readonly FundService _fundService;

        public FundsController(FundService fundService, AppDbContext context)
        {
            _fundService = fundService;
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
        [Authorize]
        public IActionResult CreateFund([FromBody] FundCreateDto request)
        {
            var newFund = new Fund
            {
                Name = request.Name,
                Code = request.Code,
                Category = request.Category,
                IsActive = true
            };

            _fundService.AddFund(newFund);

            return Ok("Fon başarıyla eklendi.");
        }

        // 3. PUT: Mevcut bir fonu güncelleme kapısı
        [HttpPut("{id}")]
        public IActionResult UpdateFund(int id, [FromBody] FundUpdateDto request)
        {
            var existingFund = _fundService.GetFundById(id);

            if (existingFund == null)
            {
                return NotFound("Güncellenmek istenen fon bulunamadı.");
            }
            
            existingFund.Name = request.Name;
            existingFund.Code = request.Code;
            existingFund.Category = request.Category;
            existingFund.IsActive = request.IsActive;

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

        // 6. GET: Belirli tarih aralığına göre fon fiyatlarını getirme kapısı
        // Adres Örneği: GET /api/funds/1/prices?startDate=2026-06-01&endDate=2026-07-01
        [HttpGet("{fundId}/prices")]
        public IActionResult GetPricesByDateRange(int fundId, [FromQuery] DateTime startDate, [FromQuery] DateTime endDate)
        {
            var prices = _fundService.GetPricesByDateRange(fundId, startDate, endDate);

            if (prices == null || !prices.Any())
            {
                return NotFound("Bu tarih aralığında fiyata ait veri bulunamadı.");
            }

            return Ok(prices);
        }

        // 7. POST: CSV dosyası ile toplu fiyat yükleme kapısı
        // Adres Örneği: POST /api/funds/upload-csv
        [HttpPost("upload-csv")]
        public IActionResult UploadPricesCsv(IFormFile file)
        {
            if (file == null || file.Length == 0)
            {
                return BadRequest("Lütfen geçerli bir CSV dosyası yükleyin.");
            }

            var newPrices = new List<FundPrice>();

            try
            {
                using (var stream = new StreamReader(file.OpenReadStream()))
                {
                    var headerLine = stream.ReadLine();

                    while (!stream.EndOfStream)
                    {
                        var line = stream.ReadLine();
                        if (string.IsNullOrWhiteSpace(line)) continue;

                        var columns = line.Split(',');

                        if (columns.Length >= 3)
                        {
                            var fundPrice = new FundPrice
                            {
                                FundId = int.Parse(columns[0].Trim()),
                                Date = DateTime.Parse(columns[1].Trim()),
                                Price = decimal.Parse(columns[2].Trim(), CultureInfo.InvariantCulture),
                                ChangeRate = 0
                            };

                            newPrices.Add(fundPrice);
                        }
                    }
                }

                _fundService.AddPricesBulk(newPrices);

                return Ok($"{newPrices.Count} adet fiyat kaydı başarıyla veritabanına işlendi!");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"CSV okunurken bir hata oluştu: {ex.Message}");
            }
        }
    }
}