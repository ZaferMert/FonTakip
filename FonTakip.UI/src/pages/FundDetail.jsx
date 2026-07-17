import { useState, useEffect } from 'react';
import { useParams, Link } from 'react-router-dom';
import { LineChart, Line, XAxis, YAxis, CartesianGrid, Tooltip, ResponsiveContainer } from 'recharts';
import axios from 'axios';
import DatePicker from 'react-datepicker';
import "react-datepicker/dist/react-datepicker.css";

export default function FundDetail() {
  const { id } = useParams();
  const [isLoading, setIsLoading] = useState(true);
  const [error, setError] = useState(null);
  const [fundData, setFundData] = useState(null);
  const [isFavorite, setIsFavorite] = useState(false);

  // TAKVİM STATE'LERİ: Varsayılan olarak son 1 ayı seçili getirelim (14 Haziran - 14 Temmuz civarı)
  const [startDate, setStartDate] = useState(new Date(2026, 5, 14)); // 14 Haziran 2026
  const [endDate, setEndDate] = useState(new Date(2026, 6, 15)); // 15 Temmuz 2026

  // 1. Favorileri Kontrol Etme (Mevcut kodumuz, dokunmadık)
  useEffect(() => {
    const fetchFavorites = async () => {
      try {
        const token = localStorage.getItem('token');
        if (!token) return; 

        const response = await axios.get('http://localhost:5043/api/favorites', {
          headers: { Authorization: `Bearer ${token}` }
        });
        
        setIsFavorite(response.data.includes(Number(id)));
      } catch (err) {
        console.error("Favoriler getirilirken hata:", err);
      }
    };
    fetchFavorites();
  }, [id]);

  // 2. Favori Ekle/Çıkar Fonksiyonu (Mevcut kodumuz, dokunmadık)
  const toggleFavorite = async () => {
    try {
      const token = localStorage.getItem('token');
      if (!token) {
        alert("Favorilere eklemek için giriş yapmalısınız!");
        return;
      }

      const response = await axios.post(`http://localhost:5043/api/favorites/${id}`, {}, {
        headers: { Authorization: `Bearer ${token}` }
      });
      setIsFavorite(response.data.isFavorite);
    } catch (err) {
      console.error("Favori işlemi başarısız:", err);
    }
  };

  // 3. İŞTE BÜYÜK BULUŞMA: API'den Canlı Veri Çekme
  useEffect(() => {
    const fetchFundDetails = async () => {
      setIsLoading(true);
      setError(null);
      
      try {
        // C# API'mizin beklediği formatta tarihleri ayarlıyoruz (YIL-AY-GÜN)
        const formattedStart = startDate.toISOString().split('T')[0];
        const formattedEnd = endDate.toISOString().split('T')[0];

        // API'ye gidip sadece seçilen tarih aralığındaki fiyatları istiyoruz
        const response = await axios.get(`http://localhost:5043/api/funds/${id}/prices?startDate=${formattedStart}&endDate=${formattedEnd}`);
        
        // API'den gelen veriyi React grafiğinin anladığı dile çeviriyoruz
        const chartData = response.data.map(fp => {
          const dateObj = new Date(fp.date);
          return {
            // Tarihi "14 Haz", "21 Haz" gibi okunaklı formata çeviriyoruz
            date: dateObj.toLocaleDateString('tr-TR', { day: 'numeric', month: 'short' }),
            price: fp.price
          };
        });

        // Fonun diğer bilgileri (isim, risk vs) API'de henüz bir endpoint olmadığı için şimdilik sabit
        setFundData({
          name: id === "1" ? "Marmara Capital Hisse Senedi Fonu" : "Diğer Fon",
          code: id === "1" ? "MAC" : "FON",
          currentPrice: chartData.length > 0 ? chartData[chartData.length - 1].price : 0,
          dailyChange: "+%2.4",
          risk: "6 / 7",
          monthlyReturn: "%8.5",
          yearlyReturn: "%112.4",
          chart: chartData // Artık sabit liste değil, sadece API'den gelen taze veri var!
        });

        setIsLoading(false);
      } catch (err) {
        console.error("Veri çekme hatası:", err);
        setError("Seçilen tarih aralığında fon verisi bulunamadı.");
        setIsLoading(false);
      }
    };

    // Bu useEffect, startDate veya endDate her değiştiğinde OTOMATİK olarak tekrar çalışır!
    fetchFundDetails();
  }, [id, startDate, endDate]);

  if (isLoading) {
    return <div className="min-h-screen bg-zinc-950 flex items-center justify-center text-cyan-400">Veriler Yükleniyor...</div>;
  }

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
                {fundData?.code}
              </div>
              <div className="flex items-center gap-4">
                <h1 className="text-2xl md:text-3xl font-medium text-white">{fundData?.name}</h1>
                <button onClick={toggleFavorite} className="text-rose-500 hover:text-rose-400 transition-colors">
                  <svg className="w-7 h-7 md:w-8 md:h-8" fill={isFavorite ? "currentColor" : "none"} viewBox="0 0 24 24" stroke="currentColor">
                    <path strokeLinecap="round" strokeLinejoin="round" strokeWidth={isFavorite ? 0 : 2} d="M4.318 6.318a4.5 4.5 0 000 6.364L12 20.364l7.682-7.682a4.5 4.5 0 00-6.364-6.364L12 7.636l-1.318-1.318a4.5 4.5 0 00-6.364 0z" />
                  </svg>
                </button>
              </div>
            </div>
            <div className="text-left sm:text-right">
              <p className="text-zinc-500 text-sm mb-1">Güncel Fiyat</p>
              <div className="flex items-baseline gap-3">
                <span className="text-3xl font-bold text-white">{fundData?.currentPrice} ₺</span>
                <span className="text-emerald-400 font-medium">{fundData?.dailyChange}</span>
              </div>
            </div>
          </div>
        </div>

        {/* ÖZEL TARİH FİLTRE ÇUBUĞU */}
        <div className="flex items-center mb-4">
          <div className="flex items-center bg-zinc-900/60 border border-zinc-800/80 px-4 py-2 rounded-lg gap-2 shadow-sm">
            <svg className="w-4 h-4 text-zinc-400 mr-1" fill="none" viewBox="0 0 24 24" stroke="currentColor">
              <path strokeLinecap="round" strokeLinejoin="round" strokeWidth={2} d="M8 7V3m8 4V3m-9 8h10M5 21h14a2 2 0 002-2V7a2 2 0 00-2-2H5a2 2 0 00-2 2v12a2 2 0 002 2z" />
            </svg>
            <span className="text-sm font-medium text-zinc-400 mr-2">Tarih:</span>
            <DatePicker
              selected={startDate}
              onChange={(date) => setStartDate(date)}
              selectsStart
              startDate={startDate}
              endDate={endDate}
              dateFormat="dd.MM.yyyy"
              className="bg-transparent text-white text-sm w-20 focus:outline-none cursor-pointer"
            />
            <span className="text-zinc-600 font-bold">-</span>
            <DatePicker
              selected={endDate}
              onChange={(date) => setEndDate(date)}
              selectsEnd
              startDate={startDate}
              endDate={endDate}
              minDate={startDate}
              dateFormat="dd.MM.yyyy"
              className="bg-transparent text-white text-sm w-20 focus:outline-none cursor-pointer pl-2"
            />
          </div>
        </div>

        <div className="grid grid-cols-1 lg:grid-cols-3 gap-6">
          <div className="lg:col-span-2 bg-zinc-900/40 border border-zinc-800 rounded-2xl p-4 md:p-6 h-[450px]">
            <div className="flex justify-between items-center mb-6">
              <h2 className="text-zinc-400 text-sm font-medium">Performans Grafiği</h2>
              {/* Tarih takvimimiz olduğu için o kafa karıştırıcı 1H 1A butonlarını kaldırdık, ekran tertemiz oldu! */}
            </div>
            
            {error ? (
              <div className="w-full h-[300px] flex items-center justify-center text-rose-400 border border-rose-500/20 rounded-xl bg-rose-500/5">
                {error}
              </div>
            ) : (
              <div className="w-full h-[300px]">
                <ResponsiveContainer width="100%" height="100%">
                  <LineChart data={fundData?.chart} margin={{ top: 5, right: 20, bottom: 5, left: 0 }}>
                    <CartesianGrid strokeDasharray="3 3" stroke="#27272a" vertical={false} />
                    <XAxis dataKey="date" stroke="#71717a" fontSize={12} tickLine={false} axisLine={false} />
                    <YAxis stroke="#71717a" fontSize={12} tickLine={false} axisLine={false} domain={['auto', 'auto']} tickFormatter={(value) => `₺${value.toFixed(2)}`} />
                    <Tooltip contentStyle={{ backgroundColor: '#18181b', borderColor: '#27272a', borderRadius: '8px' }} itemStyle={{ color: '#22d3ee' }} />
                    <Line type="monotone" dataKey="price" name="Fiyat" stroke="#22d3ee" strokeWidth={3} dot={{ r: 4, fill: '#22d3ee', strokeWidth: 0 }} activeDot={{ r: 6, fill: '#fff', stroke: '#22d3ee', strokeWidth: 2 }} />
                  </LineChart>
                </ResponsiveContainer>
              </div>
            )}
          </div>

          <div className="bg-zinc-900/40 border border-zinc-800 rounded-2xl p-6">
            <h3 className="text-white font-medium mb-6">Fon Özeti</h3>
            <div className="space-y-4">
              <div className="flex justify-between items-center pb-4 border-b border-zinc-800/50">
                <span className="text-zinc-500 text-sm">Risk Değeri</span>
                <span className="text-white font-medium">{fundData?.risk}</span>
              </div>
              <div className="flex justify-between items-center pb-4 border-b border-zinc-800/50">
                <span className="text-zinc-500 text-sm">Aylık Getiri</span>
                <span className="text-emerald-400 font-medium">{fundData?.monthlyReturn}</span>
              </div>
              <div className="flex justify-between items-center pb-4 border-b border-zinc-800/50">
                <span className="text-zinc-500 text-sm">Yıllık Getiri</span>
                <span className="text-emerald-400 font-medium">{fundData?.yearlyReturn}</span>
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