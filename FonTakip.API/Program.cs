using FonTakip.API.Data;
using Microsoft.EntityFrameworkCore;
using FonTakip.API.Services;
using FonTakip.API.Middlewares;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// --- 1. MUTFAK HAZIRLIĞI (Services) ---

// Controller kapılarımızı aktifleştirir
builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles;
});

builder.Services.AddHostedService<FonTakip.API.BackgroundTasks.TefasBackgroundService>();

// JWT Kimlik Doğrulama (Authentication) Ayarları
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true, // Token'ı kimin dağıttığını doğrula
            ValidateAudience = true, // Token'ın kime verildiğini doğrula
            ValidateLifetime = true, // Token'ın süresinin dolup dolmadığını kontrol et
            ValidateIssuerSigningKey = true, // Gizli anahtarımızı doğrula
            
            ValidIssuer = builder.Configuration["JwtSettings:Issuer"],
            ValidAudience = builder.Configuration["JwtSettings:Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JwtSettings:SecretKey"]!))
        };
    });

builder.Services.AddScoped<FundService>();
builder.Services.AddScoped<AuthService>();

// Swagger görsel arayüzü için gerekli ayarlar
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    // Ekrana Authorize (Kilit) butonunu ekler
    options.AddSecurityDefinition("Bearer", new Microsoft.OpenApi.Models.OpenApiSecurityScheme
{
    Name = "Authorization",
    Type = Microsoft.OpenApi.Models.SecuritySchemeType.Http, // ApiKey yerine doğrudan Http standardını kullanıyoruz
    Scheme = "Bearer",
    BearerFormat = "JWT", // Swagger'a bunun bir JWT olduğunu açıkça söylüyoruz
    In = Microsoft.OpenApi.Models.ParameterLocation.Header,
    Description = "Aşağıdaki kutucuğa SADECE kopyaladığınız şifreli metni (Token) yapıştırın. Başına Bearer yazmanıza GEREK YOKTUR."
});

    // Kilitli odalara girerken token'ın gönderilmesini zorunlu kılar
    options.AddSecurityRequirement(new Microsoft.OpenApi.Models.OpenApiSecurityRequirement
    {
        {
            new Microsoft.OpenApi.Models.OpenApiSecurityScheme
            {
                Reference = new Microsoft.OpenApi.Models.OpenApiReference
                {
                    Type = Microsoft.OpenApi.Models.ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            Array.Empty<string>()
        }
    });
});

// Veritabanı köprümüz
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// CORS politikasını ekliyoruz: Frontend'in (5173) bize istek atmasına izin ver
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowReactApp", policy =>
    {
        policy.WithOrigins("http://localhost:5173") // React'in çalıştığı port
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

var app = builder.Build();

// --- 2. RESTORAN KURALLARI (Middleware) ---

// Eğer geliştirme (Development) aşamasındaysak Swagger'ı göster
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// Eklediğimiz CORS politikasını aktif ediyoruz
app.UseCors("AllowReactApp");

// Güvenlik Şefimizi devreye alıyoruz (Tüm istekleri o karşılayacak)
app.UseMiddleware<ExceptionMiddleware>();

app.UseAuthentication(); // ÖNCE KİMLİK DOĞRULAMA
app.UseAuthorization();

// Yazdığımız Controller'ları sisteme haritalandırır
app.MapControllers(); 

app.Run();