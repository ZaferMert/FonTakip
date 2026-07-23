# FonTakip - Katılım Fonu Takip ve Yönetim Sistemi

FonTakip, TEFAS (Türkiye Elektronik Fon Alım Satım Platformu) mantığıyla çalışan, kullanıcılara "Katılım Fonlarını" listeleme, karşılaştırma ve portföylerinde takip etme imkanı sunan tam kapsamlı (Full-Stack) bir web uygulamasıdır. Proje, kurumsal bankacılık "Hazine Uygulamaları" süreçlerinden ilham alınarak, güncel yazılım mühendisliği pratikleriyle geliştirilmiştir.

## 🚀 Öne Çıkan Özellikler

- **Katılım Fonu Odağı:** Sistem tamamen Katılım Fonlarına özel olarak tasarlanmıştır. Gereksiz kategori karmaşası olmadan net bir finansal vizyon sunar.
- **Güvenlik ve Yetkilendirme (JWT):** Kullanıcı giriş ve kayıt işlemlerinde veri doğrulama (validation) süreçleri mevcuttur. Rota (Route) bazlı yetki kontrolü yapılarak Admin ve Kullanıcı rolleri birbirinden ayrılmıştır.
- **Yönetici Paneli (Admin Paneli):** Yetkili kullanıcılar sistemde listelenen fonları yönetebilir (CRUD işlemleri) ve CSV formatında toplu fiyat güncellemesi yapabilirler.
- **Otomatik Fiyat Simülasyonu:** Arka planda her gün otomatik olarak çalışan (.NET BackgroundService) simülatör, mevcut fonların fiyatlarını günlük olarak rastgele dalgalandırarak uygulamanın "canlı" kalmasını sağlar.
- **Gelişmiş Görselleştirme:** Fonların geçmiş performans verileri Recharts kullanılarak interaktif grafiklerle kullanıcılara sunulur. Karşılaştırma sayfası ile farklı fonların performansları yan yana incelenebilir.

## 🛠 Kullanılan Teknolojiler

**Backend (Arka Yüz)**
- .NET 8.0 / ASP.NET Core Web API
- Entity Framework Core (Code-First)
- SQL Server (Docker Container)
- JWT tabanlı Kimlik Doğrulama (Authentication)
- C# BackgroundService (Zamanlanmış Görevler)

**Frontend (Ön Yüz)**
- React 18 (Vite)
- Tailwind CSS (Modern ve duyarlı tasarım)
- React Router DOM (Yönlendirme ve korumalı rotalar)
- Axios (API İstekleri - Interceptor ile otomatik token yönetimi)
- Recharts (Veri görselleştirme ve grafikler)

**Altyapı ve Dağıtım (DevOps)**
- Docker & Docker Compose (Tek tıkla kurulum)
- Swagger UI (Geliştirme ortamında API dokümantasyonu)

## 🐳 Hızlı Kurulum ve Çalıştırma

Projenin tüm katmanları Docker ile konteynerize edilmiştir. Makinenizde Docker ve Docker Compose yüklü ise projeyi saniyeler içinde ayağa kaldırabilirsiniz.

1. Depoyu bilgisayarınıza indirin (Clone).
2. Terminal üzerinden projenin ana dizinine gidin.
3. Aşağıdaki komutu çalıştırın:
```bash
docker-compose up -d --build
```

Bu komut ile birlikte;
- `fontakip_db`: SQL Server veritabanı,
- `fontakip_api`: .NET 8 API katmanı (Backend),
- `fontakip_ui`: React katmanı (Frontend) aynı anda ayağa kalkacaktır.

**Erişim Bağlantıları:**
- Frontend (Kullanıcı Arayüzü): `http://localhost:5173`
- Backend (API) Base URL: `http://localhost:5043/api`
- Swagger API Dokümantasyonu: `http://localhost:5043/swagger`

## 👨‍💻 Test Kullanıcıları
Sistemin farklı yetkilerini test etmek için varsayılan olarak veritabanında yer alan kullanıcılar:
- **Admin Yetkili:** `zafer@gmail.com` (Şifre: `Zafer2020.`)
- **Standart Kullanıcı:** `tahabenli@gmail.com` veya `aliozturk@gmail.com` 

## 📝 Not
Bu proje, modern yazılım geliştirme pratiklerini yakalamak, uçtan uca (Full-Stack) bir projenin yaşam döngüsünü kavramak ve mimari becerileri pekiştirmek amacıyla geliştirilmiş bir portföy çalışmasıdır. Mimari kararlar ve kodlama süreçleri özenle kurgulanmıştır.