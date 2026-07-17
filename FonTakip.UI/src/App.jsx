import { Routes, Route } from 'react-router-dom';
import Navbar from './components/Navbar'; 
import Login from './pages/Login';
import Register from './pages/Register';
import FundList from './pages/FundList';
import FundDetail from './pages/FundDetail';
import FavoritesList from './pages/FavoritesList'; // YENİ: Sayfamızı içeri aktardık
import CompareFunds from './pages/CompareFunds';

function App() {
  return (
    <div className="min-h-screen bg-zinc-950">
      <Navbar /> 
      
      <Routes>
        <Route path="/" element={<Login />} />
        <Route path="/login" element={<Login />} />
        <Route path="/register" element={<Register />} />
        <Route path="/funds" element={<FundList />} />
        <Route path="/funds/:id" element={<FundDetail />} />
        {/* YENİ: Favoriler rotasını tanımladık */}
        <Route path="/favorites" element={<FavoritesList />} /> 
        <Route path="/compare" element={<CompareFunds />} />
      </Routes>
    </div>
  );
}

export default App;