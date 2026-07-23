using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using FonTakip.API.Data;
using FonTakip.API.Models;
using Microsoft.EntityFrameworkCore;

namespace FonTakip.API.Services
{
    public class PriceSimulatorService : BackgroundService
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly ILogger<PriceSimulatorService> _logger;

        public PriceSimulatorService(IServiceProvider serviceProvider, ILogger<PriceSimulatorService> logger)
        {
            _serviceProvider = serviceProvider;
            _logger = logger;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            // Bekle ki veritabanı migrate işlemleri bitsin (Program.cs'deki ExecuteScope vs)
            await Task.Delay(TimeSpan.FromSeconds(10), stoppingToken);

            while (!stoppingToken.IsCancellationRequested)
            {
                try
                {
                    await SimulatePricesAsync();
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Fiyat simülatörü çalışırken bir hata oluştu.");
                }

                // Günde 1 kez kontrol et (veya 1 saatte bir)
                await Task.Delay(TimeSpan.FromHours(12), stoppingToken);
            }
        }

        private async Task SimulatePricesAsync()
        {
            using var scope = _serviceProvider.CreateScope();
            var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();

            var today = DateTime.Today;
            var funds = await context.Funds.ToListAsync();
            var random = new Random();
            int newRecordsAdded = 0;

            foreach (var fund in funds)
            {
                // En son fiyat kaydını getir
                var lastPriceRecord = await context.FundPrices
                    .Where(p => p.FundId == fund.Id)
                    .OrderByDescending(p => p.Date)
                    .FirstOrDefaultAsync();

                if (lastPriceRecord == null)
                    continue; // Hiç fiyat yoksa simüle edemeyiz

                // Son fiyat tarihi bugünden küçükse, aradaki eksik günleri tamamla
                var dateToProcess = lastPriceRecord.Date.Date.AddDays(1);
                var currentPrice = lastPriceRecord.Price;

                while (dateToProcess <= today)
                {
                    // -5% ile +5% arasında rastgele bir değişim oranı
                    decimal changeRate = (decimal)Math.Round((random.NextDouble() * 10) - 5, 2);
                    
                    // Yeni fiyatı hesapla
                    currentPrice = currentPrice + (currentPrice * (changeRate / 100m));
                    
                    var newPrice = new FundPrice
                    {
                        FundId = fund.Id,
                        Date = dateToProcess,
                        Price = currentPrice,
                        ChangeRate = changeRate
                    };

                    context.FundPrices.Add(newPrice);
                    newRecordsAdded++;

                    dateToProcess = dateToProcess.AddDays(1);
                }
            }

            if (newRecordsAdded > 0)
            {
                await context.SaveChangesAsync();
                _logger.LogInformation($"{newRecordsAdded} adet yeni günlük fiyat simüle edildi ve eklendi.");
            }
            else
            {
                _logger.LogInformation("Tüm fonların fiyatları bugünün tarihi ile güncel.");
            }
        }
    }
}
