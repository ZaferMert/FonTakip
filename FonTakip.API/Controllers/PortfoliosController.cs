using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FonTakip.API.Data;
using FonTakip.API.Models;
using System.Security.Claims;

namespace FonTakip.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class PortfoliosController : ControllerBase
    {
        private readonly AppDbContext _context;

        public PortfoliosController(AppDbContext context)
        {
            _context = context;
        }

        // 1. KULLANICININ PORTFÖYÜNÜ GETİR (GET /api/portfolios)
        [HttpGet]
        public async Task<IActionResult> GetPortfolio()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (userId == null)
            {
                return Unauthorized("Kullanıcı kimliği doğrulanamadı.");
            }

            var portfolio = await _context.PortfolioItems
                .Include(p => p.Fund)
                .Where(p => p.UserId == userId)
                .Select(p => new
                {
                    p.Id,
                    p.FundId,
                    FundCode = p.Fund.Code,
                    FundName = p.Fund.Name,
                    p.Shares,
                    p.AverageCost,
                    TotalCost = p.Shares * p.AverageCost 
                })
                .ToListAsync();

            return Ok(portfolio);
        }

        // 2. PORTFÖYE YENİ FON EKLE (POST /api/portfolios)
        [HttpPost]
        public async Task<IActionResult> AddToPortfolio([FromBody] AddToPortfolioRequest request)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (userId == null)
            {
                return Unauthorized("Kullanıcı kimliği doğrulanamadı.");
            }

            var fundExists = await _context.Funds.AnyAsync(f => f.Id == request.FundId);
            if (!fundExists)
            {
                return NotFound("Belirtilen fon bulunamadı.");
            }

            var existingItem = await _context.PortfolioItems
                .FirstOrDefaultAsync(p => p.UserId == userId && p.FundId == request.FundId);

            if (existingItem != null)
            {
                var totalCostBefore = existingItem.Shares * existingItem.AverageCost;
                var additionalCost = request.Shares * request.Price;
                var newTotalShares = existingItem.Shares + request.Shares;

                existingItem.AverageCost = (totalCostBefore + additionalCost) / newTotalShares;
                existingItem.Shares = newTotalShares;
            }
            else
            {
                var newItem = new PortfolioItem
                {
                    UserId = userId,
                    FundId = request.FundId,
                    Shares = request.Shares,
                    AverageCost = request.Price
                };
                _context.PortfolioItems.Add(newItem);
            }

            await _context.SaveChangesAsync();
            return Ok(new { message = "Fon başarıyla portföye eklendi." });
        }
    }

    public class AddToPortfolioRequest
    {
        public int FundId { get; set; }
        public decimal Shares { get; set; }
        public decimal Price { get; set; }
    }
}