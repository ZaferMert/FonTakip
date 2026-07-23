import { useState, useEffect } from 'react';
import { LineChart, Line, XAxis, YAxis, CartesianGrid, Tooltip, ResponsiveContainer, Legend } from 'recharts';
import DatePicker from 'react-datepicker';
import "react-datepicker/dist/react-datepicker.css";
import api from '../api';

export default function CompareFunds() {
  const [fundsList, setFundsList] = useState([]);
  const [fund1Id, setFund1Id] = useState('');
  const [fund2Id, setFund2Id] = useState('');

  const bitisTarihi = new Date();
  const baslangicTarihi = new Date();
  baslangicTarihi.setMonth(bitisTarihi.getMonth() - 1);

  const [startDate, setStartDate] = useState(baslangicTarihi);
  const [endDate, setEndDate] = useState(bitisTarihi);

  const [chartData, setChartData] = useState([]);
  const [isLoading, setIsLoading] = useState(false);
  const [error, setError] = useState(null);

  useEffect(() => {
    const fetchFunds = async () => {
      try {
        const response = await api.get('/funds');
        if (response.data && response.data.length > 0) {
          setFundsList(response.data);
          setFund1Id(String(response.data[0].id));
          if (response.data.length > 1) {
            setFund2Id(String(response.data[1].id));
          } else {
            setFund2Id(String(response.data[0].id));
          }
        }
      } catch (err) {
        console.error("Fon listesi alınamadı:", err);
      }
    };
    fetchFunds();
  }, []);

  useEffect(() => {
    if (!fund1Id || !fund2Id) return;

    const fetchComparisonData = async () => {
      setIsLoading(true);
      setError(null);
      try {
        const formattedStart = startDate.toISOString().split('T')[0];
        const formattedEnd = endDate.toISOString().split('T')[0];

        const [res1, res2] = await Promise.all([
          api.get(`/funds/${fund1Id}/prices?startDate=${formattedStart}&endDate=${formattedEnd}`),
          api.get(`/funds/${fund2Id}/prices?startDate=${formattedStart}&endDate=${formattedEnd}`)
        ]);

        const fund1Obj = fundsList.find(f => String(f.id) === String(fund1Id));
        const fund2Obj = fundsList.find(f => String(f.id) === String(fund2Id));

        const f1Code = fund1Obj ? fund1Obj.code : 'Fon 1';
        const f2Code = fund2Obj ? fund2Obj.code : 'Fon 2';

        const mergedDataMap = {};

        if (res1.data && Array.isArray(res1.data)) {
          res1.data.forEach(item => {
            const d = new Date(item.date).toLocaleDateString('tr-TR', { day: 'numeric', month: 'short' });
            mergedDataMap[d] = { date: d, [f1Code]: item.price };
          });
        }

        if (res2.data && Array.isArray(res2.data)) {
          res2.data.forEach(item => {
            const d = new Date(item.date).toLocaleDateString('tr-TR', { day: 'numeric', month: 'short' });
            if (!mergedDataMap[d]) mergedDataMap[d] = { date: d };
            mergedDataMap[d][f2Code] = item.price;
          });
        }

        const finalChartData = Object.values(mergedDataMap);
        
        if (finalChartData.length === 0) {
          setError("Seçilen tarih aralığında fiyat verisi bulunamadı.");
        }

        setChartData(finalChartData);
      } catch (err) {
        console.error("Karşılaştırma verisi çekilemedi:", err);
        setError("Seçilen fonlara ait fiyat geçmişi bulunamadı.");
      } finally {
        setIsLoading(false);
      }
    };

    fetchComparisonData();
  }, [fund1Id, fund2Id, startDate, endDate, fundsList]);

  const selectedFund1 = fundsList.find(f => String(f.id) === String(fund1Id));
  const selectedFund2 = fundsList.find(f => String(f.id) === String(fund2Id));

  return (
    <div className="min-h-screen bg-zinc-950 text-white p-4 md:p-8">
      <div className="max-w-[1300px] mx-auto">
        <h1 className="text-2xl font-medium tracking-tight text-zinc-100 mb-2">Fon Karşılaştırma</h1>
        <p className="text-zinc-400 text-sm mb-8">Canlı TEFAS verileri üzerinden fonları yan yana karşılaştırın.</p>

        <div className="bg-zinc-900/40 border border-zinc-800 rounded-2xl p-6 mb-8 flex flex-col md:flex-row gap-6 items-center justify-between">
          
          <div className="w-full md:w-1/3">
            <label className="block text-xs font-medium text-zinc-500 mb-2">1. Fon (Ana Fon)</label>
            <select 
              value={fund1Id} 
              onChange={(e) => setFund1Id(e.target.value)}
              className="w-full bg-zinc-950 border border-zinc-800 text-cyan-400 font-medium rounded-lg px-4 py-3 focus:outline-none focus:ring-2 focus:ring-cyan-500 cursor-pointer"
            >
              {fundsList.map(fund => (
                <option key={fund.id} value={fund.id}>
                  {fund.code} - {fund.name}
                </option>
              ))}
            </select>
          </div>

          <div className="hidden md:flex items-center justify-center w-12 h-12 rounded-full bg-zinc-900 border border-zinc-800 shrink-0">
            <span className="text-zinc-400 font-bold text-sm">VS</span>
          </div>

          <div className="w-full md:w-1/3">
            <label className="block text-xs font-medium text-zinc-500 mb-2">2. Fon (Karşılaştırılan)</label>
            <select 
              value={fund2Id} 
              onChange={(e) => setFund2Id(e.target.value)}
              className="w-full bg-zinc-950 border border-zinc-800 text-purple-400 font-medium rounded-lg px-4 py-3 focus:outline-none focus:ring-2 focus:ring-purple-500 cursor-pointer"
            >
              {fundsList.map(fund => (
                <option key={fund.id} value={fund.id}>
                  {fund.code} - {fund.name}
                </option>
              ))}
            </select>
          </div>

          <div className="w-full md:w-auto mt-4 md:mt-0 md:pl-6 md:border-l border-zinc-800">
            <label className="block text-xs font-medium text-zinc-500 mb-2">Tarih Aralığı</label>
            <div className="flex items-center bg-zinc-950 border border-zinc-800 px-3 py-2.5 rounded-lg gap-2">
              <DatePicker selected={startDate} onChange={(date) => setStartDate(date)} selectsStart startDate={startDate} endDate={endDate} dateFormat="dd.MM.yy" className="bg-transparent text-white text-sm w-20 focus:outline-none cursor-pointer" />
              <span className="text-zinc-600 font-bold">-</span>
              <DatePicker selected={endDate} onChange={(date) => setEndDate(date)} selectsEnd startDate={startDate} endDate={endDate} minDate={startDate} dateFormat="dd.MM.yy" className="bg-transparent text-white text-sm w-20 focus:outline-none cursor-pointer" />
            </div>
          </div>
        </div>

        <div className="grid grid-cols-1 lg:grid-cols-4 gap-6">
          <div className="lg:col-span-3 bg-zinc-900/40 border border-zinc-800 rounded-2xl p-6 h-[480px]">
             {isLoading ? (
                <div className="w-full h-full flex flex-col items-center justify-center text-cyan-400 gap-2">
                  <div className="animate-spin inline-block w-6 h-6 border-2 border-cyan-500 border-t-transparent rounded-full"></div>
                  <span>Veriler karşılaştırılıyor...</span>
                </div>
             ) : error ? (
                <div className="w-full h-full flex items-center justify-center text-rose-400 border border-rose-500/20 bg-rose-500/5 rounded-xl">{error}</div>
             ) : (
                <ResponsiveContainer width="100%" height="100%">
                  <LineChart data={chartData} margin={{ top: 20, right: 20, bottom: 20, left: 0 }}>
                    <CartesianGrid strokeDasharray="3 3" stroke="#27272a" vertical={false} />
                    <XAxis dataKey="date" stroke="#71717a" fontSize={12} tickLine={false} axisLine={false} dy={10} />
                    <YAxis stroke="#71717a" fontSize={12} tickLine={false} axisLine={false} domain={['auto', 'auto']} tickFormatter={(value) => `₺${Number(value).toFixed(2)}`} dx={-10} />
                    <Tooltip contentStyle={{ backgroundColor: '#18181b', borderColor: '#27272a', borderRadius: '8px' }} />
                    <Legend verticalAlign="top" height={36} iconType="circle" />
                    
                    {selectedFund1 && (
                      <Line type="monotone" dataKey={selectedFund1.code} name={selectedFund1.code} stroke="#22d3ee" strokeWidth={3} dot={{ r: 4, strokeWidth: 0 }} activeDot={{ r: 6, strokeWidth: 2 }} />
                    )}
                    {selectedFund2 && (
                      <Line type="monotone" dataKey={selectedFund2.code} name={selectedFund2.code} stroke="#a855f7" strokeWidth={3} dot={{ r: 4, strokeWidth: 0 }} activeDot={{ r: 6, strokeWidth: 2 }} />
                    )}
                  </LineChart>
                </ResponsiveContainer>
             )}
          </div>

          <div className="space-y-6">
            {selectedFund1 && (
              <div className="bg-zinc-900/40 border border-zinc-800 rounded-2xl p-6 border-t-4 border-t-cyan-400">
                <div className="text-xs font-bold text-cyan-400 mb-1">{selectedFund1.code}</div>
                <h3 className="text-white font-medium mb-4 text-sm leading-tight">{selectedFund1.name}</h3>
                <div className="space-y-3 text-xs">
                  <div className="flex justify-between items-center"><span className="text-zinc-500">Kategori</span><span className="text-white font-medium">Katılım Fonu</span></div>
                  <div className="flex justify-between items-center"><span className="text-zinc-500">Risk Seviyesi</span><span className="text-cyan-400 font-bold">{selectedFund1.risk || 3}/7</span></div>
                  <div className="flex justify-between items-center"><span className="text-zinc-500">Yön. Ücreti</span><span className="text-white font-medium">%{selectedFund1.managementFee || 1.5}</span></div>
                  <div className="flex justify-between items-center"><span className="text-zinc-500">Yatırımcı</span><span className="text-white font-medium">{selectedFund1.investorCount ? selectedFund1.investorCount.toLocaleString('tr-TR') : '-'}</span></div>
                </div>
              </div>
            )}

            {selectedFund2 && (
              <div className="bg-zinc-900/40 border border-zinc-800 rounded-2xl p-6 border-t-4 border-t-purple-400">
                <div className="text-xs font-bold text-purple-400 mb-1">{selectedFund2.code}</div>
                <h3 className="text-white font-medium mb-4 text-sm leading-tight">{selectedFund2.name}</h3>
                <div className="space-y-3 text-xs">
                  <div className="flex justify-between items-center"><span className="text-zinc-500">Kategori</span><span className="text-white font-medium">Katılım Fonu</span></div>
                  <div className="flex justify-between items-center"><span className="text-zinc-500">Risk Seviyesi</span><span className="text-purple-400 font-bold">{selectedFund2.risk || 3}/7</span></div>
                  <div className="flex justify-between items-center"><span className="text-zinc-500">Yön. Ücreti</span><span className="text-white font-medium">%{selectedFund2.managementFee || 1.5}</span></div>
                  <div className="flex justify-between items-center"><span className="text-zinc-500">Yatırımcı</span><span className="text-white font-medium">{selectedFund2.investorCount ? selectedFund2.investorCount.toLocaleString('tr-TR') : '-'}</span></div>
                </div>
              </div>
            )}
          </div>
        </div>

      </div>
    </div>
  );
}