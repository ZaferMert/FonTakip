import { useState } from 'react';
import { Link } from 'react-router-dom';
import { LineChart, Line, XAxis, YAxis, CartesianGrid, Tooltip, ResponsiveContainer, Legend } from 'recharts';

export default function CompareFunds() {
  // Varsayılan olarak MAC ve AFT seçili gelsin ki sayfa çökmesin
  const [fund1, setFund1] = useState('MAC');
  const [fund2, setFund2] = useState('AFT');

  const fundDetails = {
    MAC: { name: "Marmara Capital Hisse Senedi Fonu", risk: 6, monthly: "%8.5", yearly: "%112.4" },
    AFT: { name: "Ak Portföy Teknoloji Şirketleri Fonu", risk: 7, monthly: "%12.1", yearly: "%145.2" },
    YAF: { name: "Yapı Kredi Altın Fonu", risk: 5, monthly: "%4.2", yearly: "%85.6" },
    NNF: { name: "Hedef Portföy Birinci Hisse Senedi Fonu", risk: 6, monthly: "%9.3", yearly: "%120.1" }
  };

  const comparisonData = [
    { date: 'Nis', MAC: 11.50, AFT: 22.10, YAF: 95.00, NNF: 6.20 },
    { date: 'May', MAC: 12.80, AFT: 24.50, YAF: 102.30, NNF: 7.10 },
    { date: 'Haz', MAC: 13.50, AFT: 26.80, YAF: 108.50, NNF: 7.80 },
    { date: 'Tem', MAC: 14.52, AFT: 28.30, YAF: 112.40, NNF: 8.75 }
  ];

  return (
    <div className="min-h-screen bg-zinc-950 text-white p-4 md:p-8">
      <div className="max-w-[1000px] mx-auto">
        <h1 className="text-2xl font-bold mb-8 text-cyan-400">Fon Karşılaştırma</h1>
        
        {/* Fon Seçim Alanı */}
        <div className="grid grid-cols-1 md:grid-cols-2 gap-6 mb-8">
          <div className="bg-zinc-900/40 p-4 border border-zinc-800 rounded-xl">
            <label className="block text-zinc-400 text-sm mb-2">1. Fonu Seçin</label>
            <select 
              value={fund1} 
              onChange={(e) => setFund1(e.target.value)}
              className="w-full bg-zinc-800 border border-zinc-700 text-white rounded-lg p-2.5 focus:outline-none focus:border-cyan-500"
            >
              <option value="MAC">MAC - Marmara Capital</option>
              <option value="AFT">AFT - Ak Portföy Teknoloji</option>
              <option value="YAF">YAF - Yapı Kredi Altın</option>
              <option value="NNF">NNF - Hedef Portföy Birinci Hisse</option>
            </select>
          </div>

          <div className="bg-zinc-900/40 p-4 border border-zinc-800 rounded-xl">
            <label className="block text-zinc-400 text-sm mb-2">2. Fonu Seçin</label>
            <select 
              value={fund2} 
              onChange={(e) => setFund2(e.target.value)}
              className="w-full bg-zinc-800 border border-zinc-700 text-white rounded-lg p-2.5 focus:outline-none focus:border-rose-500"
            >
              <option value="MAC">MAC - Marmara Capital</option>
              <option value="AFT">AFT - Ak Portföy Teknoloji</option>
              <option value="YAF">YAF - Yapı Kredi Altın</option>
              <option value="NNF">NNF - Hedef Portföy Birinci Hisse</option>
            </select>
          </div>
        </div>

        {/* Karşılaştırma Grafiği */}
        <div className="bg-zinc-900/40 border border-zinc-800 rounded-2xl p-4 md:p-6 h-[400px] mb-8">
          <h2 className="text-zinc-400 text-sm font-medium mb-6">Performans Karşılaştırması (Son 3 Ay)</h2>
          <ResponsiveContainer width="100%" height="100%">
            <LineChart data={comparisonData} margin={{ top: 5, right: 20, bottom: 20, left: 0 }}>
              <CartesianGrid strokeDasharray="3 3" stroke="#27272a" vertical={false} />
              <XAxis dataKey="date" stroke="#71717a" fontSize={12} tickLine={false} axisLine={false} />
              <YAxis stroke="#71717a" fontSize={12} tickLine={false} axisLine={false} tickFormatter={(val) => `₺${val}`} />
              <Tooltip contentStyle={{ backgroundColor: '#18181b', borderColor: '#27272a', borderRadius: '8px' }} />
              <Legend verticalAlign="top" height={36} />
              <Line type="monotone" dataKey={fund1} name={fundDetails[fund1].name} stroke="#22d3ee" strokeWidth={3} dot={{ r: 4 }} activeDot={{ r: 6 }} />
              <Line type="monotone" dataKey={fund2} name={fundDetails[fund2].name} stroke="#f43f5e" strokeWidth={3} dot={{ r: 4 }} activeDot={{ r: 6 }} />
            </LineChart>
          </ResponsiveContainer>
        </div>

        {/* Veri Karşılaştırma Tablosu */}
        <div className="bg-zinc-900/40 border border-zinc-800 rounded-2xl overflow-hidden">
          <table className="w-full text-left border-collapse">
            <thead>
              <tr className="bg-zinc-900 border-b border-zinc-800">
                <th className="p-4 text-zinc-400 font-medium">Özellik</th>
                <th className="p-4 text-cyan-400 font-bold w-2/5">{fund1}</th>
                <th className="p-4 text-rose-400 font-bold w-2/5">{fund2}</th>
              </tr>
            </thead>
            <tbody className="divide-y divide-zinc-800/50">
              <tr>
                <td className="p-4 text-zinc-400 text-sm">Risk Değeri</td>
                <td className="p-4 font-medium">{fundDetails[fund1].risk} / 7</td>
                <td className="p-4 font-medium">{fundDetails[fund2].risk} / 7</td>
              </tr>
              <tr>
                <td className="p-4 text-zinc-400 text-sm">Aylık Getiri</td>
                <td className="p-4 text-emerald-400">{fundDetails[fund1].monthly}</td>
                <td className="p-4 text-emerald-400">{fundDetails[fund2].monthly}</td>
              </tr>
              <tr>
                <td className="p-4 text-zinc-400 text-sm">Yıllık Getiri</td>
                <td className="p-4 text-emerald-400">{fundDetails[fund1].yearly}</td>
                <td className="p-4 text-emerald-400">{fundDetails[fund2].yearly}</td>
              </tr>
            </tbody>
          </table>
        </div>

      </div>
    </div>
  );
}