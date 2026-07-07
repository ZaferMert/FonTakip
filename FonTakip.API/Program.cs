using Microsoft.EntityFrameworkCore;
using FonTakip.API.Data;

var builder = WebApplication.CreateBuilder(args);

// --- SERVİS AYARLARI (BUILD OLMADAN ÖNCE BURAYA YAZILIR) ---

// OpenAPI (Test arayüzü) servisini ekliyoruz
builder.Services.AddOpenApi();

// Veritabanı Köprümüzü (AppDbContext) sisteme tanıtıyoruz
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// -----------------------------------------------------------

var app = builder.Build();

// --- UYGULAMA ÇALIŞMA AYARLARI (BUILD OLDUKTAN SONRA) ---

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

// İleride kendi API adreslerimizi (Fonları getir, Kullanıcı ekle vb.) buraya yazacağız.

app.Run();