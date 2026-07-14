import { Routes, Route } from 'react-router-dom'
import Login from './pages/Login'
import Register from './pages/Register'
import FundList from './pages/FundList'
import FundDetail from './pages/FundDetail'

function App() {
  return (
    <div className="min-h-screen bg-zinc-950">
      <Routes>
        <Route path="/" element={<Login />} />
        <Route path="/register" element={<Register />} />
        <Route path="/funds" element={<FundList />} />
        
        {/* :id kısmı dinamiktir. /funds/1 veya /funds/999 yazıldığında id değişkenine o sayıyı atar */}
        <Route path="/funds/:id" element={<FundDetail />} />
      </Routes>
    </div>
  )
}

export default App