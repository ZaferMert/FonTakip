import { useState } from 'react';
import { Link, useNavigate } from 'react-router-dom';
import axios from 'axios';

export default function Register() {
  const navigate = useNavigate();
  const [formData, setFormData] = useState({ fullName: '', email: '', password: '' });
  const [errors, setErrors] = useState({});
  const [generalError, setGeneralError] = useState('');
  const [isLoading, setIsLoading] = useState(false);

  const validateForm = () => {
    const newErrors = {};
    if (!formData.fullName) {
      newErrors.fullName = 'Ad Soyad alanı zorunludur.';
    } else if (formData.fullName.trim().length < 3) {
      newErrors.fullName = 'Ad Soyad en az 3 karakter olmalıdır.';
    }

    if (!formData.email) {
      newErrors.email = 'E-posta alanı zorunludur.';
    } else {
      const emailRegex = /^[^\s@]+@[^\s@]+\.[^\s@]+$/;
      if (!emailRegex.test(formData.email)) {
        newErrors.email = 'Geçerli bir e-posta adresi giriniz.';
      }
    }

    if (!formData.password) {
      newErrors.password = 'Şifre alanı zorunludur.';
    } else {
      const passwordRegex = /^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)[a-zA-Z\d\W]{8,}$/;
      if (!passwordRegex.test(formData.password)) {
        newErrors.password = 'Şifre en az 8 karakter, 1 büyük harf, 1 küçük harf ve 1 rakam içermelidir.';
      }
    }

    setErrors(newErrors);
    return Object.keys(newErrors).length === 0;
  };

  const handleSubmit = async (e) => {
    e.preventDefault();

    const isValid = validateForm();
    if (!isValid) {
      return;
    }

    setGeneralError('');
    setIsLoading(true);

    try {
      // 1. Kullanıcıyı kaydet
      await axios.post('http://localhost:5043/api/auth/register', {
        fullName: formData.fullName,
        email: formData.email,
        password: formData.password
      });
      
      // 2. Başarılı kayıt sonrası otomatik giriş yap
      const loginRes = await axios.post('http://localhost:5043/api/auth/login', {
        email: formData.email,
        password: formData.password
      });

      // 3. Token'ı kaydet ve uygulamaya (portföye/fonlara) yönlendir
      if (loginRes.data && loginRes.data.token) {
        localStorage.setItem('token', loginRes.data.token);
        // İsteğe bağlı olarak kullanıcı adını da tutabilirsiniz
        localStorage.setItem('userName', formData.fullName);
        navigate('/funds');
        // Navigasyon sonrası tam sayfa yenileme ile auth state'i güncellensin
        window.location.reload();
      } else {
        navigate('/login');
      }

    } catch (err) {
      setGeneralError(err.response?.data?.message || 'Kayıt olurken bir hata oluştu.');
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
            {generalError && <div className="p-3 bg-red-500/10 border border-red-500/20 text-red-400 text-sm rounded-md">{generalError}</div>}
            
            <div>
              <label className="block text-sm font-medium text-zinc-300">Ad Soyad</label>
              <input type="text" className={`mt-1 block w-full rounded-md border bg-zinc-800/50 py-2 px-3 text-white shadow-sm focus:outline-none focus:ring-1 ${errors.fullName ? 'border-red-500 focus:border-red-500 focus:ring-red-500' : 'border-zinc-700 focus:border-cyan-500 focus:ring-cyan-500'}`}
                value={formData.fullName} onChange={(e) => { setFormData({...formData, fullName: e.target.value}); if(errors.fullName) setErrors({...errors, fullName: null}); }} />
              {errors.fullName && <p className="mt-1 text-sm text-red-500">{errors.fullName}</p>}
            </div>

            <div>
              <label className="block text-sm font-medium text-zinc-300">E-posta Adresi</label>
              <input type="email" className={`mt-1 block w-full rounded-md border bg-zinc-800/50 py-2 px-3 text-white shadow-sm focus:outline-none focus:ring-1 ${errors.email ? 'border-red-500 focus:border-red-500 focus:ring-red-500' : 'border-zinc-700 focus:border-cyan-500 focus:ring-cyan-500'}`}
                value={formData.email} onChange={(e) => { setFormData({...formData, email: e.target.value}); if(errors.email) setErrors({...errors, email: null}); }} />
              {errors.email && <p className="mt-1 text-sm text-red-500">{errors.email}</p>}
            </div>

            <div>
              <label className="block text-sm font-medium text-zinc-300">Şifre</label>
              <input type="password" className={`mt-1 block w-full rounded-md border bg-zinc-800/50 py-2 px-3 text-white shadow-sm focus:outline-none focus:ring-1 ${errors.password ? 'border-red-500 focus:border-red-500 focus:ring-red-500' : 'border-zinc-700 focus:border-cyan-500 focus:ring-cyan-500'}`}
                value={formData.password} onChange={(e) => { setFormData({...formData, password: e.target.value}); if(errors.password) setErrors({...errors, password: null}); }} />
              {errors.password && <p className="mt-1 text-sm text-red-500">{errors.password}</p>}
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