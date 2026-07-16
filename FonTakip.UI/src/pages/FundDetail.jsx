import { useState, useEffect } from 'react';
import { useParams, Link } from 'react-router-dom';
import { LineChart, Line, XAxis, YAxis, CartesianGrid, Tooltip, ResponsiveContainer } from 'recharts';

export default function FundDetail() {
  const { id } = useParams();
  
  // 1. YENİ: Durum (State) Yönetimi
  const [isLoading, setIsLoading] = useState(true);
  const [error, setError] = useState(null);
  const [fundData, setFundData] = useState(null);

  // 2. YENİ: Yaşam Döngüsü (Veri Çekme Simülasyonu)
  useEffect(() => {
    // Sayfa açıldığında loading'i başlat
    setIsLoading(true);
    
    // Gerçek bir API'ye istek atıyormuşuz gibi 1.5 saniye gecikme (setTimeout) veriyoruz
    const timer = setTimeout(() => {
      try {
        // İleride burası axios.get(`/api/funds/${id}`) olacak
        const mockData = {
          name: "Marmara Capital Hisse Senedi Fonu",
          code: "MAC",
          currentPrice: 14.52,
          dailyChange: "+2.4%",
          risk: "6 / 7",
          monthlyReturn: "%8.5",
          yearlyReturn: "%112.4",
          chart: [
            { date: '1 Tem', price: 13.50 },
            { date: '3 Tem', price: 13.80 },
            { date: '5 Tem', price: 13.65 },
            { date: '7 Tem', price: 14.10 },
            { date: '9 Tem', price: 14.35 },
            { date: '11 Tem', price: 14.20 },
            { date: '14 Tem', price: 14.52 },
          ]
        };
        
        setFundData(mockData);
        setIsLoading(false);
      } catch (err) {
        setError("Fon verileri yüklenirken bir sorun oluştu.");
        setIsLoading(false);
      }
    }, 1500); // 1.5 saniye bekle

    // Bileşen ekrandan kalkarsa sayacı temizle
    return () => clearTimeout(timer);
  }, [id]);

  // 3. YENİ: Yükleniyor (Skeleton) Ekranı
  if (isLoading) {
    return (
      <div className="min-h-screen bg-zinc-950 p-4 md:p-8">
        <div className="max-w-[1000px] mx-auto animate-pulse">
          <div className="h-4 bg-zinc-800 rounded w-24 mb-8"></div>
          
          <div className="flex flex-col sm:flex-row justify-between mb-8 gap-4">
            <div>
              <div className="h-6 bg-zinc-800 rounded w-16 mb-3"></div>
              <div className="h-8 bg-zinc-800 rounded w-64 md:w-96"></div>
            </div>
            <div className="flex flex-col items-start sm:items-end">
              <div className="h-4 bg-zinc-800 rounded w-20 mb-2"></div>
              <div className="h-8 bg-zinc-800 rounded w-32"></div>
            </div>
          </div>

          <div className="grid grid-cols-1 lg:grid-cols-3 gap-6">
            <div className="lg:col-span-2 bg-zinc-900/40 border border-zinc-800 rounded-2xl p-6 h-[400px]">
              <div className="h-4 bg-zinc-800 rounded w-48 mb-8"></div>
              <div className="w-full h-[280px] bg-zinc-800/50 rounded-lg"></div>
            </div>
            <div className="bg-zinc-900/40 border border-zinc-800 rounded-2xl p-6 h-[400px]">
              <div className="h-4 bg-zinc-800 rounded w-24 mb-8"></div>
              <div className="space-y-6">
                <div className="h-4 bg-zinc-800 rounded w-full"></div>
                <div className="h-4 bg-zinc-800 rounded w-full"></div>
                <div className="h-4 bg-zinc-800 rounded w-full"></div>
              </div>
              <div className="h-12 bg-zinc-800 rounded w-full mt-12"></div>
            </div>
          </div>
        </div>
      </div>
    );
  }

  // 4. YENİ: Hata Ekranı
  if (error) {
    return (
      <div className="min-h-screen bg-zinc-950 flex flex-col items-center justify-center p-4">
        <div className="bg-red-500/10 border border-red-500/20 text-red-400 p-6 rounded-xl max-w-md text-center">
          <svg className="w-12 h-12 mx-auto mb-4 text-red-500" fill="none" viewBox="0 0 24 24" stroke="currentColor">
            <path strokeLinecap="round" strokeLinejoin="round" strokeWidth={2} d="M12 9v2m0 4h.01m-6.938 4h13.856c1.54 0 2.502-1.667 1.732-3L13.732 4c-.77-1.333-2.694-1.333-3.464 0L3.34 16c-.77 1.333.192 3 1.732 3z" />
          </svg>
          <h2 className="text-lg font-bold mb-2">Eyvah! Bir Hata Oluştu</h2>
          <p className="text-sm">{error}</p>
          <Link to="/funds" className="mt-6 inline-block bg-zinc-800 hover:bg-zinc-700 text-white px-4 py-2 rounded-lg transition-colors">
            Piyasalara Dön
          </Link>
        </div>
      </div>
    );
  }

  // 5. ASIL EKRAN: Veriler başarıyla yüklendiğinde gösterilecek arayüz
  return (
    <div className="min-h-screen bg-zinc-950 text-white p-4 md:p-8">
      <div className="max-w-[1000px] mx-auto">
        <div className="mb-8">
          <Link to="/funds" className="text-cyan-500 hover:text-cyan-400 text-sm flex items-center gap-2 mb-4 w-fit">
            <svg className="w-4 h-4" fill="none" viewBox="0 0 24 24" stroke="currentColor">
              <path strokeLinecap="round" strokeLinejoin="round" strokeWidth={2} d="M10 19l-7-7m0 0l7-7m-7 7h18" />
            </svg>
            Piyasalara Dön
          </Link>
          
          <div className="flex flex-col sm:flex-row sm:justify-between sm:items-end gap-4">
            <div>
              <div className="bg-zinc-900 border border-zinc-800 px-3 py-1 rounded-md text-sm font-bold text-cyan-400 w-fit mb-3">
                {fundData.code}
              </div>
              <h1 className="text-2xl md:text-3xl font-medium text-white">{fundData.name}</h1>
            </div>
            <div className="text-left sm:text-right">
              <p className="text-zinc-500 text-sm mb-1">Güncel Fiyat</p>
              <div className="flex items-baseline gap-3">
                <span className="text-3xl font-bold text-white">{fundData.currentPrice} ₺</span>
                <span className="text-emerald-400 font-medium">{fundData.dailyChange}</span>
              </div>
            </div>
          </div>
        </div>

        <div className="grid grid-cols-1 lg:grid-cols-3 gap-6">
          <div className="lg:col-span-2 bg-zinc-900/40 border border-zinc-800 rounded-2xl p-4 md:p-6 h-[400px]">
            <h2 className="text-zinc-400 text-sm font-medium mb-6">Son 14 Günlük Performans</h2>
            <div className="w-full h-[300px]">
              <ResponsiveContainer width="100%" height="100%">
                <LineChart data={fundData.chart} margin={{ top: 5, right: 20, bottom: 5, left: 0 }}>
                  <CartesianGrid strokeDasharray="3 3" stroke="#27272a" vertical={false} />
                  <XAxis dataKey="date" stroke="#71717a" fontSize={12} tickLine={false} axisLine={false} />
                  <YAxis stroke="#71717a" fontSize={12} tickLine={false} axisLine={false} domain={['dataMin - 0.5', 'dataMax + 0.5']} tickFormatter={(value) => `₺${value.toFixed(2)}`} />
                  <Tooltip contentStyle={{ backgroundColor: '#18181b', borderColor: '#27272a', borderRadius: '8px' }} itemStyle={{ color: '#22d3ee' }} />
                  <Line type="monotone" dataKey="price" name="Fiyat" stroke="#22d3ee" strokeWidth={3} dot={{ r: 4, fill: '#22d3ee', strokeWidth: 0 }} activeDot={{ r: 6, fill: '#fff', stroke: '#22d3ee', strokeWidth: 2 }} />
                </LineChart>
              </ResponsiveContainer>
            </div>
          </div>

          <div className="bg-zinc-900/40 border border-zinc-800 rounded-2xl p-6">
            <h3 className="text-white font-medium mb-6">Fon Özeti</h3>
            <div className="space-y-4">
              <div className="flex justify-between items-center pb-4 border-b border-zinc-800/50">
                <span className="text-zinc-500 text-sm">Risk Değeri</span>
                <span className="text-white font-medium">{fundData.risk}</span>
              </div>
              <div className="flex justify-between items-center pb-4 border-b border-zinc-800/50">
                <span className="text-zinc-500 text-sm">Aylık Getiri</span>
                <span className="text-emerald-400 font-medium">{fundData.monthlyReturn}</span>
              </div>
              <div className="flex justify-between items-center pb-4 border-b border-zinc-800/50">
                <span className="text-zinc-500 text-sm">Yıllık Getiri</span>
                <span className="text-emerald-400 font-medium">{fundData.yearlyReturn}</span>
              </div>
            </div>
            <button className="w-full mt-8 bg-cyan-600 hover:bg-cyan-500 text-white font-medium py-3 rounded-lg transition-colors">
              Portföyüme Ekle
            </button>
          </div>
        </div>
      </div>
    </div>
  );
}