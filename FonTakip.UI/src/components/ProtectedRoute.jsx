import { Navigate, useLocation } from 'react-router-dom';

export default function ProtectedRoute({ children }) {
  const token = localStorage.getItem('token');
  const location = useLocation();

  if (!token) {
    // If not logged in, redirect to login page and save the attempted URL
    return <Navigate to="/login" state={{ from: location }} replace />;
  }

  return children;
}
