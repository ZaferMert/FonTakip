import { useState, useEffect } from 'react';
import { Link } from 'react-router-dom';
import axios from 'axios';
import { PieChart, Pie, Cell, Tooltip, ResponsiveContainer } from 'recharts';

export default function Portfolio() {
  const [portfolioItems, setPortfolioItems] = useState([]);
  const [isLoading, setIsLoading] = useState(true);
  const [error, setError] = useState('');

  useEffect(() => {
    const fetchPortfolio = async () => {
      try {
        const token = localStorage.getItem('token');
        if (!token) {
          setError('Portföyünüzü görmek için lütfen giriş yapın.');
          setIsLoading(false);
          return;
        }

        const response = await axios.get('http://localhost:5043/api/portfolios', {
          headers: { Authorization: `Bearer ${token}` }
        });

        const safeData = response.data.map(item => ({
          id: item.id || item.Id,
          fundId: item.fundId || item.FundId,
          fundCode: item.fundCode || item.FundCode || '-',
          fundName: item.fundName || item.FundName || 'Bilinmeyen Fon',
          shares: Number(item.shares || item.Shares || 0),
          averageCost: Number(item.averageCost || item.AverageCost || 0),
          totalCost: Number(item.totalCost || item.TotalCost || 0)
        }));

        setPortfolioItems(safeData);
      } catch (err) {
        console.error("Portföy verisi çekilemedi:", err);
        setError('Portföy verileri yüklenirken bir hata oluştu.');
      } finally {
        setIsLoading(false);
      }
    };

    fetchPortfolio();
  }, []);

  const totalInvestment = portfolioItems.reduce((acc, item) => acc + item.totalCost, 0);

  const chartData = portfolioItems.map(item => ({
    name: item.fundCode,
    value: item.totalCost
  }));

  const COLORS = ['#22d3ee', '#818cf8', '#34d399', '#f472b6', '#fbbf24', '#a78bfa'];

  if (isLoading) {
    return <div className="min-h-screen bg-zinc-950 flex items-center justify-center text-cyan-400">Portföyünüz Yükleniyor...</div>;
  }

  return (
    <div className="min-h-screen bg-zinc-950 text-white p-4 md:p-8">
      <div className="max-w-[1200px] mx-auto">
        
        <div className="mb-8 flex justify-between items-end">
          <div>
            <h1 className="text-2xl font-medium tracking-tight text-zinc-100">Portföyüm</h1>
            <p className="text-zinc-400 mt-1 text-sm">Yatırımlarınızın güncel durumunu takip edin.</p>
          </div>
          <Link to="/funds" className="bg-zinc-900 hover:bg-zinc-800 border border-zinc-800 text-sm font-medium px-4 py-2 rounded-lg transition-colors">
            + Yeni Fon Ekle
          </Link>
        </div>

        {error ? (
          <div className="bg-rose-500/10 border border-rose-500/20 text-rose-400 p-6 rounded-2xl text-center">
            {error}
          </div>
        ) : portfolioItems.length === 0 ? (
          <div className="bg-zinc-900/40 border border-zinc-800 p-12 rounded-2xl text-center">
            <div className="w-16 h-16 bg-zinc-800 rounded-full flex items-center justify-center mx-auto mb-4">
              <svg className="w-8 h-8 text-zinc-500" fill="none" viewBox="0 0 24 24" stroke="currentColor">
                <path strokeLinecap="round" strokeLinejoin="round" strokeWidth={1.5} d="M12 6v6m0 0v6m0-6h6m-6 0H6" />
              </svg>
            </div>
            <h2 className="text-lg font-medium text-white mb-2">Portföyünüz Boş</h2>
            <p className="text-zinc-500 text-sm mb-6 max-w-md mx-auto">Henüz portföyünüze hiçbir fon eklememişsiniz. Piyasalara giderek beğendiğiniz fonları portföyünüze dahil edebilirsiniz.</p>
            <Link to="/funds" className="inline-block bg-cyan-600 hover:bg-cyan-500 text-white font-medium px-6 py-2.5 rounded-lg transition-colors">
              Piyasaları Keşfet
            </Link>
          </div>
        ) : (
          <div className="grid grid-cols-1 lg:grid-cols-3 gap-6">
            
            <div className="lg:col-span-1 space-y-6">

              <div className="bg-gradient-to-br from-cyan-950/40 to-zinc-900/40 border border-cyan-900/30 rounded-2xl p-6 relative overflow-hidden">
                <div className="absolute top-0 right-0 p-4 opacity-10">
                  <svg className="w-24 h-24 text-cyan-500" fill="currentColor" viewBox="0 0 24 24">
                    <path d="M12 2C6.48 2 2 6.48 2 12s4.48 10 10 10 10-4.48 10-10S17.52 2 12 2zm1 15h-2v-2h2v2zm0-4h-2V7h2v6z"/>
                  </svg>
                </div>
                <h3 className="text-zinc-400 text-sm font-medium mb-2">Toplam Yatırım Tutarı</h3>
                <div className="text-4xl font-bold text-white mb-1">
                  {totalInvestment.toLocaleString('tr-TR', { minimumFractionDigits: 2, maximumFractionDigits: 2 })} ₺
                </div>
                <div className="text-emerald-400 text-sm font-medium flex items-center gap-1">
                  <svg className="w-4 h-4" fill="none" viewBox="0 0 24 24" stroke="currentColor">
                    <path strokeLinecap="round" strokeLinejoin="round" strokeWidth={2} d="M13 7h8m0 0v8m0-8l-8 8-4-4-6 6" />
                  </svg>
                  Güncel Maliyet Görünümü
                </div>
              </div>

              <div className="bg-zinc-900/40 border border-zinc-800 rounded-2xl p-6 h-[300px] flex flex-col">
                <h3 className="text-zinc-400 text-sm font-medium mb-4">Varlık Dağılımı</h3>
                <div className="flex-1 w-full">
                  <ResponsiveContainer width="100%" height="100%">
                    <PieChart>
                      <Pie
                        data={chartData}
                        cx="50%"
                        cy="50%"
                        innerRadius={60}
                        outerRadius={80}
                        paddingAngle={5}
                        dataKey="value"
                        stroke="none"
                      >
                        {chartData.map((entry, index) => (
                          <Cell key={`cell-${index}`} fill={COLORS[index % COLORS.length]} />
                        ))}
                      </Pie>
                      <Tooltip 
                        formatter={(value) => `${value.toLocaleString('tr-TR', { minimumFractionDigits: 2 })} ₺`}
                        contentStyle={{ backgroundColor: '#18181b', borderColor: '#27272a', borderRadius: '8px', fontSize: '12px' }}
                        itemStyle={{ color: '#fff' }}
                      />
                    </PieChart>
                  </ResponsiveContainer>
                </div>
              </div>

            </div>

            <div className="lg:col-span-2 bg-zinc-900/40 border border-zinc-800 rounded-2xl overflow-hidden flex flex-col">
              <div className="p-6 border-b border-zinc-800 flex justify-between items-center">
                <h3 className="text-white font-medium">Fonlarım</h3>
                <span className="bg-zinc-800 text-zinc-300 text-xs px-2.5 py-1 rounded-full font-medium">
                  {portfolioItems.length} Fon
                </span>
              </div>
              
              <div className="overflow-x-auto">
                <table className="w-full text-left text-sm text-zinc-400">
                  <thead className="text-xs text-zinc-500 uppercase bg-zinc-950/50">
                    <tr>
                      <th className="px-6 py-4 font-medium">Fon</th>
                      <th className="px-6 py-4 font-medium text-right">Adet (Pay)</th>
                      <th className="px-6 py-4 font-medium text-right">Ort. Maliyet</th>
                      <th className="px-6 py-4 font-medium text-right">Toplam Değer</th>
                    </tr>
                  </thead>
                  <tbody className="divide-y divide-zinc-800/50">
                    {portfolioItems.map((item, index) => (
                      <tr key={item.id} className="hover:bg-zinc-800/20 transition-colors group">
                        <td className="px-6 py-4">
                          <Link to={`/funds/${item.fundId}`} className="flex flex-col">
                            <div className="flex items-center gap-2 mb-1">
                              <span className="w-2 h-2 rounded-full" style={{ backgroundColor: COLORS[index % COLORS.length] }}></span>
                              <span className="font-bold text-cyan-400 group-hover:text-cyan-300 transition-colors">{item.fundCode}</span>
                            </div>
                            <span className="text-zinc-300 text-xs truncate max-w-[200px]">{item.fundName}</span>
                          </Link>
                        </td>
                        <td className="px-6 py-4 text-right font-medium text-white">
                          {item.shares.toLocaleString('tr-TR')}
                        </td>
                        <td className="px-6 py-4 text-right">
                          {item.averageCost.toLocaleString('tr-TR', { minimumFractionDigits: 4 })} ₺
                        </td>
                        <td className="px-6 py-4 text-right font-bold text-white">
                          {item.totalCost.toLocaleString('tr-TR', { minimumFractionDigits: 2 })} ₺
                        </td>
                      </tr>
                    ))}
                  </tbody>
                </table>
              </div>
            </div>

          </div>
        )}

      </div>
    </div>
  );
}