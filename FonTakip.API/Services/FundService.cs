using FonTakip.API.Controllers;
using FonTakip.API.Data;
using FonTakip.API.Models;
using Microsoft.EntityFrameworkCore;

namespace FonTakip.API.Services
{
    public class FundService
    {
        // Aşçının veritabanına erişim köprüsü
        private readonly AppDbContext _context;

        public FundService(AppDbContext context)
        {
            _context = context;
        }
        
        public List<Fund> GetAllFunds()
        {
            // Sadece aktif olanları filtrele:
            var funds = _context.Funds.Include(f => f.Prices).Where(f => f.IsActive == true).ToList();
            return funds;
        }

        // Dışarıdan bir kategori ismi alan ve sadece o kategoriyle eşleşen aktif fonları getiren metot
        public List<Fund> GetFundsByCategory(string categoryName)
        {
            var funds = _context.Funds.Where(f => f.IsActive == true && f.Category == categoryName).ToList();

            return funds;


        }

        // POST: Yeni fon ekleme metodu
        // Dışarıdan DTO değil, Controller'ın hazırladığı saf "Fund" nesnesini alıyoruz.
        public void AddFund(Fund newFund)
        { 
            _context.Funds.Add(newFund);

            _context.SaveChanges();
        }

        // GET: Tek bir fonu ID ile bulma
        public Fund? GetFundById(int id)
        {
            return _context.Funds.Include(f => f.Prices).FirstOrDefault(f => f.Id == id);
        }

        // PUT: Fon güncelleme
        public void UpdateFund(Fund fund)
        {
            _context.Funds.Update(fund);
            _context.SaveChanges();
        }

        // DELETE: Fon silme (Yazılımsal / Soft Delete)
        public void DeleteFund(Fund fund)
        {
            fund.IsActive = false;
            _context.Funds.Update(fund);
            _context.SaveChanges();
        }

        // POST: Bir fona yeni fiyat ekleme
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
    }
}