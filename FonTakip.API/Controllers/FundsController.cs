using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using FonTakip.API.Data;
using FonTakip.API.Models;
using FonTakip.API.DTOs;
using FonTakip.API.Services;
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
        [HttpGet("category/{categoryName}")]
        public IActionResult GetByCategory(string categoryName)
        {
            var funds = _fundService.GetFundsByCategory(categoryName);
            return Ok(funds);
        }

        // 3. POST: Yeni fon ekleme kapısı (Sadece Admin)
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public IActionResult CreateFund([FromBody] FundCreateDto request)
        {
            var existing = _fundService.GetFundByCode(request.Code);
            if (existing != null)
            {
                existing.Name = request.Name;
                existing.Category = string.IsNullOrWhiteSpace(request.Category) ? "Katılım Fonu" : request.Category;
                existing.Risk = request.Risk > 0 ? request.Risk : existing.Risk;
                existing.ManagementFee = request.ManagementFee > 0 ? request.ManagementFee : existing.ManagementFee;
                existing.InvestorCount = request.InvestorCount > 0 ? request.InvestorCount : existing.InvestorCount;
                existing.TotalValue = request.TotalValue > 0 ? request.TotalValue : existing.TotalValue;
                if (!string.IsNullOrWhiteSpace(request.AssetDistribution)) existing.AssetDistribution = request.AssetDistribution;
                
                _fundService.UpdateFund(existing);
                return Ok("Fon bilgileri güncellendi.");
            }

            var newFund = new Fund
            {
                Name = request.Name,
                Code = request.Code.ToUpper(),
                Category = string.IsNullOrWhiteSpace(request.Category) ? "Katılım Fonu" : request.Category,
                Risk = request.Risk > 0 ? request.Risk : 3,
                ManagementFee = request.ManagementFee > 0 ? request.ManagementFee : 1.5m,
                InvestorCount = request.InvestorCount,
                TotalValue = request.TotalValue,
                AssetDistribution = request.AssetDistribution,
                IsActive = true
            };

            _fundService.AddFund(newFund);

            return Ok("Fon başarıyla eklendi.");
        }

        // 4. PUT: Mevcut bir fonu güncelleme kapısı (Sadece Admin)
        [Authorize(Roles = "Admin")]
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
            existingFund.Risk = request.Risk;
            existingFund.ManagementFee = request.ManagementFee;
            existingFund.InvestorCount = request.InvestorCount;
            existingFund.TotalValue = request.TotalValue;
            existingFund.AssetDistribution = request.AssetDistribution;
            existingFund.IsActive = request.IsActive;

            _fundService.UpdateFund(existingFund);

            return Ok("Fon başarıyla güncellendi.");
        }

        // 5. DELETE: Bir fonu pasife çekme (Soft Delete) kapısı (Sadece Admin)
        [Authorize(Roles = "Admin")]
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

        // 6. POST: Bir fona yeni fiyat ekleme kapısı (Sadece Admin)
        [Authorize(Roles = "Admin")]
        [HttpPost("{fundId}/prices")]
        public IActionResult AddPrice(int fundId, [FromBody] FundPriceCreateDto request)
        {
            _fundService.AddPriceToFund(fundId, request.Price);
            return Ok("Fiyat başarıyla eklendi.");
        }

        // 7. GET: Belirli tarih aralığına göre fon fiyatlarını getirme kapısı
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

        // 8. POST: CSV Dosyası Yükleme Kapısı (Sadece Admin)
        [Authorize(Roles = "Admin")]
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
                        if (columns.Length < 3) continue;

                        string code = columns[0].Trim();
                        string name = columns.Length > 1 ? columns[1].Trim() : code;
                        string category = columns.Length > 2 ? columns[2].Trim() : "Katılım Fonu";

                        DateTime date = DateTime.Today;
                        decimal price = 0m;
                        decimal changeRate = 0m;

                        int risk = 3;
                        decimal fee = 1.5m;
                        int investors = 0;
                        decimal totalVal = 0m;
                        string assets = "";

                        if (columns.Length >= 11)
                        {
                            DateTime.TryParse(columns[3].Trim(), out date);
                            decimal.TryParse(columns[4].Trim(), NumberStyles.Any, CultureInfo.InvariantCulture, out price);
                            decimal.TryParse(columns[5].Trim(), NumberStyles.Any, CultureInfo.InvariantCulture, out changeRate);
                            int.TryParse(columns[6].Trim(), out risk);
                            decimal.TryParse(columns[7].Trim(), NumberStyles.Any, CultureInfo.InvariantCulture, out fee);
                            int.TryParse(columns[8].Trim(), out investors);
                            decimal.TryParse(columns[9].Trim(), NumberStyles.Any, CultureInfo.InvariantCulture, out totalVal);
                            assets = columns[10].Trim('"').Trim();
                        }
                        else if (columns.Length >= 5)
                        {
                            DateTime.TryParse(columns[3].Trim(), out date);
                            decimal.TryParse(columns[4].Trim(), NumberStyles.Any, CultureInfo.InvariantCulture, out price);
                        }
                        else
                        {
                            DateTime.TryParse(columns[1].Trim(), out date);
                            decimal.TryParse(columns[2].Trim(), NumberStyles.Any, CultureInfo.InvariantCulture, out price);
                        }

                        if (string.IsNullOrWhiteSpace(code)) continue;

                        var fund = _fundService.GetFundByCode(code);
                        if (fund == null)
                        {
                            fund = new Fund
                            {
                                Code = code.ToUpper(),
                                Name = string.IsNullOrWhiteSpace(name) ? code : name,
                                Category = string.IsNullOrWhiteSpace(category) ? "Katılım Fonu" : category,
                                Risk = risk > 0 ? risk : 3,
                                ManagementFee = fee > 0 ? fee : 1.5m,
                                InvestorCount = investors,
                                TotalValue = totalVal,
                                AssetDistribution = assets,
                                IsActive = true
                            };
                            _fundService.AddFund(fund);
                        }
                        else
                        {
                            if (!string.IsNullOrWhiteSpace(name) && name != code) fund.Name = name;
                            if (!string.IsNullOrWhiteSpace(category)) fund.Category = category;
                            if (risk > 0) fund.Risk = risk;
                            if (fee > 0) fund.ManagementFee = fee;
                            if (investors > 0) fund.InvestorCount = investors;
                            if (totalVal > 0) fund.TotalValue = totalVal;
                            if (!string.IsNullOrWhiteSpace(assets)) fund.AssetDistribution = assets;
                            _fundService.UpdateFund(fund);
                        }

                        if (fund.Id > 0 && price > 0)
                        {
                            newPrices.Add(new FundPrice
                            {
                                FundId = fund.Id,
                                Date = date,
                                Price = price,
                                ChangeRate = changeRate
                            });
                        }
                    }
                }

                _fundService.AddPricesBulk(newPrices);

                return Ok($"{newPrices.Count} adet fon ve fiyat kaydı başarıyla veritabanına işlendi!");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"CSV okunurken bir hata oluştu: {ex.Message}");
            }
        }
    }
}