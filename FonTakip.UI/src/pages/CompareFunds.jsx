import { useState, useEffect } from 'react';
import { LineChart, Line, XAxis, YAxis, CartesianGrid, Tooltip, ResponsiveContainer, Legend } from 'recharts';
import axios from 'axios';
import DatePicker from 'react-datepicker';
import "react-datepicker/dist/react-datepicker.css";

export default function CompareFunds() {
  // Seçili Fon ID'leri (Veritabanındaki ID'ler: 1=MAC, 2=AFT, 3=YAF, 4=NNF)
  const [fund1Id, setFund1Id] = useState('1'); 
  const [fund2Id, setFund2Id] = useState('2');

  const [startDate, setStartDate] = useState(new Date(2026, 5, 14));
  const [endDate, setEndDate] = useState(new Date(2026, 6, 15));

  const [chartData, setChartData] = useState([]);
  const [isLoading, setIsLoading] = useState(false);
  const [error, setError] = useState(null);

  // Veritabanımızdaki 4 Fonun Sabit Bilgileri (İleride API'den çekilebilir)
  const fundDetails = {
    '1': { name: "Marmara Capital Hisse Senedi", code: "MAC", risk: 6, return: "%112.4", color: "#22d3ee" }, // Cyan
    '2': { name: "Ak Portföy Teknoloji", code: "AFT", risk: 7, return: "%145.2", color: "#a855f7" }, // Purple
    '3': { name: "Yapı Kredi Altın", code: "YAF", risk: 5, return: "%85.6", color: "#eab308" }, // Yellow
    '4': { name: "Hedef Portföy Birinci Hisse", code: "NNF", risk: 6, return: "%120.1", color: "#ec4899" } // Pink
  };

  useEffect(() => {
    const fetchComparisonData = async () => {
      setIsLoading(true);
      setError(null);
      try {
        const formattedStart = startDate.toISOString().split('T')[0];
        const formattedEnd = endDate.toISOString().split('T')[0];

        // İki fonun verisini AYNI ANDA çekiyoruz (Promise.all ile paralel ve hızlı çalışır)
        const [res1, res2] = await Promise.all([
          axios.get(`http://localhost:5043/api/funds/${fund1Id}/prices?startDate=${formattedStart}&endDate=${formattedEnd}`),
          axios.get(`http://localhost:5043/api/funds/${fund2Id}/prices?startDate=${formattedStart}&endDate=${formattedEnd}`)
        ]);

        // Gelen iki farklı listeyi, tarihlere göre tek bir objede birleştiriyoruz (Recharts'ın anlayacağı format)
        const mergedDataMap = {};

        res1.data.forEach(item => {
          const d = new Date(item.date).toLocaleDateString('tr-TR', { day: 'numeric', month: 'short' });
          mergedDataMap[d] = { date: d, Fund1: item.price };
        });

        res2.data.forEach(item => {
          const d = new Date(item.date).toLocaleDateString('tr-TR', { day: 'numeric', month: 'short' });
          if (!mergedDataMap[d]) mergedDataMap[d] = { date: d };
          mergedDataMap[d].Fund2 = item.price;
        });

        // Objeyi Recharts için diziye (array) çeviriyoruz
        const finalChartData = Object.values(mergedDataMap);
        
        if (finalChartData.length === 0) {
           setError("Seçilen tarih aralığında veri bulunamadı.");
        }

        setChartData(finalChartData);
        setIsLoading(false);
      } catch (err) {
        console.error("Karşılaştırma verisi çekilemedi:", err);
        setError("Veriler yüklenirken bir sorun oluştu veya bu tarihte fiyat yok.");
        setIsLoading(false);
      }
    };

    fetchComparisonData();
  }, [fund1Id, fund2Id, startDate, endDate]);

  return (
    <div className="min-h-screen bg-zinc-950 text-white p-4 md:p-8">
      <div className="max-w-[1200px] mx-auto">
        <h1 className="text-2xl font-medium tracking-tight text-zinc-100 mb-8">Fon Karşılaştırma</h1>

        {/* KONTROL PANELİ: Fon Seçimi ve Tarih */}
        <div className="bg-zinc-900/40 border border-zinc-800 rounded-2xl p-6 mb-8 flex flex-col md:flex-row gap-6 items-center justify-between">
          
          {/* Fon 1 Seçimi */}
          <div className="w-full md:w-1/3">
            <label className="block text-xs font-medium text-zinc-500 mb-2">1. Fon (Ana Fon)</label>
            <select 
              value={fund1Id} 
              onChange={(e) => setFund1Id(e.target.value)}
              className="w-full bg-zinc-950 border border-zinc-800 text-cyan-400 font-medium rounded-lg px-4 py-3 focus:outline-none focus:ring-2 focus:ring-cyan-500 appearance-none"
            >
              <option value="1">MAC - Marmara Capital</option>
              <option value="2">AFT - Ak Portföy Teknoloji</option>
              <option value="3">YAF - Yapı Kredi Altın</option>
              <option value="4">NNF - Hedef Portföy Birinci Hisse</option>
            </select>
          </div>

          <div className="hidden md:flex items-center justify-center w-12 h-12 rounded-full bg-zinc-900 border border-zinc-800 shrink-0">
            <span className="text-zinc-500 font-bold text-sm">VS</span>
          </div>

          {/* Fon 2 Seçimi */}
          <div className="w-full md:w-1/3">
            <label className="block text-xs font-medium text-zinc-500 mb-2">2. Fon (Karşılaştırılan)</label>
            <select 
              value={fund2Id} 
              onChange={(e) => setFund2Id(e.target.value)}
              className="w-full bg-zinc-950 border border-zinc-800 text-purple-400 font-medium rounded-lg px-4 py-3 focus:outline-none focus:ring-2 focus:ring-purple-500 appearance-none"
            >
              <option value="1">MAC - Marmara Capital</option>
              <option value="2">AFT - Ak Portföy Teknoloji</option>
              <option value="3">YAF - Yapı Kredi Altın</option>
              <option value="4">NNF - Hedef Portföy Birinci Hisse</option>
            </select>
          </div>

          {/* Tarih Seçimi (Date Picker) */}
          <div className="w-full md:w-auto mt-4 md:mt-0 md:pl-6 md:border-l border-zinc-800">
            <label className="block text-xs font-medium text-zinc-500 mb-2">Tarih Aralığı</label>
            <div className="flex items-center bg-zinc-950 border border-zinc-800 px-3 py-2.5 rounded-lg gap-2">
              <DatePicker selected={startDate} onChange={(date) => setStartDate(date)} selectsStart startDate={startDate} endDate={endDate} dateFormat="dd.MM.yy" className="bg-transparent text-white text-sm w-20 focus:outline-none cursor-pointer" />
              <span className="text-zinc-600 font-bold">-</span>
              <DatePicker selected={endDate} onChange={(date) => setEndDate(date)} selectsEnd startDate={startDate} endDate={endDate} minDate={startDate} dateFormat="dd.MM.yy" className="bg-transparent text-white text-sm w-20 focus:outline-none cursor-pointer" />
            </div>
          </div>
        </div>

        {/* GRAFİK VE ÖZET ALANI */}
        <div className="grid grid-cols-1 lg:grid-cols-4 gap-6">
          <div className="lg:col-span-3 bg-zinc-900/40 border border-zinc-800 rounded-2xl p-6 h-[500px]">
             {isLoading ? (
                <div className="w-full h-full flex items-center justify-center text-zinc-500">Veriler karşılaştırılıyor...</div>
             ) : error ? (
                <div className="w-full h-full flex items-center justify-center text-rose-400">{error}</div>
             ) : (
                <ResponsiveContainer width="100%" height="100%">
                  <LineChart data={chartData} margin={{ top: 20, right: 20, bottom: 20, left: 0 }}>
                    <CartesianGrid strokeDasharray="3 3" stroke="#27272a" vertical={false} />
                    <XAxis dataKey="date" stroke="#71717a" fontSize={12} tickLine={false} axisLine={false} dy={10} />
                    <YAxis stroke="#71717a" fontSize={12} tickLine={false} axisLine={false} domain={['auto', 'auto']} tickFormatter={(value) => `₺${value.toFixed(1)}`} dx={-10} />
                    <Tooltip contentStyle={{ backgroundColor: '#18181b', borderColor: '#27272a', borderRadius: '8px' }} />
                    <Legend verticalAlign="top" height={36} iconType="circle" />
                    
                    {/* Dinamik Renklerle İki Çizgi */}
                    <Line type="monotone" dataKey="Fund1" name={fundDetails[fund1Id].code} stroke={fundDetails[fund1Id].color} strokeWidth={3} dot={{ r: 4, strokeWidth: 0 }} activeDot={{ r: 6, strokeWidth: 2 }} />
                    <Line type="monotone" dataKey="Fund2" name={fundDetails[fund2Id].code} stroke={fundDetails[fund2Id].color} strokeWidth={3} dot={{ r: 4, strokeWidth: 0 }} activeDot={{ r: 6, strokeWidth: 2 }} />
                  </LineChart>
                </ResponsiveContainer>
             )}
          </div>

          <div className="space-y-6">
            {/* Fon 1 Özet Kutusu */}
            <div className={`bg-zinc-900/40 border border-zinc-800 rounded-2xl p-6 border-t-4`} style={{ borderTopColor: fundDetails[fund1Id].color }}>
              <div className="text-xs font-bold text-zinc-500 mb-1">{fundDetails[fund1Id].code}</div>
              <h3 className="text-white font-medium mb-4 text-sm leading-tight">{fundDetails[fund1Id].name}</h3>
              <div className="space-y-3">
                <div className="flex justify-between items-center"><span className="text-zinc-500 text-xs">Risk</span><span className="text-white font-medium text-sm">{fundDetails[fund1Id].risk}/7</span></div>
                <div className="flex justify-between items-center"><span className="text-zinc-500 text-xs">Yıllık Getiri</span><span className="text-emerald-400 font-medium text-sm">{fundDetails[fund1Id].return}</span></div>
              </div>
            </div>

            {/* Fon 2 Özet Kutusu */}
            <div className={`bg-zinc-900/40 border border-zinc-800 rounded-2xl p-6 border-t-4`} style={{ borderTopColor: fundDetails[fund2Id].color }}>
              <div className="text-xs font-bold text-zinc-500 mb-1">{fundDetails[fund2Id].code}</div>
              <h3 className="text-white font-medium mb-4 text-sm leading-tight">{fundDetails[fund2Id].name}</h3>
              <div className="space-y-3">
                <div className="flex justify-between items-center"><span className="text-zinc-500 text-xs">Risk</span><span className="text-white font-medium text-sm">{fundDetails[fund2Id].risk}/7</span></div>
                <div className="flex justify-between items-center"><span className="text-zinc-500 text-xs">Yıllık Getiri</span><span className="text-emerald-400 font-medium text-sm">{fundDetails[fund2Id].return}</span></div>
              </div>
            </div>
          </div>
        </div>

      </div>
    </div>
  );
}