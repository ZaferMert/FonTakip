import { useState } from 'react';
import { Link } from 'react-router-dom'; 

export default function Login() {
  // Kullanıcının yazdığı bilgileri React'in hafızasında tutuyoruz (State)
  const [username, setUsername] = useState('');
  const [password, setPassword] = useState('');
  const [rememberMe, setRememberMe] = useState(false);

  // Butona basıldığında çalışacak fonksiyon
  const handleLogin = (e) => {
    e.preventDefault(); // Sayfanın yenilenmesini engeller
    console.log("Giriş denemesi:", { username, password, rememberMe });
    // İleride buraya Backend'e (Axios ile) istek atma kodumuzu yazacağız.
  };

  return (
    // Arka plan: Koyu antrasit/siyah tonları
    <div className="min-h-screen bg-zinc-950 flex items-center justify-center p-4">
      
      {/* Form Kartı (Glassmorphism esintili, çok ince çerçeveli elit kutu) */}
      <div className="w-full max-w-md bg-zinc-900 border border-zinc-800 rounded-2xl shadow-2xl p-8">
        
        {/* Başlık Kısmı */}
        <div className="text-center mb-8">
          <h1 className="text-3xl font-bold text-white tracking-tight">Giriş Yap</h1>
          <p className="text-zinc-400 mt-2 text-sm">FonTakip portföyünüze erişin</p>
        </div>

        {/* Form Alanı */}
        <form onSubmit={handleLogin} className="space-y-6">
          
          {/* Kullanıcı Adı Kutusu */}
          <div>
            <label className="block text-sm font-medium text-zinc-300 mb-2">Kullanıcı Adı</label>
            <input
              type="text"
              value={username}
              onChange={(e) => setUsername(e.target.value)}
              className="w-full bg-zinc-950 border border-zinc-800 text-white rounded-lg px-4 py-3 focus:outline-none focus:ring-2 focus:ring-cyan-500 transition-colors"
              placeholder="Kullanıcı adınızı girin"
              required
            />
          </div>

          {/* Şifre Kutusu */}
          <div>
            <label className="block text-sm font-medium text-zinc-300 mb-2">Şifre</label>
            <input
              type="password"
              value={password}
              onChange={(e) => setPassword(e.target.value)}
              className="w-full bg-zinc-950 border border-zinc-800 text-white rounded-lg px-4 py-3 focus:outline-none focus:ring-2 focus:ring-cyan-500 transition-colors"
              placeholder="••••••••"
              required
            />
          </div>

          {/* Beni Hatırla & Şifremi Unuttum */}
          <div className="flex items-center justify-between">
            <div className="flex items-center">
              <input
                type="checkbox"
                id="remember"
                checked={rememberMe}
                onChange={(e) => setRememberMe(e.target.checked)}
                className="h-4 w-4 rounded border-zinc-700 bg-zinc-900 text-cyan-500 focus:ring-cyan-500 focus:ring-offset-zinc-900"
              />
              <label htmlFor="remember" className="ml-2 block text-sm text-zinc-400">
                Beni hatırla
              </label>
            </div>
            <a href="#" className="text-sm font-medium text-cyan-500 hover:text-cyan-400 transition-colors">
              Şifremi unuttum
            </a>
          </div>

          {/* Giriş Yap Butonu */}
          <button
            type="submit"
            className="w-full bg-cyan-600 hover:bg-cyan-500 text-white font-semibold py-3 px-4 rounded-lg transition-all duration-200 transform hover:scale-[1.02]"
          >
            Giriş Yap
          </button>
        </form>

        {/* Kayıt Ol Sayfasına Yönlendirme (Henüz sayfa yok ama linki hazır) */}
        <p className="mt-8 text-center text-sm text-zinc-400">
          Henüz hesabınız yok mu?{' '}
          <Link to="/register" className="font-semibold text-white hover:text-cyan-400 transition-colors">
            Kayıt Ol
          </Link>
        </p>
      </div>
    </div>
  );
}