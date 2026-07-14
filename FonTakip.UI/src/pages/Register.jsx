import { useState } from 'react';
import { Link } from 'react-router-dom'; 

export default function Register() {
  // Kullanıcıdan alınacak veriler için hafıza (State) tanımlamaları
  const [fullName, setFullName] = useState('');
  const [username, setUsername] = useState('');
  const [password, setPassword] = useState('');
  const [confirmPassword, setConfirmPassword] = useState('');

  // Kayıt ol butonuna basıldığında çalışacak mantık
  const handleRegister = (e) => {
    e.preventDefault(); 
    
    // Şifrelerin aynı olup olmadığını önyüzde (frontend) kontrol ediyoruz
    if (password !== confirmPassword) {
      alert("Hata: Şifreler birbiriyle eşleşmiyor!");
      return;
    }

    console.log("Kayıt denemesi:", { fullName, username, password });
    // İleride backend API'mizin /register ucuna bu verileri göndereceğiz.
  };

  return (
    <div className="min-h-screen bg-zinc-950 flex items-center justify-center p-4">
      
      {/* Form Kartı */}
      <div className="w-full max-w-md bg-zinc-900 border border-zinc-800 rounded-2xl shadow-2xl p-8">
        
        <div className="text-center mb-8">
          <h1 className="text-3xl font-bold text-white tracking-tight">Kayıt Ol</h1>
          <p className="text-zinc-400 mt-2 text-sm">FonTakip ailesine katılın</p>
        </div>

        <form onSubmit={handleRegister} className="space-y-5">
          
          {/* Ad-Soyad Kutusu */}
          <div>
            <label className="block text-sm font-medium text-zinc-300 mb-1">Ad Soyad</label>
            <input
              type="text"
              value={fullName}
              onChange={(e) => setFullName(e.target.value)}
              className="w-full bg-zinc-950 border border-zinc-800 text-white rounded-lg px-4 py-2.5 focus:outline-none focus:ring-2 focus:ring-cyan-500 transition-colors"
              placeholder="Örn: Zafer Mert Serinken"
              required
            />
          </div>

          {/* Kullanıcı Adı Kutusu */}
          <div>
            <label className="block text-sm font-medium text-zinc-300 mb-1">Kullanıcı Adı</label>
            <input
              type="text"
              value={username}
              onChange={(e) => setUsername(e.target.value)}
              className="w-full bg-zinc-950 border border-zinc-800 text-white rounded-lg px-4 py-2.5 focus:outline-none focus:ring-2 focus:ring-cyan-500 transition-colors"
              placeholder="Benzersiz bir kullanıcı adı belirleyin"
              required
            />
          </div>

          {/* Şifre Kutusu */}
          <div>
            <label className="block text-sm font-medium text-zinc-300 mb-1">Şifre</label>
            <input
              type="password"
              value={password}
              onChange={(e) => setPassword(e.target.value)}
              className="w-full bg-zinc-950 border border-zinc-800 text-white rounded-lg px-4 py-2.5 focus:outline-none focus:ring-2 focus:ring-cyan-500 transition-colors"
              placeholder="••••••••"
              required
            />
          </div>

          {/* Şifre Tekrar Kutusu */}
          <div>
            <label className="block text-sm font-medium text-zinc-300 mb-1">Şifre Tekrar</label>
            <input
              type="password"
              value={confirmPassword}
              onChange={(e) => setConfirmPassword(e.target.value)}
              className="w-full bg-zinc-950 border border-zinc-800 text-white rounded-lg px-4 py-2.5 focus:outline-none focus:ring-2 focus:ring-cyan-500 transition-colors"
              placeholder="••••••••"
              required
            />
          </div>

          {/* Kayıt Ol Butonu */}
          <button
            type="submit"
            className="w-full bg-cyan-600 hover:bg-cyan-500 text-white font-semibold py-3 px-4 rounded-lg transition-all duration-200 transform hover:scale-[1.02] mt-2"
          >
            Hesap Oluştur
          </button>
        </form>

        {/* Giriş Yap Sayfasına Yönlendirme */}
        <p className="mt-6 text-center text-sm text-zinc-400">
          Zaten bir hesabınız var mı?{' '}
          <Link to="/" className="font-semibold text-white hover:text-cyan-400 transition-colors">
            Giriş Yap
          </Link>
        </p>
      </div>
    </div>
  );
}