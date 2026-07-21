import { useState, useEffect } from 'react';
import axios from 'axios';
import { Link } from 'react-router-dom';

export default function Admin() {
  const [file, setFile] = useState(null);
  const [message, setMessage] = useState('');
  const [isLoading, setIsLoading] = useState(false);
  const [isError, setIsError] = useState(false);

  const [funds, setFunds] = useState([]);
  
  const [formData, setFormData] = useState({ id: null, name: '', code: '', risk: 1, category: 'Hisse Senedi' });
  const [formError, setFormError] = useState('');
  const [isEditing, setIsEditing] = useState(false); 

  useEffect(() => {
    fetchFunds();
  }, []);

  const fetchFunds = async () => {
    try {
      const response = await axios.get('http://localhost:5043/api/funds');
      setFunds(response.data);
    } catch (error) {
      console.error("Fonlar getirilemedi:", error);
    }
  };

  const handleSaveFund = async (e) => {
    e.preventDefault();

    if (!formData.name.trim() || !formData.code.trim()) {
      setFormError("Fon adı ve fon kodu boş bırakılamaz!");
      return;
    }
    if (formData.code.length > 5) {
      setFormError("Fon kodu en fazla 5 karakter olmalıdır (Örn: MAC, AFT).");
      return;
    }

    setFormError('');

    try {
      const token = localStorage.getItem('token');
      
      const payload = {
        name: formData.name,
        code: formData.code.toUpperCase(),
        risk: Number(formData.risk),
        category: formData.category,
        isActive: true
      };

      const config = {
        headers: { 'Authorization': `Bearer ${token}` }
      };

      if (isEditing) {
        await axios.put(`http://localhost:5043/api/funds/${formData.id}`, { ...payload, id: formData.id }, config);
      } else {
        await axios.post('http://localhost:5043/api/funds', payload, config);
      }
      
      setFormData({ id: null, name: '', code: '', risk: 1, category: 'Hisse Senedi' });
      setIsEditing(false);
      fetchFunds();
    } catch (error) {
      console.error("İşlem başarısız:", error);
      setFormError("İşlem sırasında sunucu hatası oluştu.");
    }
  };

  const handleEditClick = (fund) => {
    setFormData({
      id: fund.id,
      name: fund.name,
      code: fund.code,
      risk: fund.risk,
      category: fund.category || 'Hisse Senedi'
    });
    setIsEditing(true);
    setFormError('');
  };

  const handleCancelEdit = () => {
    setFormData({ id: null, name: '', code: '', risk: 1, category: 'Hisse Senedi' });
    setIsEditing(false);
    setFormError('');
  };

  const handleDeleteFund = async (id) => {
    const isConfirmed = window.confirm("Bu fonu silmek istediğinize emin misiniz?");
    if (!isConfirmed) return;

    try {
      const token = localStorage.getItem('token');
      await axios.delete(`http://localhost:5043/api/funds/${id}`, {
        headers: { 'Authorization': `Bearer ${token}` }
      });
      fetchFunds();
    } catch (error) {
      console.error("Fon silinemedi:", error);
    }
  };

  const handleFileChange = (e) => {
    setFile(e.target.files[0]);
    setMessage('');
    setIsError(false);
  };

  const handleUpload = async () => {
    if (!file) {
      setIsError(true);
      setMessage("Lütfen önce bir CSV dosyası seçin.");
      return;
    }
    const uploadData = new FormData();
    uploadData.append("file", file);
    setIsLoading(true);
    setMessage('');
    setIsError(false);

    try {
      const token = localStorage.getItem('token');
      const response = await axios.post('http://localhost:5043/api/funds/upload-csv', uploadData, {
        headers: { 
          'Content-Type': 'multipart/form-data',
          'Authorization': `Bearer ${token}` 
        }
      });
      setMessage(response.data);
      setFile(null);
      document.getElementById('csv-upload').value = '';
    } catch (error) {
      setIsError(true);
      setMessage(error.response?.data || "Yükleme hatası.");
    } finally {
      setIsLoading(false);
    }
  };

  return (
    <div className="min-h-screen bg-zinc-950 text-white p-4 md:p-8">
      <div className="max-w-[1200px] mx-auto">
        <div className="mb-8 flex justify-between items-center">
          <h1 className="text-2xl font-medium tracking-tight text-zinc-100">Yönetim Paneli</h1>
          <Link to="/funds" className="text-cyan-500 hover:text-cyan-400 text-sm flex items-center gap-2">
            Uygulamaya Dön &rarr;
          </Link>
        </div>

        <div className="grid grid-cols-1 lg:grid-cols-3 gap-6">
          
          <div className="lg:col-span-1 space-y-6">
            
            <div className={`border rounded-2xl p-6 transition-colors ${isEditing ? 'bg-cyan-950/20 border-cyan-500/50' : 'bg-zinc-900/40 border-zinc-800'}`}>
              {/* BAŞLIK DİNAMİK OLARAK DEĞİŞİYOR */}
              <h2 className="text-lg font-medium text-white mb-4 border-b border-zinc-800 pb-2">
                {isEditing ? 'Fonu Güncelle' : 'Yeni Fon Ekle'}
              </h2>
              
              {formError && (
                <div className="bg-rose-500/10 text-rose-400 border border-rose-500/20 p-3 rounded-lg text-sm mb-4">
                  {formError}
                </div>
              )}

              <form onSubmit={handleSaveFund} className="space-y-4">
                <div>
                  <label className="block text-xs font-medium text-zinc-500 mb-1">Fon Adı</label>
                  <input type="text" value={formData.name} onChange={(e) => setFormData({...formData, name: e.target.value})} className="w-full bg-zinc-950 border border-zinc-800 rounded-lg px-3 py-2 text-sm focus:outline-none focus:ring-1 focus:ring-cyan-500" placeholder="Örn: Marmara Capital..." />
                </div>
                <div>
                  <label className="block text-xs font-medium text-zinc-500 mb-1">Kısa Kod</label>
                  <input type="text" value={formData.code} onChange={(e) => setFormData({...formData, code: e.target.value})} className="w-full bg-zinc-950 border border-zinc-800 rounded-lg px-3 py-2 text-sm focus:outline-none focus:ring-1 focus:ring-cyan-500 uppercase" placeholder="Örn: MAC" />
                </div>
                <div className="grid grid-cols-2 gap-4">
                  <div>
                    <label className="block text-xs font-medium text-zinc-500 mb-1">Risk (1-7)</label>
                    <input type="number" min="1" max="7" value={formData.risk} onChange={(e) => setFormData({...formData, risk: e.target.value})} className="w-full bg-zinc-950 border border-zinc-800 rounded-lg px-3 py-2 text-sm focus:outline-none focus:ring-1 focus:ring-cyan-500" />
                  </div>
                  <div>
                    <label className="block text-xs font-medium text-zinc-500 mb-1">Kategori</label>
                    <select value={formData.category} onChange={(e) => setFormData({...formData, category: e.target.value})} className="w-full bg-zinc-950 border border-zinc-800 rounded-lg px-3 py-2 text-sm focus:outline-none focus:ring-1 focus:ring-cyan-500">
                      <option value="Hisse Senedi">Hisse Senedi</option>
                      <option value="Kıymetli Maden">Kıymetli Maden</option>
                      <option value="Teknoloji">Teknoloji</option>
                    </select>
                  </div>
                </div>
                
                {/* BUTONLAR DİNAMİK OLARAK DEĞİŞİYOR */}
                <div className="pt-2 flex gap-3">
                  <button type="submit" className={`flex-1 py-2 rounded-lg text-sm font-medium transition-colors ${isEditing ? 'bg-cyan-600 hover:bg-cyan-500 text-white' : 'bg-cyan-600 hover:bg-cyan-500 text-white'}`}>
                    {isEditing ? 'Değişiklikleri Kaydet' : 'Fonu Sisteme Ekle'}
                  </button>
                  
                  {isEditing && (
                    <button type="button" onClick={handleCancelEdit} className="flex-1 bg-zinc-800 hover:bg-zinc-700 text-white py-2 rounded-lg text-sm font-medium transition-colors">
                      İptal Et
                    </button>
                  )}
                </div>
              </form>
            </div>

            <div className="bg-zinc-900/40 border border-zinc-800 rounded-2xl p-6">
              <h2 className="text-lg font-medium text-white mb-2">Fiyatları Güncelle</h2>
              <p className="text-zinc-500 text-xs mb-4">Sütunlar: FundId, Date, Price olmalıdır.</p>
              <input type="file" id="csv-upload" accept=".csv" onChange={handleFileChange} className="block w-full text-xs text-zinc-400 file:mr-3 file:py-1.5 file:px-3 file:rounded-md file:border-0 file:text-xs file:font-medium file:bg-zinc-800 file:text-white mb-3" />
              <button onClick={handleUpload} disabled={isLoading} className={`w-full py-2 rounded-lg text-sm font-medium ${isLoading ? 'bg-zinc-800 text-zinc-500' : 'bg-zinc-800 hover:bg-zinc-700 text-white'}`}>
                {isLoading ? 'İşleniyor...' : 'CSV Yükle'}
              </button>
              {message && <div className={`p-3 rounded-lg mt-3 text-xs ${isError ? 'bg-rose-500/10 text-rose-400' : 'bg-emerald-500/10 text-emerald-400'}`}>{message}</div>}
            </div>

          </div>

          <div className="lg:col-span-2 bg-zinc-900/40 border border-zinc-800 rounded-2xl p-6">
            <h2 className="text-lg font-medium text-white mb-4 border-b border-zinc-800 pb-2">Aktif Fon Listesi</h2>
            <div className="overflow-x-auto">
              <table className="w-full text-left text-sm text-zinc-400">
                <thead className="text-xs text-zinc-500 uppercase bg-zinc-950/50">
                  <tr>
                    <th className="px-4 py-3 rounded-tl-lg">ID</th>
                    <th className="px-4 py-3">Kod</th>
                    <th className="px-4 py-3">Fon Adı</th>
                    <th className="px-4 py-3">Kategori</th>
                    <th className="px-4 py-3 rounded-tr-lg text-right">İşlemler</th>
                  </tr>
                </thead>
                <tbody>
                  {funds.map((fund) => (
                    <tr key={fund.id} className="border-b border-zinc-800/50 hover:bg-zinc-800/20">
                      <td className="px-4 py-3 font-medium text-zinc-500">#{fund.id}</td>
                      <td className="px-4 py-3 font-bold text-cyan-400">{fund.code}</td>
                      <td className="px-4 py-3 text-zinc-200">{fund.name}</td>
                      <td className="px-4 py-3">{fund.category || '-'}</td>
                      <td className="px-4 py-3 text-right flex justify-end gap-2">
                        {/* DÜZENLE BUTONU */}
                        <button 
                          onClick={() => handleEditClick(fund)}
                          className="text-cyan-500 hover:text-cyan-400 font-medium text-xs px-3 py-1 border border-cyan-500/30 rounded-md hover:bg-cyan-500/10 transition-colors"
                        >
                          Düzenle
                        </button>
                        <button 
                          onClick={() => handleDeleteFund(fund.id)}
                          className="text-rose-500 hover:text-rose-400 font-medium text-xs px-3 py-1 border border-rose-500/30 rounded-md hover:bg-rose-500/10 transition-colors"
                        >
                          Sil
                        </button>
                      </td>
                    </tr>
                  ))}
                  {funds.length === 0 && (
                    <tr>
                      <td colSpan="5" className="px-4 py-8 text-center text-zinc-500">Sistemde kayıtlı fon bulunmuyor.</td>
                    </tr>
                  )}
                </tbody>
              </table>
            </div>
          </div>

        </div>
      </div>
    </div>
  );
}