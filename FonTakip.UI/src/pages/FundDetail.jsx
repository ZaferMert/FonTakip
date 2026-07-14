import { useParams, Link } from 'react-router-dom';

export default function FundDetail() {
  const { id } = useParams();

  const fund = {
    code: 'MAC',
    name: 'Marmara Capital Hisse Senedi Fonu',
    price: '14.52 ₺',
    trend: '+2.4%',
    isPositive: true,
    riskValue: '6 / 7',
    monthlyReturn: '%8.5',
    yearlyReturn: '%112.4'
  };

  return (
    <div className="min-h-screen bg-zinc-950 text-white p-6 md:p-10">
      <div className="max-w-5xl mx-auto">
        
        {/* Üst Menü (Geri Dönüş Butonu) - Küçültüldü */}
        <Link to="/funds" className="inline-flex items-center text-zinc-400 hover:text-cyan-400 text-sm transition-colors mb-6">
          <svg className="w-4 h-4 mr-2" fill="none" viewBox="0 0 24 24" stroke="currentColor">
            <path strokeLinecap="round" strokeLinejoin="round" strokeWidth={2} d="M10 19l-7-7m0 0l7-7m-7 7h18" />
          </svg>
          Piyasalara Dön
        </Link>

        {/* Fon Başlık ve Fiyat Alanı - Yeniden Düzenlendi */}
        <div className="flex flex-col md:flex-row justify-between items-start md:items-center bg-zinc-900 border border-zinc-800 p-6 rounded-2xl mb-8">
          
          {/* Sol Taraf: Kod ve İsim */}
          <div className="mb-4 md:mb-0">
            <div className="inline-block bg-zinc-950 border border-zinc-800 px-2.5 py-1 rounded-md mb-3">
              <span className="font-semibold text-cyan-400 text-sm">{fund.code}</span>
            </div>
            {/* Başlık boyutu ve kalınlığı inceltildi */}
            <h1 className="text-xl md:text-2xl font-medium tracking-tight text-zinc-100">{fund.name}</h1>
          </div>
          
          {/* Sağ Taraf: Fiyat ve Trend */}
          <div className="text-left md:text-right">
            <p className="text-zinc-500 mb-1 text-sm">Güncel Fiyat</p>
            <div className="flex items-center md:justify-end gap-3">
              {/* Fiyat boyutu küçültüldü */}
              <span className="text-2xl md:text-3xl font-bold text-white">{fund.price}</span>
              <span className={`text-sm font-semibold px-2.5 py-1 rounded-lg ${fund.isPositive ? 'bg-emerald-500/10 text-emerald-400' : 'bg-rose-500/10 text-rose-400'}`}>
                {fund.trend}
              </span>
            </div>
          </div>
        </div>

        <div className="grid grid-cols-1 lg:grid-cols-3 gap-8">
          
          {/* Sol Taraf: Grafik Alanı */}
          <div className="lg:col-span-2 bg-zinc-900 border border-zinc-800 rounded-2xl p-8 flex flex-col justify-center items-center min-h-[350px]">
            <svg className="w-12 h-12 text-zinc-700 mb-4" fill="none" viewBox="0 0 24 24" stroke="currentColor">
              <path strokeLinecap="round" strokeLinejoin="round" strokeWidth={1} d="M7 12l3-3 3 3 4-4M8 21l4-4 4 4M3 4h18M4 4h16v12a1 1 0 01-1 1H5a1 1 0 01-1-1V4z" />
            </svg>
            <p className="text-zinc-400 font-medium text-sm">Gelişmiş Grafik Modülü</p>
            <p className="text-zinc-600 text-xs mt-2">(İlerleyen aşamalarda buraya grafik eklenecek)</p>
          </div>

          {/* Sağ Taraf: Fon İstatistikleri ve Aksiyon */}
          <div className="space-y-6">
            
            {/* İstatistik Kartı - Yazılar zarifleştirildi */}
            <div className="bg-zinc-900 border border-zinc-800 rounded-2xl p-6">
              <h3 className="text-base font-semibold text-zinc-100 mb-5 border-b border-zinc-800 pb-3">Fon Özeti</h3>
              
              <div className="space-y-3 text-sm">
                <div className="flex justify-between items-center">
                  <span className="text-zinc-400">Risk Değeri</span>
                  <span className="font-medium text-white">{fund.riskValue}</span>
                </div>
                <div className="flex justify-between items-center">
                  <span className="text-zinc-400">Aylık Getiri</span>
                  <span className="font-medium text-emerald-400">{fund.monthlyReturn}</span>
                </div>
                <div className="flex justify-between items-center">
                  <span className="text-zinc-400">Yıllık Getiri</span>
                  <span className="font-medium text-emerald-400">{fund.yearlyReturn}</span>
                </div>
              </div>
            </div>

            {/* Aksiyon Butonu - Boyutları dengelendi */}
            <button className="w-full bg-cyan-600 hover:bg-cyan-500 text-white font-medium py-3 px-4 rounded-xl transition-all duration-200 transform hover:scale-[1.02] shadow-lg shadow-cyan-500/10 text-sm">
              Portföyüme Ekle
            </button>

          </div>
        </div>
      </div>
    </div>
  );
}