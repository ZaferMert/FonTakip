import { Routes, Route } from 'react-router-dom';
import Navbar from './components/Navbar'; 
import Login from './pages/Login';
import Register from './pages/Register';
import FundList from './pages/FundList';
import FundDetail from './pages/FundDetail';
import FavoritesList from './pages/FavoritesList'; // YENİ: Sayfamızı içeri aktardık
import CompareFunds from './pages/CompareFunds';
import Admin from './pages/Admin';
import Portfolio from './pages/Portfolio';
import AdminRoute from './components/AdminRoute';
import ProtectedRoute from './components/ProtectedRoute';

function App() {
  return (
    <div className="min-h-screen bg-zinc-950">
      <Navbar /> 
      
      <Routes>
        <Route path="/" element={<Login />} />
        <Route path="/login" element={<Login />} />
        <Route path="/register" element={<Register />} />
        <Route path="/funds" element={<ProtectedRoute><FundList /></ProtectedRoute>} />
        <Route path="/funds/:id" element={<ProtectedRoute><FundDetail /></ProtectedRoute>} />
        <Route path="/favorites" element={<ProtectedRoute><FavoritesList /></ProtectedRoute>} /> 
        <Route path="/compare" element={<ProtectedRoute><CompareFunds /></ProtectedRoute>} />
        <Route path="/admin" element={
          <ProtectedRoute>
            <AdminRoute>
              <Admin />
            </AdminRoute>
          </ProtectedRoute>
        } />
        <Route path="/portfolio" element={<ProtectedRoute><Portfolio /></ProtectedRoute>} />
      </Routes>
    </div>
  );
}

export default App;