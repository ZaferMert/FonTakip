using FonTakip.API.Data;
using Microsoft.EntityFrameworkCore;
using FonTakip.API.Services;

var builder = WebApplication.CreateBuilder(args);

// --- 1. MUTFAK HAZIRLIĞI (Services) ---

// Controller kapılarımızı aktifleştirir
builder.Services.AddControllers();
builder.Services.AddScoped<FundService>();

// Swagger görsel arayüzü için gerekli ayarlar
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Veritabanı köprümüz
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

// --- 2. RESTORAN KURALLARI (Middleware) ---

// Eğer geliştirme (Development) aşamasındaysak Swagger'ı göster
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();

// Yazdığımız Controller'ları sisteme haritalandırır
app.MapControllers(); 

app.Run();