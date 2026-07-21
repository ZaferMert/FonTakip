import axios from 'axios';

// Temel API ayarlarımızı yapıyoruz
const api = axios.create({
  baseURL: 'http://localhost:5043/api', // Artık her yerde uzun uzun adres yazmayacağız
});

// "Interceptor" (Araya Girici) - Her istek sunucuya gitmeden ÖNCE buraya uğrar
api.interceptors.request.use(
  (config) => {
    // LocalStorage'dan token'ı al
    const token = localStorage.getItem('token');
    
    // Eğer token varsa, isteğin içine otomatik olarak zımbala
    if (token) {
      config.headers.Authorization = `Bearer ${token}`;
    }
    
    return config;
  },
  (error) => {
    return Promise.reject(error);
  }
);

export default api;