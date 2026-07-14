import { useState } from 'react';
import { Link } from 'react-router-dom';

export default function FundList() {
  const [searchTerm, setSearchTerm] = useState('');
  // Yeni: Kullanıcının seçtiği görünüm modunu hafızada tutuyoruz (Varsayılan: grid)
  const [viewMode, setViewMode] = useState('grid'); 

  const dummyFunds = [
    { id: 1, code: 'MAC', name: 'Marmara Capital Hisse Senedi Fonu', price: '14.52 ₺', trend: '+2.4%', isPositive: true },
    { id: 2, code: 'TCD', name: 'Tacirler Portföy Değişken Fon', price: '45.10 ₺', trend: '-1.2%', isPositive: false },
    { id: 3, code: 'NNF', name: 'Hedef Portföy Hisse Senedi Fonu', price: '8.75 ₺', trend: '+5.1%', isPositive: true },
    { id: 4, code: 'YAS', name: 'Yapı Kredi Koç Holding İştirak Fonu', price: '112.30 ₺', trend: '+0.8%', isPositive: true },
    { id: 5, code: 'AFT', name: 'Ak Portföy Yeni Teknolojiler Fonu', price: '34.20 ₺', trend: '-3.4%', isPositive: false },
    { id: 6, code: 'IPB', name: 'İstanbul Portföy Birinci Değişken Fon', price: '12.45 ₺', trend: '+1.1%', isPositive: true },
    { id: 7, code: 'YKT', name: 'Yapı Kredi Portföy Teknoloji Fonu', price: '88.10 ₺', trend: '+0.2%', isPositive: true },
    { id: 8, code: 'OJT', name: 'QNB Finans Portföy Teknoloji', price: '15.30 ₺', trend: '-0.5%', isPositive: false },
  ];

  const filteredFunds = dummyFunds.filter(fund => 
    fund.name.toLowerCase().includes(searchTerm.toLowerCase()) || 
    fund.code.toLowerCase().includes(searchTerm.toLowerCase())
  );

  return (
    <div className="min-h-screen bg-zinc-950 text-white p-4 md:p-8">
      {/* max-w genişletildi, içerik ekrana daha iyi yayılsın diye */}
      <div className="max-w-[1400px] mx-auto mb-8">
        
        <div className="flex flex-col lg:flex-row justify-between items-start lg:items-end gap-6">
          <div>
            <h1 className="text-2xl font-medium tracking-tight text-zinc-100">Piyasalar</h1>
            <p className="text-zinc-400 mt-1 text-sm">Güncel fon verilerini ve portföyünüzü inceleyin.</p>
          </div>

          <div className="flex flex-col sm:flex-row gap-4 w-full lg:w-auto">
            
            {/* Arama Kutusu (Daha kompakt) */}
            <div className="relative w-full sm:w-80">
              <input
                type="text"
                placeholder="Fon kodu veya adı ara..."
                value={searchTerm}
                onChange={(e) => setSearchTerm(e.target.value)}
                className="w-full bg-zinc-900/80 border border-zinc-800 text-white rounded-lg pl-10 pr-4 py-2.5 text-sm focus:outline-none focus:ring-2 focus:ring-cyan-500 transition-colors"
              />
              <svg className="absolute left-3 top-3 h-4 w-4 text-zinc-500" fill="none" viewBox="0 0 24 24" stroke="currentColor">
                <path strokeLinecap="round" strokeLinejoin="round" strokeWidth={2} d="M21 21l-6-6m2-5a7 7 0 11-14 0 7 7 0 0114 0z" />
              </svg>
            </div>

            {/* Görünüm Değiştirici Butonlar (Toggle) */}
            <div className="flex bg-zinc-900 border border-zinc-800 rounded-lg p-1 shrink-0">
              <button 
                onClick={() => setViewMode('grid')}
                className={`p-1.5 rounded-md transition-colors ${viewMode === 'grid' ? 'bg-zinc-800 text-cyan-400 shadow-sm' : 'text-zinc-500 hover:text-zinc-300'}`}
                title="Blok Görünümü"
              >
                <svg className="w-5 h-5" fill="none" viewBox="0 0 24 24" stroke="currentColor">
                  <path strokeLinecap="round" strokeLinejoin="round" strokeWidth={2} d="M4 6a2 2 0 012-2h2a2 2 0 012 2v2a2 2 0 01-2 2H6a2 2 0 01-2-2V6zM14 6a2 2 0 012-2h2a2 2 0 012 2v2a2 2 0 01-2 2h-2a2 2 0 01-2-2V6zM4 16a2 2 0 012-2h2a2 2 0 012 2v2a2 2 0 01-2 2H6a2 2 0 01-2-2v-2zM14 16a2 2 0 012-2h2a2 2 0 012 2v2a2 2 0 01-2 2h-2a2 2 0 01-2-2v-2z" />
                </svg>
              </button>
              <button 
                onClick={() => setViewMode('list')}
                className={`p-1.5 rounded-md transition-colors ${viewMode === 'list' ? 'bg-zinc-800 text-cyan-400 shadow-sm' : 'text-zinc-500 hover:text-zinc-300'}`}
                title="Liste Görünümü"
              >
                <svg className="w-5 h-5" fill="none" viewBox="0 0 24 24" stroke="currentColor">
                  <path strokeLinecap="round" strokeLinejoin="round" strokeWidth={2} d="M4 6h16M4 12h16M4 18h16" />
                </svg>
              </button>
            </div>
            
          </div>
        </div>
      </div>

      <div className="max-w-[1400px] mx-auto">
        
        {filteredFunds.length === 0 ? (
          <div className="text-center py-12 bg-zinc-900/20 border border-zinc-800/50 rounded-2xl">
            <p className="text-zinc-500 text-sm">Aradığınız kritere uygun fon bulunamadı.</p>
          </div>
        ) : viewMode === 'grid' ? (
          
          /* --- BLOK (GRID) GÖRÜNÜMÜ --- */
          /* Ekran boyutuna göre kolon sayısı: 1 -> 2 -> 3 -> 4 (xl) */
          <div className="grid grid-cols-1 sm:grid-cols-2 lg:grid-cols-3 xl:grid-cols-4 gap-4">
            {filteredFunds.map((fund) => (
              <Link 
                to={`/funds/${fund.id}`} 
                key={fund.id}
                className="block bg-zinc-900/50 border border-zinc-800 rounded-xl p-5 hover:border-cyan-500/50 hover:bg-zinc-900 transition-all duration-200 group"
              >
                <div className="flex justify-between items-start mb-3">
                  <div className="bg-zinc-950 border border-zinc-800 px-2.5 py-1 rounded-md text-xs font-semibold text-cyan-400">
                    {fund.code}
                  </div>
                  <span className={`text-xs font-medium ${fund.isPositive ? 'text-emerald-400' : 'text-rose-400'}`}>
                    {fund.trend}
                  </span>
                </div>
                
                <h2 className="text-sm font-medium text-zinc-300 mb-5 line-clamp-2 min-h-[2.5rem] group-hover:text-white transition-colors">
                  {fund.name}
                </h2>
                
                <div className="flex justify-between items-end border-t border-zinc-800/50 pt-3 mt-auto">
                  <span className="text-zinc-500 text-xs">Fiyat</span>
                  <span className="text-lg font-bold text-white">{fund.price}</span>
                </div>
              </Link>
            ))}
          </div>

        ) : (

          /* --- DETAYLI LİSTE GÖRÜNÜMÜ --- */
          <div className="bg-zinc-900/40 border border-zinc-800 rounded-xl overflow-hidden">
            {/* Tablo Başlıkları (Mobilde Gizli) */}
            <div className="hidden sm:grid sm:grid-cols-12 gap-4 p-4 border-b border-zinc-800 bg-zinc-900/80 text-xs font-medium text-zinc-400 uppercase tracking-wider">
              <div className="col-span-2">Fon Kodu</div>
              <div className="col-span-6">Fon Adı</div>
              <div className="col-span-2 text-right">Günlük Getiri</div>
              <div className="col-span-2 text-right">Fiyat</div>
            </div>
            
            {/* Tablo Satırları */}
            <div className="divide-y divide-zinc-800/50">
              {filteredFunds.map((fund) => (
                <Link 
                  to={`/funds/${fund.id}`} 
                  key={fund.id}
                  className="flex flex-col sm:grid sm:grid-cols-12 gap-2 sm:gap-4 p-4 hover:bg-zinc-800/40 transition-colors items-start sm:items-center group"
                >
                  <div className="col-span-2">
                    <span className="bg-zinc-950 border border-zinc-700 px-2 py-1 rounded text-xs font-semibold text-cyan-400">
                      {fund.code}
                    </span>
                  </div>
                  <div className="col-span-6 w-full">
                    <p className="text-sm font-medium text-zinc-300 group-hover:text-white transition-colors truncate">
                      {fund.name}
                    </p>
                  </div>
                  <div className="col-span-2 w-full sm:text-right flex justify-between sm:block mt-2 sm:mt-0">
                    <span className="sm:hidden text-xs text-zinc-500">Getiri: </span>
                    <span className={`text-sm font-medium ${fund.isPositive ? 'text-emerald-400' : 'text-rose-400'}`}>
                      {fund.trend}
                    </span>
                  </div>
                  <div className="col-span-2 w-full sm:text-right flex justify-between sm:block mt-1 sm:mt-0">
                    <span className="sm:hidden text-xs text-zinc-500">Fiyat: </span>
                    <span className="text-sm font-semibold text-white">{fund.price}</span>
                  </div>
                </Link>
              ))}
            </div>
          </div>

        )}

      </div>
    </div>
  );
}