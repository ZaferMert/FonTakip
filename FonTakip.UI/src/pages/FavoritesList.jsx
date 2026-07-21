import { useState, useEffect } from 'react';
import { Link } from 'react-router-dom';
import axios from 'axios';

export default function FavoritesList() {
  const [favoriteIds, setFavoriteIds] = useState([]);
  const [isLoading, setIsLoading] = useState(true);
  const [error, setError] = useState(null);

  const allMockFunds = [
    { id: 1, name: "Marmara Capital Hisse Senedi Fonu", code: "MAC", price: 14.52, change: "+2.4%", risk: 6 },
    { id: 2, name: "Ak Portföy Teknoloji Şirketleri Fonu", code: "AFT", price: 28.30, change: "+1.8%", risk: 7 },
    { id: 3, name: "Yapı Kredi Altın Fonu", code: "YAF", price: 112.40, change: "-0.5%", risk: 5 },
    { id: 4, name: "Hedef Portföy Birinci Hisse Senedi Fonu", code: "NNF", price: 8.75, change: "+3.1%", risk: 6 }
  ];

  const fetchFavorites = async () => {
    try {
      const token = localStorage.getItem('token');
      if (!token) {
        setError("Lütfen giriş yapın.");
        setIsLoading(false);
        return;
      }

      const response = await axios.get('http://localhost:5043/api/favorites', {
        headers: { Authorization: `Bearer ${token}` }
      });
      
      setFavoriteIds(response.data);
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
      const token = localStorage.getItem('token');
      await axios.post(`http://localhost:5043/api/favorites/${fundId}`, {}, {
        headers: { Authorization: `Bearer ${token}` }
      });
      setFavoriteIds(favoriteIds.filter(id => id !== fundId));
    } catch (err) {
      alert("Fon favorilerden çıkarılamadı.");
    }
  };

  const favoriteFunds = allMockFunds.filter(fund => favoriteIds.includes(fund.id));

  if (isLoading) return <div className="min-h-screen bg-zinc-950 flex items-center justify-center text-cyan-500">Yükleniyor...</div>;
  if (error) return <div className="min-h-screen bg-zinc-950 flex items-center justify-center text-red-500">{error}</div>;

  return (
    <div className="min-h-screen bg-zinc-950 text-white p-4 md:p-8">
      <div className="max-w-[1000px] mx-auto">
        <h1 className="text-2xl font-bold mb-6 text-cyan-400">Favori Fonlarım</h1>
        
        {favoriteFunds.length === 0 ? (
          <div className="bg-zinc-900/50 border border-zinc-800 rounded-xl p-8 text-center">
            <p className="text-zinc-400 mb-4">Henüz favorilerinize eklediğiniz bir fon bulunmuyor.</p>
            <Link to="/funds" className="text-cyan-500 hover:text-cyan-400 font-medium">Piyasalara gidip fon keşfedin</Link>
          </div>
        ) : (
          <div className="grid grid-cols-1 md:grid-cols-2 lg:grid-cols-3 gap-4">
            {favoriteFunds.map(fund => (
              <div key={fund.id} className="bg-zinc-900/40 border border-zinc-800 rounded-xl p-5 hover:bg-zinc-900 transition-colors relative group">
                <div className="flex justify-between items-start mb-4">
                  <span className="bg-zinc-800 text-cyan-400 text-xs font-bold px-2 py-1 rounded">{fund.code}</span>
                  <button 
                    onClick={() => removeFavorite(fund.id)}
                    className="text-rose-500 hover:text-rose-400 transition-colors"
                    title="Favorilerden Çıkar"
                  >
                    <svg className="w-6 h-6 fill-current" viewBox="0 0 24 24" stroke="currentColor">
                      <path strokeLinecap="round" strokeLinejoin="round" strokeWidth={0} d="M4.318 6.318a4.5 4.5 0 000 6.364L12 20.364l7.682-7.682a4.5 4.5 0 00-6.364-6.364L12 7.636l-1.318-1.318a4.5 4.5 0 00-6.364 0z" />
                    </svg>
                  </button>
                </div>
                <h3 className="text-lg font-medium mb-4 line-clamp-1">{fund.name}</h3>
                <div className="flex justify-between items-end">
                  <div>
                    <p className="text-zinc-500 text-sm">Fiyat</p>
                    <p className="font-bold text-lg">{fund.price} ₺</p>
                  </div>
                  <div className="text-right">
                    <p className="text-emerald-400 font-medium">{fund.change}</p>
                    <p className="text-zinc-600 text-xs mt-1">Risk: {fund.risk}/7</p>
                  </div>
                </div>
                <Link to={`/funds/${fund.id}`} className="absolute inset-0 z-0"></Link>
                <div className="relative z-10"></div>
              </div>
            ))}
          </div>
        )}
      </div>
    </div>
  );
}