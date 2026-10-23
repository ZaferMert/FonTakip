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


## 🐳 Installation and Setup

### Prerequisites

- Docker Desktop
- Docker Compose
- Node.js and npm

### 1. Clone the Repository

```bash
git clone https://github.com/ZaferMert/FonTakip.git
cd FonTakip
```

### 2. Configure Environment Variables

Create a `.env` file in the project root using `.env.example` as a reference.

Set the following variables:

- `MSSQL_SA_PASSWORD`: A strong SQL Server administrator password.
- `JWT_SECRET_KEY`: A cryptographically secure random JWT signing key.

Generate a JWT key with:

```bash
openssl rand -hex 32
```

Never commit the `.env` file or real credentials to GitHub.

### 3. Start the Backend and Database

```bash
docker compose up -d --build db api
```

Docker Compose starts:

- SQL Server on port `1433`
- ASP.NET Core Web API on port `5043`

The API automatically applies Entity Framework Core migrations.

### 4. Start the Frontend

```bash
cd FonTakip.UI
npm ci
npm run dev
```

The React application runs locally using Vite.

### 5. Access the Application

- Frontend: http://localhost:5173
- Backend API: http://localhost:5043/api
- Swagger UI: http://localhost:5043/swagger

### 6. Create a User Account

Open the application and use the registration page to create an account.

New accounts receive the `User` role by default. Administrative privileges must be assigned separately by an authorized database administrator.

No default administrator credentials are distributed with this repository. 

## 📝 Not
Bu proje, modern yazılım geliştirme pratiklerini yakalamak, uçtan uca (Full-Stack) bir projenin yaşam döngüsünü kavramak ve mimari becerileri pekiştirmek amacıyla geliştirilmiş bir portföy çalışmasıdır. Mimari kararlar ve kodlama süreçleri özenle kurgulanmıştır.
