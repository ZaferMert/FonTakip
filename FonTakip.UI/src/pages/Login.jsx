import { useState } from 'react';
import { Link, useNavigate } from 'react-router-dom';
import axios from 'axios';

export default function Login() {
  const navigate = useNavigate();
  const [formData, setFormData] = useState({ email: '', password: '' });
  const [error, setError] = useState('');
  const [isLoading, setIsLoading] = useState(false);

  const handleSubmit = async (e) => {
    e.preventDefault();
    
    // --- TEMEL VALİDASYON ---
    if (!formData.email || !formData.password) {
      setError('Lütfen e-posta ve şifrenizi giriniz.');
      return;
    }

    const emailRegex = /^[^\s@]+@[^\s@]+\.[^\s@]+$/;
    if (!emailRegex.test(formData.email)) {
      setError('Lütfen geçerli bir e-posta formatı kullanın.');
      return;
    }

    setError('');
    setIsLoading(true);

    try {
      const response = await axios.post('http://localhost:5043/api/auth/login', {
        email: formData.email,
        password: formData.password
      });
      
      const actualToken = response.data.token || response.data.Token || response.data;
      localStorage.setItem('token', actualToken);
      
      navigate('/funds');
    } catch (err) {
      setError(err.response?.data?.message || 'E-posta veya şifre hatalı.');
    } finally {
      setIsLoading(false);
    }
  };

  return (
    <div className="min-h-screen bg-zinc-950 flex flex-col justify-center py-12 sm:px-6 lg:px-8">
      <div className="sm:mx-auto sm:w-full sm:max-w-md">
        <h2 className="mt-6 text-center text-3xl font-bold tracking-tight text-white">Hesabına Giriş Yap</h2>
      </div>

      <div className="mt-8 sm:mx-auto sm:w-full sm:max-w-md">
        <div className="bg-zinc-900/50 py-8 px-4 shadow sm:rounded-lg sm:px-10 border border-zinc-800">
          <form className="space-y-6" onSubmit={handleSubmit}>
            {error && <div className="p-3 bg-red-500/10 border border-red-500/20 text-red-400 text-sm rounded-md">{error}</div>}
            
            <div>
              <label className="block text-sm font-medium text-zinc-300">E-posta Adresi</label>
              <input type="email" required className="mt-1 block w-full rounded-md border border-zinc-700 bg-zinc-800/50 py-2 px-3 text-white shadow-sm focus:border-cyan-500"
                value={formData.email} onChange={(e) => setFormData({...formData, email: e.target.value})} />
            </div>

            <div>
              <label className="block text-sm font-medium text-zinc-300">Şifre</label>
              <input type="password" required className="mt-1 block w-full rounded-md border border-zinc-700 bg-zinc-800/50 py-2 px-3 text-white shadow-sm focus:border-cyan-500"
                value={formData.password} onChange={(e) => setFormData({...formData, password: e.target.value})} />
            </div>

            <button type="submit" disabled={isLoading} className="flex w-full justify-center rounded-md border border-transparent bg-cyan-600 py-2 px-4 text-sm font-medium text-white shadow-sm hover:bg-cyan-500">
              {isLoading ? 'Giriş Yapılıyor...' : 'Giriş Yap'}
            </button>
          </form>
          <div className="mt-6 text-center text-sm">
            <span className="text-zinc-400">Hesabın yok mu? </span>
            <Link to="/register" className="font-medium text-cyan-500 hover:text-cyan-400">Hemen Kayıt Ol</Link>
          </div>
        </div>
      </div>
    </div>
  );
}