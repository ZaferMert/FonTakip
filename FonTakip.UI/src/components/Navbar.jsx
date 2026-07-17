import { Link, useNavigate, useLocation } from 'react-router-dom';

export default function Navbar() {
  const navigate = useNavigate();
  const location = useLocation();

  const handleLogout = () => {
    // 1. Çıkış yaparken yaka kartını (token) yırtıp atıyoruz
    localStorage.removeItem('token');
    // 2. Kullanıcıyı tekrar giriş ekranına şutluyoruz
    navigate('/login');
  };

  // Login veya Register sayfalarındaysak menüyü göstermeyelim, temiz bir ekran olsun
  if (location.pathname === '/' || location.pathname === '/login' || location.pathname === '/register') {
    return null;
  }

  return (
    <nav className="bg-zinc-900 border-b border-zinc-800 px-4 py-3">
      <div className="max-w-[1000px] mx-auto flex flex-wrap justify-between items-center gap-4">
        {/* Logo / Marka */}
        <Link to="/funds" className="text-xl font-bold text-cyan-500 tracking-wide hover:text-cyan-400 transition-colors">
          FonTakip
        </Link>
        
        {/* Menü Linkleri */}
        <div className="flex gap-4 md:gap-6 items-center">
          <Link 
            to="/funds" 
            className={`text-sm font-medium transition-colors ${location.pathname === '/funds' ? 'text-white' : 'text-zinc-400 hover:text-zinc-200'}`}
          >
            Piyasalar
          </Link>
          <Link 
            to="/favorites" 
            className={`text-sm font-medium transition-colors ${location.pathname === '/favorites' ? 'text-white' : 'text-zinc-400 hover:text-zinc-200'}`}
          >
            Favorilerim
          </Link>
          <Link 
            to="/compare" 
            className={`text-sm font-medium transition-colors ${location.pathname === '/compare' ? 'text-white' : 'text-zinc-400 hover:text-zinc-200'}`}
          >
            Karşılaştır
</Link>
          
          {/* Çıkış Butonu */}
          <button 
            onClick={handleLogout}
            className="ml-2 bg-rose-500/10 text-rose-400 hover:bg-rose-500/20 border border-rose-500/20 px-4 py-1.5 rounded-lg text-sm font-medium transition-colors focus:outline-none"
          >
            Çıkış Yap
          </button>
        </div>
      </div>
    </nav>
  );
}