import axios from 'axios';

// 1. Temel Ayar: Backend'imizin (API) adresini belirliyoruz.
// (Not: İleride .NET projemizi çalıştırdığımızda buradaki port numarasını API'nin Swagger adresindeki port ile güncelleyeceğiz).
const axiosInstance = axios.create({
  baseURL: 'https://localhost:7000/api', 
});

// 2. Interceptor (Araya Girici): Her istek gitmeden önce buraya uğrar.
axiosInstance.interceptors.request.use(
  (config) => {
    // Tarayıcının hafızasından (Local Storage) yaka kartımızı (Token) al.
    const token = localStorage.getItem('token');
    
    // Eğer yaka kartı varsa, bunu "Authorization" başlığı altına "Bearer {token}" formatında yapıştır.
    if (token) {
      config.headers.Authorization = `Bearer ${token}`;
    }
    
    return config; // İsteği backend'e doğru yola çıkar.
  },
  (error) => {
    // Eğer istek yola çıkmadan bir hata olursa bunu yakala.
    return Promise.reject(error);
  }
);

export default axiosInstance;