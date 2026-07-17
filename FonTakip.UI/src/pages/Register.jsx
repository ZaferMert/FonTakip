import { useState } from 'react';
import { Link, useNavigate } from 'react-router-dom';
import axios from 'axios';

export default function Register() {
  const navigate = useNavigate();
  const [formData, setFormData] = useState({ fullName: '', email: '', password: '' });
  const [error, setError] = useState('');
  const [isLoading, setIsLoading] = useState(false);

  const handleSubmit = async (e) => {
    e.preventDefault();
    setError('');
    setIsLoading(true);

    try {
      // Backend'deki kayıt olma (Register) uç noktasına bilgileri gönderiyoruz
      // Not: API URL'ini kendi AuthController'ına göre gerekirse düzenleyebilirsin
      await axios.post('http://localhost:5043/api/auth/register', {
        fullName: formData.fullName,
        email: formData.email,
        password: formData.password
      });
      
      // Başarılı olursa kullanıcıyı Login ekranına yönlendir
      navigate('/login');
    } catch (err) {
      setError(err.response?.data?.message || 'Kayıt olurken bir hata oluştu.');
    } finally {
      setIsLoading(false);
    }
  };

  return (
    <div className="min-h-screen bg-zinc-950 flex flex-col justify-center py-12 sm:px-6 lg:px-8">
      <div className="sm:mx-auto sm:w-full sm:max-w-md">
        <h2 className="mt-6 text-center text-3xl font-bold tracking-tight text-white">Yeni Hesap Oluştur</h2>
      </div>

      <div className="mt-8 sm:mx-auto sm:w-full sm:max-w-md">
        <div className="bg-zinc-900/50 py-8 px-4 shadow sm:rounded-lg sm:px-10 border border-zinc-800">
          <form className="space-y-6" onSubmit={handleSubmit}>
            {error && <div className="p-3 bg-red-500/10 border border-red-500/20 text-red-400 text-sm rounded-md">{error}</div>}
            
            <div>
              <label className="block text-sm font-medium text-zinc-300">Ad Soyad</label>
              <input type="text" required className="mt-1 block w-full rounded-md border border-zinc-700 bg-zinc-800/50 py-2 px-3 text-white shadow-sm focus:border-cyan-500 focus:outline-none focus:ring-1 focus:ring-cyan-500"
                value={formData.fullName} onChange={(e) => setFormData({...formData, fullName: e.target.value})} />
            </div>

            <div>
              <label className="block text-sm font-medium text-zinc-300">E-posta Adresi</label>
              <input type="email" required className="mt-1 block w-full rounded-md border border-zinc-700 bg-zinc-800/50 py-2 px-3 text-white shadow-sm focus:border-cyan-500 focus:outline-none focus:ring-1 focus:ring-cyan-500"
                value={formData.email} onChange={(e) => setFormData({...formData, email: e.target.value})} />
            </div>

            <div>
              <label className="block text-sm font-medium text-zinc-300">Şifre</label>
              <input type="password" required className="mt-1 block w-full rounded-md border border-zinc-700 bg-zinc-800/50 py-2 px-3 text-white shadow-sm focus:border-cyan-500 focus:outline-none focus:ring-1 focus:ring-cyan-500"
                value={formData.password} onChange={(e) => setFormData({...formData, password: e.target.value})} />
            </div>

            <button type="submit" disabled={isLoading} className="flex w-full justify-center rounded-md border border-transparent bg-cyan-600 py-2 px-4 text-sm font-medium text-white shadow-sm hover:bg-cyan-500 focus:outline-none">
              {isLoading ? 'Kaydediliyor...' : 'Kayıt Ol'}
            </button>
          </form>
          <div className="mt-6 text-center text-sm">
            <span className="text-zinc-400">Zaten hesabın var mı? </span>
            <Link to="/login" className="font-medium text-cyan-500 hover:text-cyan-400">Giriş Yap</Link>
          </div>
        </div>
      </div>
    </div>
  );
}