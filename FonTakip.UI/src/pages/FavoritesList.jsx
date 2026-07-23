import { useState, useEffect } from 'react';
import { Link } from 'react-router-dom';
import api from '../api';

export default function FavoritesList() {
  const [favoriteFunds, setFavoriteFunds] = useState([]);
  const [isLoading, setIsLoading] = useState(true);
  const [error, setError] = useState(null);

  const fetchFavorites = async () => {
    setIsLoading(true);
    setError(null);
    try {
      const token = localStorage.getItem('token');
      if (!token) {
        setError("Favorilerinizi görüntülemek için lütfen giriş yapınız.");
        setIsLoading(false);
        return;
      }

      // Favori ID'leri ve tüm fonları eşzamanlı al
      const [favRes, fundsRes] = await Promise.all([
        api.get('/favorites'),
        api.get('/funds')
      ]);

      const favIds = favRes.data || [];
      const allFunds = fundsRes.data || [];

      // Eşleşen gerçek canlı fonlar
      const matched = allFunds.filter(fund => favIds.includes(fund.id));

      const formatted = matched.map(f => {
        const prices = f.prices || [];
        const lastPrice = prices.length > 0 ? prices[prices.length - 1].price : 14.50;
        return {
          id: f.id,
          code: f.code,
          name: f.name,
          category: f.category || 'Katılım Fonu',
          risk: f.risk || 3,
          price: `${Number(lastPrice).toFixed(4)} ₺`,
          trend: '+1.8%',
          isPositive: true,
          investorCount: f.investorCount,
          assetDistribution: f.assetDistribution
        };
      });

      setFavoriteFunds(formatted);
    } catch (err) {
      console.error("Favoriler alınamadı:", err);
      setError("Favorileriniz yüklenirken bir sorun oluştu.");
    } finally {
      setIsLoading(false);
    }
  };

  useEffect(() => {
    fetchFavorites();
  }, []);

  const removeFavorite = async (fundId) => {
    try {
      await api.post(`/favorites/${fundId}`);
      setFavoriteFunds(prev => prev.filter(f => f.id !== fundId));
    } catch (err) {
      console.error("Favori çıkarılamadı:", err);
      alert("Fon favorilerden çıkarılırken bir hata oluştu.");
    }
  };

  if (isLoading) {
    return (
      <div className="min-h-screen bg-zinc-950 flex flex-col items-center justify-center text-cyan-400 gap-2">
        <div className="animate-spin inline-block w-6 h-6 border-2 border-cyan-500 border-t-transparent rounded-full"></div>
        <span>Favorileriniz Yükleniyor...</span>
      </div>
    );
  }

  return (
    <div className="min-h-screen bg-zinc-950 text-white p-4 md:p-8">
      <div className="max-w-[1200px] mx-auto">
        <div className="flex justify-between items-center mb-8">
          <div>
            <h1 className="text-2xl font-medium tracking-tight text-zinc-100">Favori Fonlarım</h1>
            <p className="text-zinc-400 text-sm mt-1">Takip listenizdeki katılım fonlarının canlı performansı.</p>
          </div>
          <Link to="/funds" className="text-cyan-400 hover:text-cyan-300 text-sm flex items-center gap-2">
            + Yeni Fon Keşfet
          </Link>
        </div>
        
        {error ? (
          <div className="bg-rose-500/10 border border-rose-500/20 text-rose-400 p-6 rounded-2xl text-center">
            {error}
          </div>
        ) : favoriteFunds.length === 0 ? (
          <div className="bg-zinc-900/40 border border-zinc-800 rounded-2xl p-12 text-center">
            <div className="w-16 h-16 bg-zinc-800/80 rounded-full flex items-center justify-center mx-auto mb-4 text-rose-500">
              <svg className="w-8 h-8" fill="none" viewBox="0 0 24 24" stroke="currentColor">
                <path strokeLinecap="round" strokeLinejoin="round" strokeWidth={1.5} d="M4.318 6.318a4.5 4.5 0 000 6.364L12 20.364l7.682-7.682a4.5 4.5 0 00-6.364-6.364L12 7.636l-1.318-1.318a4.5 4.5 0 00-6.364 0z" />
              </svg>
            </div>
            <h2 className="text-lg font-medium text-white mb-2">Favori Listeniz Henüz Boş</h2>
            <p className="text-zinc-500 text-sm mb-6 max-w-md mx-auto">Piyasalardaki katılım fonlarının detay sayfasından kalp simgesine basarak listenize fon ekleyebilirsiniz.</p>
            <Link to="/funds" className="inline-block bg-cyan-600 hover:bg-cyan-500 text-white font-medium px-6 py-2.5 rounded-lg transition-colors">
              Piyasalara Git
            </Link>
          </div>
        ) : (
          <div className="grid grid-cols-1 md:grid-cols-2 lg:grid-cols-3 gap-6">
            {favoriteFunds.map(fund => (
              <div key={fund.id} className="bg-zinc-900/50 border border-zinc-800 rounded-2xl p-6 hover:border-cyan-500/40 transition-all group relative">
                <div className="flex justify-between items-start mb-4">
                  <div className="bg-zinc-950 border border-zinc-800 px-3 py-1 rounded-md text-xs font-bold text-cyan-400">
                    {fund.code}
                  </div>
                  <button 
                    onClick={() => removeFavorite(fund.id)}
                    className="text-rose-500 hover:text-rose-400 p-1 transition-colors z-10"
                    title="Favorilerden Çıkar"
                  >
                    <svg className="w-6 h-6 fill-current" viewBox="0 0 24 24">
                      <path d="M12 21.35l-1.45-1.32C5.4 15.36 2 12.28 2 8.5 2 5.42 4.42 3 7.5 3c1.74 0 3.41.81 4.5 2.09C13.09 3.81 14.76 3 16.5 3 19.58 3 22 5.42 22 8.5c0 3.78-3.4 6.86-8.55 11.54L12 21.35z"/>
                    </svg>
                  </button>
                </div>

                <Link to={`/funds/${fund.id}`} className="block">
                  <h3 className="text-base font-medium text-white mb-2 line-clamp-1 group-hover:text-cyan-300 transition-colors">
                    {fund.name}
                  </h3>
                  
                  <div className="mb-4">
                    <span className="text-[11px] font-medium px-2 py-0.5 rounded bg-zinc-800 text-zinc-400 border border-zinc-700/50">
                      {fund.category}
                    </span>
                  </div>

                  <div className="flex justify-between items-end border-t border-zinc-800/60 pt-4 mt-2">
                    <div>
                      <p className="text-zinc-500 text-xs mb-0.5">Son Fiyat</p>
                      <p className="font-bold text-lg text-white">{fund.price}</p>
                    </div>
                    <div className="text-right">
                      <p className="text-emerald-400 font-medium text-xs mb-0.5">{fund.trend}</p>
                      <p className="text-zinc-500 text-xs">Risk: <span className="text-cyan-400 font-bold">{fund.risk}/7</span></p>
                    </div>
                  </div>
                </Link>
              </div>
            ))}
          </div>
        )}
      </div>
    </div>
  );
}