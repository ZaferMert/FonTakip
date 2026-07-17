import { useState, useEffect } from 'react';
import { useParams, Link } from 'react-router-dom';
import { LineChart, Line, XAxis, YAxis, CartesianGrid, Tooltip, ResponsiveContainer } from 'recharts';
import axios from 'axios';

export default function FundDetail() {
  const { id } = useParams();
  const [isLoading, setIsLoading] = useState(true);
  const [error, setError] = useState(null);
  const [fundData, setFundData] = useState(null);
  const [timeRange, setTimeRange] = useState('1A');
  
  const [isFavorite, setIsFavorite] = useState(false);

  useEffect(() => {
    const fetchFavorites = async () => {
      try {
        const token = localStorage.getItem('token');
        if (!token) return; 

        // Adres doğru: http://localhost:5043/api/favorites
        const response = await axios.get('http://localhost:5043/api/favorites', {
          headers: { Authorization: `Bearer ${token}` }
        });
        
        setIsFavorite(response.data.includes(Number(id)));
      } catch (err) {
        console.error("Favoriler getirilirken hata oluştu:", err);
      }
    };

    fetchFavorites();
  }, [id]);

  const toggleFavorite = async () => {
    try {
      const token = localStorage.getItem('token');
      if (!token) {
        alert("Favorilere eklemek için giriş yapmalısınız!");
        return;
      }

      // Backend'in tam beklediği gibi: Adresin sonunda ID var, gövde boş, yaka kartı (token) başlıkta!
      const response = await axios.post(`http://localhost:5043/api/favorites/${id}`, 
        {}, 
        {
          headers: { Authorization: `Bearer ${token}` }
        }
      );
      
      // Gelen isFavorite (true/false) yanıtına göre kalbin durumunu anında güncelle
      setIsFavorite(response.data.isFavorite);
    } catch (err) {
      console.error("Favori işlemi başarısız:", err);
      alert("İşlem sırasında bir hata oluştu.");
    }
  };

  useEffect(() => {
    setIsLoading(true);
    const timer = setTimeout(() => {
      try {
        const mockData = {
          name: "Marmara Capital Hisse Senedi Fonu",
          code: "MAC",
          currentPrice: 14.52,
          dailyChange: "+2.4%",
          risk: "6 / 7",
          monthlyReturn: "%8.5",
          yearlyReturn: "%112.4",
          charts: {
            '1H': [
              { date: '7 Tem', price: 14.10 }, { date: '9 Tem', price: 14.35 },
              { date: '11 Tem', price: 14.20 }, { date: '14 Tem', price: 14.52 },
            ],
            '1A': [
              { date: '14 Haz', price: 13.00 }, { date: '21 Haz', price: 13.20 },
              { date: '28 Haz', price: 13.50 }, { date: '5 Tem', price: 13.65 },
              { date: '14 Tem', price: 14.52 },
            ],
            '3A': [
              { date: 'Nis', price: 11.50 }, { date: 'May', price: 12.80 },
              { date: 'Haz', price: 13.50 }, { date: 'Tem', price: 14.52 },
            ]
          }
        };
        
        setFundData(mockData);
        setIsLoading(false);
      } catch (err) {
        setError("Fon verileri yüklenirken bir sorun oluştu.");
        setIsLoading(false);
      }
    }, 1500);

    return () => clearTimeout(timer);
  }, [id]);

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
          </div>
          <div className="h-[400px] bg-zinc-900/40 border border-zinc-800 rounded-2xl p-6"></div>
        </div>
      </div>
    );
  }

  if (error) {
    return <div className="min-h-screen bg-zinc-950 flex items-center justify-center text-red-400">{error}</div>;
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
                {fundData.code}
              </div>
              <div className="flex items-center gap-4">
                <h1 className="text-2xl md:text-3xl font-medium text-white">{fundData.name}</h1>
                
                <button 
                  onClick={toggleFavorite}
                  className="text-rose-500 hover:text-rose-400 transition-colors focus:outline-none"
                  title="Favorilere Ekle"
                >
                  <svg 
                    className="w-7 h-7 md:w-8 md:h-8" 
                    fill={isFavorite ? "currentColor" : "none"} 
                    viewBox="0 0 24 24" 
                    stroke="currentColor"
                  >
                    <path strokeLinecap="round" strokeLinejoin="round" strokeWidth={isFavorite ? 0 : 2} d="M4.318 6.318a4.5 4.5 0 000 6.364L12 20.364l7.682-7.682a4.5 4.5 0 00-6.364-6.364L12 7.636l-1.318-1.318a4.5 4.5 0 00-6.364 0z" />
                  </svg>
                </button>
              </div>
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
          <div className="lg:col-span-2 bg-zinc-900/40 border border-zinc-800 rounded-2xl p-4 md:p-6 h-[450px]">
            <div className="flex justify-between items-center mb-6">
              <h2 className="text-zinc-400 text-sm font-medium">Performans Grafiği</h2>
              <div className="flex bg-zinc-950 rounded-lg p-1 border border-zinc-800">
                {['1H', '1A', '3A'].map((range) => (
                  <button key={range} onClick={() => setTimeRange(range)} className={`px-3 py-1 text-xs md:text-sm font-medium rounded-md transition-colors ${timeRange === range ? 'bg-zinc-800 text-white' : 'text-zinc-500 hover:text-zinc-300'}`}>
                    {range}
                  </button>
                ))}
              </div>
            </div>
            <div className="w-full h-[300px]">
              <ResponsiveContainer width="100%" height="100%">
                <LineChart data={fundData.charts[timeRange]} margin={{ top: 5, right: 20, bottom: 5, left: 0 }}>
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