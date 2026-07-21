using FonTakip.API.Controllers;
using FonTakip.API.Data;
using FonTakip.API.Models;
using Microsoft.EntityFrameworkCore;

namespace FonTakip.API.Services
{
    public class FundService
    {
        private readonly AppDbContext _context;

        public FundService(AppDbContext context)
        {
            _context = context;
        }
        
        public List<Fund> GetAllFunds()
        {
            var funds = _context.Funds.Include(f => f.Prices).Where(f => f.IsActive == true).ToList();
            return funds;
        }

        public List<Fund> GetFundsByCategory(string categoryName)
        {
            var funds = _context.Funds.Where(f => f.IsActive == true && f.Category == categoryName).ToList();

            return funds;


        }

        public void AddFund(Fund newFund)
        { 
            _context.Funds.Add(newFund);

            _context.SaveChanges();
        }

        public Fund? GetFundById(int id)
        {
            return _context.Funds.Include(f => f.Prices).FirstOrDefault(f => f.Id == id);
        }

        public void UpdateFund(Fund fund)
        {
            _context.Funds.Update(fund);
            _context.SaveChanges();
        }

        public void DeleteFund(Fund fund)
        {
            fund.IsActive = false;
            _context.Funds.Update(fund);
            _context.SaveChanges();
        }

        public void AddPriceToFund(int targetFundId, decimal incomingPrice)
        {    
            var newFundPrice = new FundPrice
            {
                FundId = targetFundId,
                Price = incomingPrice,
                Date = DateTime.Now,
                ChangeRate = 0
            };

            _context.FundPrices.Add(newFundPrice);

            _context.SaveChanges();

        }

        public List<FundPrice> GetPricesByDateRange(int fundId, DateTime startDate, DateTime endDate)
        {
            var prices = _context.FundPrices
                .Where(fp => fp.FundId == fundId && fp.Date.Date >= startDate.Date && fp.Date.Date <= endDate.Date)
                .OrderBy(fp => fp.Date)
                .ToList();

            return prices;
        }

        public void AddPricesBulk(List<FundPrice> prices)
        {
            _context.FundPrices.AddRange(prices);
            _context.SaveChanges();
        }
    }
}