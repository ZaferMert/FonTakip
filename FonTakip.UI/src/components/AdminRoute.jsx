import { Navigate } from 'react-router-dom';

export default function AdminRoute({ children }) {
  const token = localStorage.getItem('token');

  if (!token) {
    return <Navigate to="/login" replace />;
  }

  try {
    const base64Url = token.split('.')[1];
    const base64 = base64Url.replace(/-/g, '+').replace(/_/g, '/');
    const jsonPayload = decodeURIComponent(atob(base64).split('').map(function(c) {
        return '%' + ('00' + c.charCodeAt(0).toString(16)).slice(-2);
    }).join(''));

    const decodedToken = JSON.parse(jsonPayload);

    const userRole = decodedToken['http://schemas.microsoft.com/ws/2008/06/identity/claims/role'] || decodedToken.role;

   
    if (userRole === 'Admin') {
      return children;
    } else {
      return <Navigate to="/funds" replace />;
    }
    
  } catch (error) {
    console.error("Token çözümlenirken hata oluştu veya token geçersiz:", error);
    localStorage.removeItem('token');
    return <Navigate to="/login" replace />;
  }
}