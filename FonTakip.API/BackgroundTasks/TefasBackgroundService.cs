using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using FonTakip.API.Data;
using FonTakip.API.Models;

namespace FonTakip.API.BackgroundTasks
{
    public class TefasBackgroundService : BackgroundService
    {
        private readonly ILogger<TefasBackgroundService> _logger;
        private readonly IServiceScopeFactory _scopeFactory;

        public TefasBackgroundService(ILogger<TefasBackgroundService> logger, IServiceScopeFactory scopeFactory)
        {
            _logger = logger;
            _scopeFactory = scopeFactory;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation("TEFAS Arka Plan Servisi başlatıldı...");
            var random = new Random();

            using (var scope = _scopeFactory.CreateScope())
            {
                var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();

                var aktifFonlar = dbContext.Funds.Where(f => f.IsActive).ToList();

                foreach (var fon in aktifFonlar)
                {
                    var fiyatSayisi = dbContext.Set<FundPrice>().Count(fp => fp.FundId == fon.Id);
                    
                    if (fiyatSayisi > 25)
                    {
                        var silinecekler = dbContext.Set<FundPrice>().Where(fp => fp.FundId == fon.Id).ToList();
                        dbContext.RemoveRange(silinecekler);
                        _logger.LogInformation("{FonKodu} için spam veriler tespit edildi ve temizlendi.", fon.Code);
                    }
                }
                await dbContext.SaveChangesAsync(stoppingToken);

                foreach (var fon in aktifFonlar)
                {
                    bool gecmisVeriVarMi = dbContext.Set<FundPrice>().Any(fp => fp.FundId == fon.Id);
                    
                    if (!gecmisVeriVarMi)
                    {
                        _logger.LogInformation("{FonKodu} için pürüzsüz 20 günlük piyasa verisi oluşturuluyor...", fon.Code);
                        decimal baslangicFiyati = 100m;
                        
                        for (int i = 20; i >= 1; i--)
                        {
                            double degisimOrani = (random.NextDouble() * 5) - 2; 
                            baslangicFiyati = baslangicFiyati * (1 + (decimal)(degisimOrani / 100));
                            baslangicFiyati = Math.Round(baslangicFiyati, 6);
                            
                            dbContext.Set<FundPrice>().Add(new FundPrice
                            {
                                FundId = fon.Id,
                                Price = baslangicFiyati,
                                Date = DateTime.Today.AddDays(-i)
                            });
                        }
                    }
                }
                await dbContext.SaveChangesAsync(stoppingToken);
                _logger.LogInformation("Tarihçe veri kontrolü tamamlandı.");
            }
            
            while (!stoppingToken.IsCancellationRequested)
            {
                try
                {
                    using (var scope = _scopeFactory.CreateScope())
                    {
                        var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
                        var aktifFonlar = dbContext.Funds.Where(f => f.IsActive).ToList();

                        if (aktifFonlar.Count > 0)
                        {
                            foreach (var fon in aktifFonlar)
                            {
                                var sonFiyatKaydi = dbContext.Set<FundPrice>()
                                                             .Where(fp => fp.FundId == fon.Id)
                                                             .OrderByDescending(fp => fp.Date)
                                                             .FirstOrDefault();
                                
                                decimal baslangicFiyati = sonFiyatKaydi != null ? sonFiyatKaydi.Price : 100m;
                                double degisimOrani = (random.NextDouble() * 5) - 2; 
                                decimal yeniFiyat = baslangicFiyati * (1 + (decimal)(degisimOrani / 100));
                                yeniFiyat = Math.Round(yeniFiyat, 6);

                                var bugun = DateTime.Today;
                                var yarin = bugun.AddDays(1);
                                var bugunkuKayit = dbContext.Set<FundPrice>()
                                                            .FirstOrDefault(fp => fp.FundId == fon.Id && fp.Date >= bugun && fp.Date < yarin);

                                if (bugunkuKayit != null)
                                {
                                    bugunkuKayit.Price = yeniFiyat;
                                }
                                else
                                {
                                    dbContext.Set<FundPrice>().Add(new FundPrice 
                                    { 
                                        FundId = fon.Id,
                                        Price = yeniFiyat, 
                                        Date = DateTime.Now 
                                    });
                                }
                            }
                            
                            await dbContext.SaveChangesAsync(stoppingToken);
                        }
                    }
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Simülasyon güncellenirken hata oluştu.");
                }

                await Task.Delay(TimeSpan.FromSeconds(15), stoppingToken);
            }
        }
    }
}