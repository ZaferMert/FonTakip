import { Navigate } from 'react-router-dom';

export default function AdminRoute({ children }) {
  const token = localStorage.getItem('token');

  // 1. Token hiç yoksa (Giriş yapılmamışsa) direkt logine gönder
  if (!token) {
    return <Navigate to="/login" replace />;
  }

  try {
    // 2. JWT Token'ın Payload (veri) kısmını çözümlüyoruz
    const base64Url = token.split('.')[1];
    const base64 = base64Url.replace(/-/g, '+').replace(/_/g, '/');
    const jsonPayload = decodeURIComponent(atob(base64).split('').map(function(c) {
        return '%' + ('00' + c.charCodeAt(0).toString(16)).slice(-2);
    }).join(''));

    const decodedToken = JSON.parse(jsonPayload);

    // 3. C# Claim yapısına göre rolü buluyoruz. 
    // .NET genelde rolü uzun bir URL şemasıyla veya direkt "role" adıyla gönderir.
    const userRole = decodedToken['http://schemas.microsoft.com/ws/2008/06/identity/claims/role'] || decodedToken.role;

    // 4. Eğer kullanıcının rolü "Admin" ise sayfanın (children) yüklenmesine izin ver
    if (userRole === 'Admin') {
      return children;
    } else {
      // 5. Giriş yapmış ama Admin değilse piyasalar ekranına yönlendir
      return <Navigate to="/funds" replace />;
    }
    
  } catch (error) {
    console.error("Token çözümlenirken hata oluştu veya token geçersiz:", error);
    // Hatalı veya oynanmış token durumunda güvenliği sağlamak için çıkış yaptır
    localStorage.removeItem('token');
    return <Navigate to="/login" replace />;
  }
}