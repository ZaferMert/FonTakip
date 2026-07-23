import { Link, useNavigate, useLocation } from 'react-router-dom';

export default function Navbar() {
  const navigate = useNavigate();
  const location = useLocation();

  let isAdmin = false;
  const token = localStorage.getItem('token');
  if (token) {
    try {
      const base64Url = token.split('.')[1];
      const base64 = base64Url.replace(/-/g, '+').replace(/_/g, '/');
      const jsonPayload = decodeURIComponent(atob(base64).split('').map(function(c) {
          return '%' + ('00' + c.charCodeAt(0).toString(16)).slice(-2);
      }).join(''));
      const decodedToken = JSON.parse(jsonPayload);
      const userRole = decodedToken['http://schemas.microsoft.com/ws/2008/06/identity/claims/role'] || decodedToken.role;
      isAdmin = userRole === 'Admin';
    } catch (e) {
      // Geçersiz token durumu
    }
  }

  const handleLogout = () => {
    localStorage.removeItem('token');
    navigate('/login');
  };

  if (location.pathname === '/' || location.pathname === '/login' || location.pathname === '/register') {
    return null;
  }

  return (
    <nav className="bg-zinc-900 border-b border-zinc-800 px-4 py-3">
      <div className="max-w-[1000px] mx-auto flex flex-wrap justify-between items-center gap-4">
        <Link to="/funds" className="text-xl font-bold text-cyan-500 tracking-wide hover:text-cyan-400 transition-colors">
          FonTakip
        </Link>
        
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

          <Link to="/portfolio" className="text-zinc-300 hover:text-white transition-colors text-sm font-medium">
            Portföyüm
          </Link>

          {isAdmin && (
            <Link 
              to="/admin" 
              className={`text-sm font-medium transition-colors ${location.pathname === '/admin' ? 'text-amber-400' : 'text-amber-500/70 hover:text-amber-400'}`}
            >
              Yönetici Paneli
            </Link>
          )}
          
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